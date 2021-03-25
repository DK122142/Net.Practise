using System.Collections.Generic;

namespace PhoneBook.ViewModels
{
    public class PaginationViewModel<TModel> where TModel : class
    {
        public IEnumerable<TModel> Models { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
