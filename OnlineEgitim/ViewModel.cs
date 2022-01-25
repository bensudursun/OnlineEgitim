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
        public List<Kategori> Kategoris { get; set; }
        public List<Yetki> Yetkis { get; set; }
        public List<YetkiTur> YetkiTurs { get; set; }
        public List<EgitimVeren> EgitimVerens { get; set; }
        public List<Egitim> Egitims { get; set; }
        public List<Kurs> Kurss { get; set; }
        public List<KursLink> KursLinks { get; set; }
        public List<Yorum> Yorums { get; set; }
    }
}