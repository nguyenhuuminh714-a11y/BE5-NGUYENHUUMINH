using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
namespace BE5_NGUYENHUUMINH.Models.ViewModle
{
    public class ProductDetailsVM
    {
        public Product product { get; set; }
        public int quantity { get; set; }
        public decimal estimatedValue { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public PagedList.IPagedList<Product> TopProducts { get; set; }
    }
}