
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BM;
using BookShopSytem.Models.VM;

namespace BookShopSystem.Service
{
    public class AuthorService :Service
    {
        public AuthorVM GetAuthorById(int id)
        {
            var author = this.Contex.Authors.Find(id);
            var authorView = Mapper.Map<AuthorVM>(author);
            return authorView;
        }

        public void AddAuthor(AddAuthorBM model)
        {
            var author = Mapper.Map<Author>(model);
            Contex.Authors.Add(author);
            Contex.SaveChanges();
        }

        public ICollection<AuthorBooksVM> GetAuthorsBooks(int id)
        {
            var books = Contex.Authors.Find(id).Books;
            var model = Mapper.Map<ICollection<AuthorBooksVM>>(books);
            return model;
        }
    }
}
