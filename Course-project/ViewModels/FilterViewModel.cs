using Microsoft.AspNetCore.Mvc.Rendering;
using Course_project.Models;
using Course_project.Models.Enums;

namespace Course_project.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Collection> companies, CollectionType? company, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            //companies.Insert(0, new Collection { Name = "All", Id = 0 });
            Companies = new SelectList(companies, "Id", "Name", company);
            SelectedCompany = ((int?)company);
            SelectedName = name;
        }
        public SelectList Companies { get; private set; } // список компаний
        public int? SelectedCompany { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}
