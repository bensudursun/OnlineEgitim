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
    
    public partial class EgitimVeren
    {
        public int egitimVerenId { get; set; }
        public string Adi { get; set; }
        public string Email { get; set; }
        public string EgitimDurumu { get; set; }
        public string il { get; set; }
        public string Universite { get; set; }
        public string Hakkimda { get; set; }
        public Nullable<int> kullaniciid { get; set; }
        public string Soyad { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
    }
}