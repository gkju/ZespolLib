using System;
using System.Diagnostics;
using System.IO;

namespace ZespolLib.Interfejsy
{
    public interface IZapisywalne
    {
        void ZapiszBin(string sciezka);
        Object OdczytajBin(string sciezka);
        
        void ZapiszXML(string sciezka);
        Object OdczytajXML(string sciezka);
        
        void ZapiszJSON(string sciezka);
        Object OdczytajJSON(string sciezka);
        
        void ZapiszYaml(string sciezka);
        Object OdczytajYaml(string sciezka);
    }
}