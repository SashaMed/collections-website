using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Course_project.Data;
using Course_project.Models;
using Course_project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Course_project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PusherServer;

namespace Course_project.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;


        public ItemsController(ApplicationDbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }



        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 15;   
            var count = await _context.Items.CountAsync();
            var items = await _context.Items.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexItemViewModel viewModel = new IndexItemViewModel
            {
                UserId = GetUserId(),
                PageViewModel = pageViewModel,
                Items = items
            };
            return View(viewModel);
        }

        public IActionResult TagSearch(string id)
        {
            var tag = _context.Tags.FirstOrDefault(m => m.Name == id);
            var tagId = tag.Id;
            var connections = _context.TagConnections.Where(m => m.TagId == tagId);
            var items = new List<Item>();
            foreach (var connection in connections)
            {
                var t = _context.Items.FirstOrDefault(e => e.Id == connection.ItemId);
                if (t != null)
                {
                    items.Add(t);
                }
            }

            return View(new TagSearchViewModel
            {
                items = items,
                tag = tag,
                userId = GetUserId()
            });
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            var collection = _context.Collections.FirstOrDefault(m => m.Id == item.CollectionId);

            if (collection == null)
            {
                return NotFound();
            }

            var tagConnections = _context.TagConnections.Where(m => m.ItemId == id);
            var tagList = new List<Tag>();
            if (tagConnections != null)
            {
                foreach (var tag in tagConnections)
                {
                    tagList.Add(_context.Tags.Find(tag.TagId));
                }
            }

            var comments = _context.Comments.Where(m => m.ItemId == id).ToList();

            var response = new DetailsItemViewModel
            {
                comments = comments,
                userName = HttpContext.User.Identity.Name,
                userId = GetUserId(),
                collection = collection,
                item = item,
                tags = tagList
            };
            return View(response);
        }



        [Authorize]
        public IActionResult Create(int? CollectionId)
        {
            var response = new CreateItemViewModel(_context.Collections.FirstOrDefault(m => m.Id == CollectionId), new Item());
            var tags = _context.Tags.ToList();
            response.Tags = new List<string>();
            foreach (var tag in tags)
            {
                response.Tags.Add(tag.Name);
            }
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel item)
        {
            if (ModelState.IsValid)
            {

                var result = await _photoService.AddPhotoAsync(item.Image);
                item.ThisItem.ImagePath = result.Url.ToString();
                _context.Add(item.ThisItem);
                await _context.SaveChangesAsync();
                await CreateTags(item.Tags[0], item.ThisItem.Id);
                return RedirectToAction("CollectionItems", "Collection", new { CollectionId = item.ThisItem.CollectionId });
            }

            return View(new CreateItemViewModel(_context.Collections.FirstOrDefault(m => m.Id == item.ThisItem.CollectionId), item.ThisItem));
        }

        public async Task CreateTags(string input, int itemID)
		{
            var tags = input.Split(',');
            foreach(var tag in tags)
			{
                var t = await _context.Tags.FirstOrDefaultAsync(m => m.Name == tag);
                if (t == null)
                {
                    t = new Tag { 
                        Id = tag,
                        Name = tag };
                    _context.Tags.Add(t);
                }
                var connection = new TagConnection
                {
                    ItemId = itemID,
                    TagId = t.Id
                };
                _context.TagConnections.Add(connection);
                await _context.SaveChangesAsync();
            }
		}


        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }


            var item = await _context.Items.FindAsync(id);
            
            if (item == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections.FindAsync(item.CollectionId);
            
            if (collection == null)
            {
                return NotFound();
            }

            var response = new EditItemViewModel(collection, item, item.Id)
            {
                ImagePath = item.ImagePath
            };
            return View(response);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditItemViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.Image != null)
                    {
                        var result = await _photoService.AddPhotoAsync(input.Image);
                        input.ThisItem.ImagePath = result.Url.ToString();
                    }

                    _context.Update(input.ThisItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(input.ThisItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Items", new { id = input.ThisItem.Id });
            }
            return View(new EditItemViewModel());
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }
            int collectionId = 0;
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                collectionId = item.CollectionId;
                _context.Items.Remove(item);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("CollectionItems", "Collection", new { CollectionId = collectionId });
        }

        private bool ItemExists(int id)
        {
          return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        

        public string GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;
                return userId;
            }
            return null;
        }
    }
}
