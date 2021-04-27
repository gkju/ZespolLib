using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ZespolLib.Interfejsy;

namespace ZespolLib
{
    [Serializable]
    public partial class Zespol : IZapisywalne<Zespol>
    {
        [Key]
        public string Id { get; set; }

        public string Nazwa { get; set; }

        [NotMapped]
        [YamlIgnore]
        public int LiczbaCzlonkow
        {
            get
            {
                return Czlonkowie.Count;
            }
        }

        public KierownikZespolu Kierownik { get; set; }
        public List<CzlonekZespolu> Czlonkowie { get; set; } = new List<CzlonekZespolu>();
        
        public Zespol()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Zespol(string PodanaNazwa = "", KierownikZespolu PodanyKierownik = null) : this()
        {
            Nazwa = PodanaNazwa;
            Kierownik = PodanyKierownik;
        }
        
        public Zespol(string PodanaNazwa = "", KierownikZespolu PodanyKierownik = null, params Zespol[] Zespoly) : this()
        {
            Nazwa = PodanaNazwa;
            Kierownik = PodanyKierownik;
            foreach(var zespol in Zespoly)
            {
                foreach (var czlonek in zespol.Czlonkowie)
                {
                    Czlonkowie.Add(czlonek);
                }
            }
        }

        public void DodajCzlonka(CzlonekZespolu NowyCzlonek)
        {
            Czlonkowie.Add(NowyCzlonek);
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Nazwa}\n");
            sb.Append(
                $"Kierownik: {Kierownik.Imie} {Kierownik.Nazwisko} ({Convert.ToString(Kierownik.Wiek())}, {Convert.ToString(Kierownik.Doswiadczenie)} lat doświadczenia)");
            foreach(CzlonekZespolu czlonek in Czlonkowie)
            {
                sb.Append(
                    $"\n    Czlonek: {czlonek.Imie} {czlonek.Nazwisko} ({Convert.ToString(czlonek.Wiek())}) -  {czlonek.Funkcja}");
            }
            return sb.ToString();
        }

        public bool JestCzlonkiem(CzlonekZespolu czlonek)
        {
            return Czlonkowie.Contains(czlonek);
        }

        public bool JestCzlonkiem(string PESEL)
        {
            return Czlonkowie.Any(czlonek => czlonek.PESEL == PESEL);
        }
        
        public bool JestCzlonkiem(string Imie, string Nazwisko)
        {
            return Czlonkowie.Any(czlonek => czlonek.Imie == Imie && czlonek.Nazwisko == Nazwisko);
        }

        public void UsunCzlonka(string PESEL)
        {
            Czlonkowie = Czlonkowie.FindAll(czlonek => czlonek.PESEL != PESEL);
        }
        
        public void UsunCzlonka(string Imie, string Nazwisko)
        {
            Czlonkowie = Czlonkowie.FindAll(czlonek => czlonek.Imie != Imie || czlonek.Nazwisko != Nazwisko);
        }

        public void UsunWszystkich()
        {
            Czlonkowie.Clear();
        }

        public List<CzlonekZespolu> WyszukajCzlonkow(string funkcja)
        {
            return Czlonkowie.FindAll(czlonek => czlonek.Funkcja == funkcja);
        }
        
        public List<CzlonekZespolu> WyszukajCzlonkow(int miesiac)
        {
            return Czlonkowie.FindAll(czlonek => czlonek.DataZapisu.Month == miesiac);
        }

        public void Sortuj()
        {
            Czlonkowie.Sort();
        }

        public void SortujPoPesel()
        {
            Czlonkowie.Sort(Osoba.PeselComparer);
        }
    }
}