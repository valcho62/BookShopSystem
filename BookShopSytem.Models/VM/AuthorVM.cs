
using System.Collections.Generic;

namespace BookShopSytem.Models.VM
{
    public class AuthorVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public  ICollection<string> BookTitles { get; set; }
    }
}
