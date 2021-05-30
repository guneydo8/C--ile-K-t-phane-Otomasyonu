using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Models.Sınıf
{
    public class Class1
    {
        public IEnumerable<TblKitaplar> ktk { get; set; }
        public IEnumerable<TblHakkımızda> hk { get; set; }
    }
}