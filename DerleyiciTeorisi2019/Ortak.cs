using System;
using System.Collections.Generic;

namespace DerleyiciTeorisi2019
{
    public enum TokenTuru
    {
        Tanim = 1,
        Fonk = 2,
        ParantezAc = 3,
        ParantezKapat = 4,
        Esittir = 5,
        TamSayi = 6,
        Arti = 7,
        Bosluk = 8,
        YeniSatir = 9,
        Tanimsiz = 10
    }
    public class Token
    {
        public TokenTuru Tur { get; set; }
        public string Deger { get; set; }
        public Token(TokenTuru Tur,string Deger)
        {
            this.Tur = Tur;
            this.Deger = Deger;
        }
    }
    public class TokenListesi 
    {
        private List<Token> tokenListesi = new List<Token>();
        int sayac = 0;
        public TokenListesi(List<Token> tokenListesi)
        {
            this.tokenListesi = tokenListesi;
        }
        public Token TokenAl()
        {
            return tokenListesi[sayac++];
        }
        public Token Gozat()
        {
            return tokenListesi[sayac];
        }
        public void IleriGit()
        {
            sayac++;
        }
        public void GeriGit()
        {
            sayac--;
        }
    }
}
