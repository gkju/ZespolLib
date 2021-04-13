using System;

namespace ZespolLib
{
    [Serializable]
    public class KierownikZespolu : Osoba
    {
        public int Doswiadczenie { get; set; }

        public KierownikZespolu()
        {
            
        }
        
        public KierownikZespolu(string imie = "", string nazwisko = "", string dataUrodzenia = "", string pesel = "00000000000", Plcie plec = Plcie.K, int doswiadczenie = 0) : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            Doswiadczenie = doswiadczenie;
        }
        
        public override string ToString()
        {
            return $"Kierownik zespołu {Imie} {Nazwisko} {(Plec == Plcie.K ? "K" : "M")}, PESEL {PESEL}, wiek {Convert.ToString(this.Wiek())} lat, {Doswiadczenie.ToString()} lat doświadczenia";
        }
    }
}