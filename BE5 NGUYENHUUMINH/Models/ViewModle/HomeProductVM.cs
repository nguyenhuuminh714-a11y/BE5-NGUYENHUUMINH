using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
namespace BE5_NGUYENHUUMINH.Models.ViewModle
{
    public class HomeProductVM
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSite { get; set; } = 10;
        public List<Product> FeaturedProduct { get; set;}
        public PagedList.IPagedList<Product> NewProduct { get; set; }
    }
}