using System.ComponentModel.DataAnnotations;

namespace BookShopSytem.Models.BM
{
    public class AddAuthorBM
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}