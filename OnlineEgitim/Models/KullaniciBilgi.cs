//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineEgitim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KullaniciBilgi
    {
        public int kullanicibilgiid { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string email { get; set; }
        public Nullable<int> telefon { get; set; }
        public Nullable<System.DateTime> dogumtarihi { get; set; }
        public string linkednprof { get; set; }
        public Nullable<int> kullaniciid { get; set; }
        public string yetkiturad { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
    }
}
