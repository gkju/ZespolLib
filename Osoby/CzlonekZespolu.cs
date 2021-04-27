using System;
using System.Globalization;

namespace ZespolLib
{
    [Serializable]
    public class CzlonekZespolu : Osoba
    {
        public DateTime DataZapisu { get; set; }
        public string Funkcja { get; set; }

        public CzlonekZespolu()
        {
            
        }

        public CzlonekZespolu(string imie = "", string nazwisko = "", string dataUrodzenia = "",
            string pesel = "00000000000", Plcie plec = Plcie.K, string funkcja = "", Zespol zespolCzlonka = null,
            DateTime podanaDataZapisu = default) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            Funkcja = funkcja;
            DataZapisu = podanaDataZapisu;

            if (zespolCzlonka != null)
            {
                zespolCzlonka.DodajCzlonka(this);
            }
        }
        
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {(Plec == Plcie.K ? "K" : "M")}, PESEL {PESEL}, wiek {Convert.ToString(this.Wiek())} lat, {Funkcja}, data zapisu {DataZapisu.ToString()}";
        }

        public CzlonekZespolu Copy()
        {
            return (CzlonekZespolu)MemberwiseClone();
        }
    }
}