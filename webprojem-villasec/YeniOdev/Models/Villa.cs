using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YeniOdev.Models
{
    public class Villa
    {
        public int Id { set; get; }

        public string VillaAd { set; get; }

        public int KategoriId { set; get; } //fk

        public int AdresId { get; set; } //fk

        public int BolgeId { get; set; } //fk

        public Bolge Bolge { get; set; }

        public double? Fiyat { set; get; }

        public double? Metrekare { set; get; }

        public int? Kapasite { set; get; }

        public string Fotograf { set; get; }

        public Kategori Kategori { set; get; }

        public Adres Adres { get; set; }


        public string Aciklama { get; set; }

    }
}
