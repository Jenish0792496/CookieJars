using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MvcCookieJars.Models
{
    public class CookieGenereViewModel
    {
        public List<Cookie> CookieName { get; set; }
        public SelectList MainIngredents { get; set; }
        public string Ingridients { get; set; }
        public string SearchString { get; set; }
    }
}
