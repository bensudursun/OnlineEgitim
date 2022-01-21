using OnlineEgitim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEgitim
{
    public class ViewModel
    {
        public List<KullaniciBilgi> KullaniciBilgis { get; set; }
        public List<Kullanici> Kullanicis { get; set; }
    }
}