using System;
using System.Diagnostics;
using System.IO;

namespace ZespolLib.Interfejsy
{
    public interface IZapisywalne<T>
    {
        void ZapiszBin(string sciezka);
        T OdczytajBin(string sciezka);
        
        void ZapiszXML(string sciezka);
        T OdczytajXML(string sciezka);
        
        void ZapiszJSON(string sciezka);
        T OdczytajJSON(string sciezka);
        
        void ZapiszYaml(string sciezka);
        T OdczytajYaml(string sciezka);
    }
}