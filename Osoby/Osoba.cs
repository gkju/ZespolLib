using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace ZespolLib
{
    [Serializable]
    public abstract class Osoba :ICloneable, IComparable<Osoba>, IEquatable<Osoba>
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        [XmlAttribute]
        public string PESEL { get; set; }
        public Plcie Plec { get; set; }
        
        public Osoba()
        {
            
        }
        
        public Osoba(string imie = "", string nazwisko = "", string dataUrodzenia = "", string pesel = "00000000000", Plcie plec = Plcie.K)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            PESEL = pesel;
            DateTime output;
            DateTime.TryParseExact(dataUrodzenia, new [] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd.mm.yyyy" }, null, DateTimeStyles.None, out output);
            DataUrodzenia = output;
            Plec = plec;
        }

        public int Wiek()
        {
            return DateTime.Now.Year - DataUrodzenia.Year;
        }
        
        public override string ToString()
        {
            return $"PESEL {PESEL} Imię {Imie} Naziwsko {Nazwisko} ({Convert.ToString(this.Wiek())})";
        }
        
        public object Clone()
        {
            return MemberwiseClone();
        }
        
        public int CompareTo(Osoba inna)
        {
            return string.Compare(Nazwisko + Imie, inna.Nazwisko + inna.Imie, StringComparison.CurrentCultureIgnoreCase);
        }
        
        public static int PeselComparer(Osoba a, Osoba b)
        {
            return string.Compare(a.PESEL, b.PESEL, StringComparison.Ordinal);
        }
        
        public bool Equals(Osoba other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            
            return other.PESEL == PESEL;
        }
    }
}