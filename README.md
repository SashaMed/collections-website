# collections-website

### What is this project using?
* C#
* ASP.NET Core MVC
* EntityFrameworkCore
* JavaScript
* SignalR
* Bootstrap 
* Cloudinary

### Description
Web-app for managing personal collections (collections of books, photos, paintings, and so on — in the text below it calls items). 
Unauthenticated users have read-only rights (they can not create collections and items, comment, and rate items).
Authenticated not-admin users have the right to create, update, delete their collections and items, comment, and rate items.

Admin users can manage other users' accounts — block, unblock, delete, and grant or take admin rights.
Admin sees all pages like their author (for example, admin can open a collection of any other user and add an item to it; in fact, admins are owners of all items and collections).
Only the admin or owner of collections or items can manipulate them (edit, add, delete), but all users can read everything (except the admin page).

Users can register and login. 
All authenticated users have a personal page, where user can manage their collections (create, delete, edit) — each collection is a link to the collection page, which contains an items table. It is allowed to create new items, and delete and edit the existing ones.
Each collection has a name, description, and type (one value from a fixed reference, for example, “Books”, “Photos”, “Paintings”).
Additionally collection allows you to choose fields, that items will inherit from this collection. At the collection level, you can select any set from the following available fields:
3 integer fields, 3 string fields, 3 multiline text fields, 3 boolean checkboxes, and 3 date fields. For each of the selected fields user choose a name.
For example, I collect books. I can choose the additional string field "Author", additional text “Description”, and additional date field “The year of publishing”. 
All selected fields will render on the item page.

All items have tags (user can input several tags; there is support for [autocomplete](https://www.jqueryscript.net/form/Tagging-System-Autocomplete-Amsify-Suggestags.html) — when the user input something, he gets a list of tags with matching initial letters from those already in the database). Also, items must have an image (uploaded by the user to the [cloud](https://cloudinary.com/)).
At the bottom of the item details page, you can find the comments section(when it is opened by any user).
Comments are updated in real-time — when a page is opened and someone adds a comment, it appears immediately. Comments are implemented with [SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-6.0).
It is possible to like an item(the user can set only one like for each item). Implemented with [AJAX](https://www.w3schools.com/xml/ajax_intro.asp).
The site supports two visual themes: light and dark (the user chooses and the choice is saved). It is also implemented using [AJAX](https://www.w3schools.com/xml/ajax_intro.asp).

#### At main page:
* 5 newly created Collections.
* Newly created Items.
* [Tag cloud](https://www.amcharts.com/demos-v4/tag-cloud-v4/) (when a user clicks on a tag, a list of items is displayed).

### What next?
* Full-text search.
* Markdown.
* Authentication via social networks.
* More code refactoring.
* Tests.
