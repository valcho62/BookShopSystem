
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BM;
using BookShopSytem.Models.VM;

namespace BookShopSystem.Service
{
    public class CategoryService :Service
    {
        public ICollection<AllCategoryVM> GetAllCatgories()
        {
            var categories = Contex.Categories.ToList();
            var model = Mapper.Map<ICollection<AllCategoryVM>>(categories);
            return model;
        }

        public AllCategoryVM GetCatById(int id)
        {
            var cat = Contex.Categories.Find(id);
            if (cat == null)
            {
                return null;
            }
            var model = Mapper.Map<AllCategoryVM>(cat);
            return model;
        }

        public string EditCatById(int id, EditCatBM name)
        {
            var cat = Contex.Categories.Find(id);
            if (cat == null || Contex.Categories.Any(x => x.Name == name.Name))
            {
                return null;
            }
            cat.Name = name.Name;
            Contex.Categories.AddOrUpdate(cat);
            Contex.SaveChanges();
            return "ok";
        }

        public string DeleteCat(int id)
        {
            var cat = Contex.Categories.Find(id);
            if (cat == null)
            {
                return null;
            }
            Contex.Categories.Remove(cat);
            Contex.SaveChanges();
            return "ok";
        }

        public string CreateCat(EditCatBM model)
        {
            if (Contex.Categories.Any(x => x.Name == model.Name))
            {
                return null;
            }
            var cat = new Category();
            cat.Name = model.Name;
            Contex.Categories.Add(cat);
            Contex.SaveChanges();
            return "The cat was created";

        }
    }
}
