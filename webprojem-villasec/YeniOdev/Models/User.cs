using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YeniOdev.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

    
        public DateTime DogumTarihi { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public string Sehir { get; set; }

        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }
    }

    public enum Cinsiyet
    {
        Kadin,
        Erkek
    }
}

