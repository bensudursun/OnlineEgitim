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
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.Yetki = new HashSet<Yetki>();
        }
    
        public int KullaniciId { get; set; }
        public string Kullaniciadi { get; set; }
        public string Sifre { get; set; }
        public Nullable<int> YetkiTurId { get; set; }
        public Nullable<int> EgitmenId { get; set; }
        public Nullable<int> OgrenciId { get; set; }
        public Nullable<int> AdminId { get; set; }
    
        public virtual YetkiTur YetkiTur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yetki> Yetki { get; set; }
    }
}
