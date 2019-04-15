using System;
using System.Collections.Generic;
using System.IO;

namespace DerleyiciTeorisi2019
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string kaynakKodu = File.ReadAllText("kaynak.txt");
            Lexer l = new Lexer(kaynakKodu);
            TokenListesi tl = l.TokenListesiAl();
            List<Durum> agac = new Parser(tl).AgacAl();
        }
    }
}
