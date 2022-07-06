using Course_project.Models;

namespace Course_project.ViewModels
{
    public class IndexItemViewModel
    {
        public List<Item> Items { get; set; }

        public IndexItemViewModel(List<Item> items)
        {
            Items = items;
        }
    }
}
