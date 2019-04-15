using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerleyiciTeorisi2019
{
    class Parser
    {
        private TokenListesi tl;
        Blok suAnkiBlok = null;
        Stack<Blok> blokStack = new Stack<Blok>();
        List<Durum> agac = new List<Durum>();
        List<string> eklentiler = new List<string>();
        public Parser(TokenListesi tl)
        {
            this.tl = tl;
            parseEt();
        }

        private void parseEt()
        {
            while (true)
            {
                Token t = tl.TokenAl();
                if (t == null) break;
                if (t.Tur == TokenTuru.Fonk)
                {
                    suAnkiBlok = fonksiyonParseEt();
                }
                else if (t.Tur == TokenTuru.Tanim)
                {
                    if (tl.Gozat().Tur == TokenTuru.Esittir)
                    {
                        tl.GeriGit();
                        Atama a = atamaParseEt();
                        suAnkiBlok.durumListesi.Add(a);
                    }
                    else if (tl.Gozat().Tur == TokenTuru.ParantezAc)
                    {
                        tl.GeriGit();
                        Cagirma c = cagirmaParseEt();
                        suAnkiBlok.durumListesi.Add(c);
                    }
                }
            }
        }

        private Cagirma cagirmaParseEt()
        {
            string ad = tl.TokenAl().Deger;
            tl.IleriGit();
            List<Ifade> argumanlar = new List<Ifade>();
            if (tl.Gozat().Tur == TokenTuru.ParantezKapat)
                argumanlar = argumanParseEt();
            return new Cagirma(ad, argumanlar);
        }

        private List<Ifade> argumanParseEt()
        {
            List<Ifade> argumanlar = new List<Ifade>();
            while (true)
            {
                argumanlar.Add(ifadeParseEt());
                if (tl.Gozat().Tur == TokenTuru.ParantezKapat)
                {
                    tl.IleriGit();
                    break;
                }
            }
            return argumanlar;
        }

        private Atama atamaParseEt()
        {
            string ad = tl.TokenAl().Deger;
            tl.IleriGit();
            Ifade ifade = ifadeParseEt();
            return new Atama(ad, ifade);
        }

        private Ifade ifadeParseEt()
        {
            Ifade donus = null;
            Token t = tl.TokenAl();
            if (t.Tur == TokenTuru.TamSayi)
                donus = new Tamsayi(Convert.ToInt32(t.Deger));
            else if (t.Tur == TokenTuru.Tanim)
                donus = new Tanim(t.Deger);
            if (tl.Gozat().Tur == TokenTuru.Arti)
            {
                Ifade solIfade = donus;
                TokenTuru islem = tl.TokenAl().Tur;
                Ifade sagIfade = ifadeParseEt();
                donus = new MatematikIfadesi(solIfade, islem, sagIfade);
            }
            return donus;
        }

        private Fonksiyon fonksiyonParseEt()
        {
            string ad = tl.TokenAl().Deger;
            tl.IleriGit();
            List<string> parametreler = new List<string>();
            if (tl.Gozat().Tur == TokenTuru.ParantezKapat)
                tl.IleriGit();
            else
                parametreler = parametreParseEt();
            return new Fonksiyon(ad, parametreler);
        }

        private List<string> parametreParseEt()
        {
            List<string> parametreler = new List<string>();
            while (true)
            {
                Token t = tl.TokenAl();
                if (t.Tur == TokenTuru.Tanim)
                    parametreler.Add(t.Deger);
                if (tl.Gozat().Tur == TokenTuru.ParantezKapat)
                {
                    tl.IleriGit();
                    break;
                }
            }
            return parametreler;
        }
    }
}
