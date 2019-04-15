using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerleyiciTeorisi2019
{
    class Durum { }
    class Ifade { }
    class Blok : Durum
    {
        public List<Durum> durumListesi { get; set; }
        public Blok()
        {
            durumListesi = new List<Durum>();
        }
    }
    class Fonksiyon : Blok
    {
        string ad;
        List<string> parametreler;
        public Fonksiyon(string ad, List<string> parametreler)
        {
            this.ad = ad;
            this.parametreler = parametreler;
        }
    }
    class Atama : Durum
    {
        string ad;
        Ifade deger;
        public Atama(string ad, Ifade deger)
        {
            this.ad = ad;
            this.deger = deger;
        }
    }
    class Cagirma : Durum
    {
        string ad;
        List<Ifade> parametreler;
        public Cagirma(string ad, List<Ifade> parametreler)
        {
            this.ad = ad;
            this.parametreler = parametreler;
        }
    }
    class Tamsayi : Ifade
    {
        int deger;
        public Tamsayi(int deger)
        {
            this.deger = deger;
        }
    }
    class Tanim : Ifade
    {
        string deger;
        public Tanim(string deger)
        {
            this.deger = deger;
        }
    }
    class MatematikIfadesi : Ifade
    {
        Ifade solIfade;
        TokenTuru islem;
        Ifade sagIfade;
        public MatematikIfadesi(Ifade solIfade, TokenTuru islem, Ifade sagIfade)
        {
            this.solIfade = solIfade;
            this.islem = islem;
            this.sagIfade = sagIfade;
        }
    }
}
