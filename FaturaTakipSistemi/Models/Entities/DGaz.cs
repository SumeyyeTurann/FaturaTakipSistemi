//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FaturaTakipSistemi.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DGaz
    {
        public int ID { get; set; }
        public string dagitimfirmasi { get; set; }
        public System.DateTime tarih { get; set; }
        public System.DateTime sontarih { get; set; }
        public decimal tutar { get; set; }
        public bool odendi { get; set; }
        public string HizmetMiktari { get; set; }
        public string DGazId { get; set; }
        public string HizmetType { get; set; }
        public Nullable<int> AboneID { get; set; }
    
        public virtual Abone Abone { get; set; }
        public virtual Hizmet Hizmet { get; set; }
        public virtual kullanici kullanici { get; set; }
    }
}
