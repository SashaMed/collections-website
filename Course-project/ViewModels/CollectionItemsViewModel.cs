using Course_project.Models;

namespace Course_project.ViewModels
{
    public class CollectionItemsViewModel
    {
        public List<Item> Items { get; set; }

        public Collection ThisCollection { get; set; }

        public CollectionItemsViewModel(List<Item> items, Collection collection)
        {
            Items = items;
            ThisCollection = collection;
        }
    }
}
