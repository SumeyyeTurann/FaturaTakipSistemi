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
    
    public partial class Telefon
    {
        public int ID { get; set; }
        public string GSMType { get; set; }
        public string DataMB { get; set; }
        public int Sms { get; set; }
        public int InternetGB { get; set; }
        public int SesDK { get; set; }
        public System.DateTime tarih { get; set; }
        public System.DateTime sontarih { get; set; }
        public decimal tutar { get; set; }
        public bool odendi { get; set; }
        public bool Sabit { get; set; }
        public string HizmetMiktarı { get; set; }
        public string HizmetType { get; set; }
        public string TelefonId { get; set; }
        public Nullable<int> AboneID { get; set; }
    
        public virtual Abone Abone { get; set; }
        public virtual Hizmet Hizmet { get; set; }
        public virtual kullanici kullanici { get; set; }
    }
}