using BookShopSystem.Data;
using BookShopSytem.Models;

namespace BookShopSystem.Service
{
    public abstract class Service
    {
        public BookShopContext Contex { get; }

        public Service()
        {
            this.Contex = new BookShopContext();
        }
    }
}