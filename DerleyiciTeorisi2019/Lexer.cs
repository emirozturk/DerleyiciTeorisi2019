using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DerleyiciTeorisi2019
{
    public class Lexer
    {
        private string kaynakKodu { get; set; }
        private Dictionary<TokenTuru, string> tokenTanimlari;
        private Dictionary<TokenTuru, MatchCollection> tokenSozlugu;
        int sayac=0;
        public Lexer(string kaynakKodu)
        {
            this.kaynakKodu = kaynakKodu;
            TokenTanimlariDoldur();
            TokenSozluguOlustur();
        }

        private void TokenSozluguOlustur()
        {
            tokenSozlugu = new Dictionary<TokenTuru, MatchCollection>();
            foreach (KeyValuePair<TokenTuru, string> tokenTuru in tokenTanimlari)
                tokenSozlugu.Add(tokenTuru.Key, Regex.Matches(kaynakKodu, tokenTuru.Value));
        }

        private void TokenTanimlariDoldur()
        {
            tokenTanimlari = new Dictionary<TokenTuru, string>();
            tokenTanimlari.Add(TokenTuru.Fonk, "Fonk");
            tokenTanimlari.Add(TokenTuru.ParantezAc, "\\(");
            tokenTanimlari.Add(TokenTuru.ParantezKapat, "\\)");
            tokenTanimlari.Add(TokenTuru.Esittir, "\\=");
            tokenTanimlari.Add(TokenTuru.TamSayi, "[0-9]+");
            tokenTanimlari.Add(TokenTuru.Arti, "\\+");
            tokenTanimlari.Add(TokenTuru.Bosluk, "[ \t]+");
            tokenTanimlari.Add(TokenTuru.YeniSatir, "(\n|\r\n)+");
            tokenTanimlari.Add(TokenTuru.Tanim, "[a-zA-Z]+[a-z-A-Z0-9]*");
        }
        public Token TokenAl()
        {
            foreach(var ikili in tokenSozlugu)
                foreach(Match m in ikili.Value)
                    if(sayac == m.Index)
                    { 
                        sayac += m.Length;
                        return new Token(ikili.Key, m.Value);
                    }
            return new Token(TokenTuru.Tanimsiz, "");
        }
        public TokenListesi TokenListesiAl()
        {
            List<Token> tokenListesi = new List<Token>();
            Token t = null;
            do
            {
                t = TokenAl();
                if(t.Tur != TokenTuru.Bosluk && t.Tur != TokenTuru.YeniSatir)
                    tokenListesi.Add(t);
            } while (t.Tur != TokenTuru.Tanimsiz);
            tokenListesi.Add(new Token(TokenTuru.Tanimsiz, ""));
            return new TokenListesi(tokenListesi);
        }
    }
}
