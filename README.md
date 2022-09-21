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
Unauthenticated users have read only rights (they can not create collections and items, comment and rate items).
Authenticated not-admin users have rights to create, update, delete their collections and items, comment and rate items.

Admin users can control others users — block, unblock, delete, give or take admin rights.
Admin sees all pages like their author (for example, admin can open collection of any other user and add item to it; 
in fact, admins are owners of all items and collections).
Only admin or owner of collections or items can manipulate them (edit, add, delete), but all users can read everysing (exсept admin page).

Users can register and login. 
All authenticated users have personal page, where user can manage their collections (create, delete, edit) — each collection is a link to collection page,
which contains items table with possibility to create new items, delete or edit existing.
Each collection have name, description, type (one value from a fixed reference, for example, “Books”, “Photos”, “Paintings”).
Additionally collection allows to choose fields, thats items will inherit from this collection. At the collection level, you can select any set from the following available fields:
3 integer fields, 3 string fields, 3 multiline text fields, 
3 boolean checkboxes, 3 date fields. For each of selected fields user choose name.
For example, i am collecte books. I can choose additional string field "Author", additional text “Description”, additional date “The year of publishing”. 
All selected fields must render on item page.

All items have tags (user can input several tags; there is support for [autocomplete](https://www.jqueryscript.net/form/Tagging-System-Autocomplete-Amsify-Suggestags.html) — when user input something, 
he gets list of tags with matching initial letters from those already in the database). Also items must have an image (thats uploads to [cloud](https://cloudinary.com/).
There are comments at the bottom of the item details page (when it is opened by any user).
Comments are updated in real time — when page is opened and someone add a comment, it appears instantly. 
Comments are implemented with [SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-6.0).
Each item have likes (one from user for each item). Implemented with [AJAX](https://www.w3schools.com/xml/ajax_intro.asp) requests.
The site supports two visual themes: light and dark (the user chooses and the choice is saved). It is also implemented using [AJAX](https://www.w3schools.com/xml/ajax_intro.asp).

#### At main page:
* 5 newly created Collections
* Newly created Items
* [Tag cloud](https://www.amcharts.com/demos-v4/tag-cloud-v4/) (when a user clicks on a tag, a list of items is displayed).

### What next?
* Full text search.
* Markdown.
* Аутентификация через социальные сети?
* More code refactoring.
* Tests
