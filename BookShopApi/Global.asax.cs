using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BookShopSytem.Models;
using BookShopSytem.Models.BM;
using BookShopSytem.Models.VM;

namespace BookShopApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitilizeMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.Indent = true;
        }

        private void InitilizeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorVM>()
                .ForMember(m => m.BookTitles, f => f.MapFrom(bt => bt.Books.Select(x => x.Title)));
                cfg.CreateMap<AddAuthorBM, Author>();
                cfg.CreateMap<Book,AuthorBooksVM>()
                .ForMember(m => m.CategoriesName,s => s.MapFrom(bt => bt.Categories.Select(x => x.Name)));
                cfg.CreateMap<Book, BookDetailsVM>()
               .ForMember(m => m.CategoriesName, s => s.MapFrom(bt => bt.Categories.Select(x => x.Name)))
               .ForMember(m => m.AuthorName, s => s.MapFrom(bt => bt.Author.FirstName + " " + bt.Author.LastName));
                cfg.CreateMap<Book, SearchBookVM>();
                cfg.CreateMap<Category, AllCategoryVM>();


            });
        }
    }
}
