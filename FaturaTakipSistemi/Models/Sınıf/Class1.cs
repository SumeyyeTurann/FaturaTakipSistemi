using FaturaTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaturaTakipSistemi.Models.Sınıf
{
    public class Class1
    {
        public IEnumerable<kullanici> kullanici { get; set; }
        public IEnumerable<Elektrik> elektrik { get; set; }
        public IEnumerable<Internet> internet { get; set; }
        public IEnumerable<Su> su { get; set; }
        public IEnumerable<Telefon> telefon { get; set; }
        public IEnumerable<DGaz> dgaz { get; set; }
    }
}