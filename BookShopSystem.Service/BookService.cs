
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BM;
using BookShopSytem.Models.VM;

namespace BookShopSystem.Service
{
    public class BookService :Service
    {
        public BookDetailsVM GetBookById(int id)
        {
            var book = Contex.Books.Find(id);
            var model = Mapper.Map<BookDetailsVM>(book);
            return model;
        }

        public ICollection<SearchBookVM> GetTopBooks(string word)
        {
            var books = Contex.Books.Where(x => x.Title.Contains(word)).OrderBy(t => t.Title)
                .Take(10).ToList();
            var model = Mapper.Map<ICollection<SearchBookVM>>(books);
            return model;
        }

        public void EditBookById(int id,EditBookBM model)
        {
            var book = Contex.Books.Find(id);
            book.Title = model.Title;
            book.Description = model.Description;
            book.Price = model.Price;
            Contex.Books.AddOrUpdate(book);
            Contex.SaveChanges();

        }

        public void DeleteBookById(int id)
        {
            var book = Contex.Books.Find(id);
            Contex.Books.Remove(book);
            Contex.SaveChanges();
        }

        public void CreateBook(CreateBookBM model)
        {
           var book = new Book();
            book.Title = model.Title;
            book.Description = model.Description;
            var cat = model.Categories.Split(' ');
            foreach (var cate in cat)
            {
                if (Contex.Categories.Any(name => name.Name == cate))
                {
                    book.Categories.Add(Contex.Categories.FirstOrDefault(x => x.Name == cate));
                }
            }
            book.ReleaseDate =DateTime.Now;
            Contex.Books.Add(book);
            Contex.SaveChanges();
        }
    }
}
