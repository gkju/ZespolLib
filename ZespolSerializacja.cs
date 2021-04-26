using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ZespolLib
{
    public partial class Zespol
    {
        public static Zespol OdczytajBinStatic(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open);
            Zespol zespol = (Zespol)formatter.Deserialize(stream);
            stream.Close();
            return zespol;
        }

        public Zespol OdczytajBin(string sciezka)
        {
            return OdczytajBinStatic(sciezka);
        }

        public void ZapiszBin(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, this);
            stream.Flush();
            stream.Close();
        }

        public Zespol OdczytajXML(string sciezka)
        {
            return OdczytajXMLStatic(sciezka);
        }

        public static Zespol OdczytajXMLStatic(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            Stream stream = new FileStream(path, FileMode.Open);
            Zespol zespol = (Zespol) serializer.Deserialize(stream);
            stream.Close();
            return zespol;
        }

        public void ZapiszXML(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            Stream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Flush();
            stream.Close();
        }

        public Zespol OdczytajJSON(string sciezka)
        {
            return OdczytajJSONStatic(sciezka);
        }
        
        public static Zespol OdczytajJSONStatic(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            StreamReader sr = File.OpenText(path);
            Zespol zespol = JsonSerializer.Deserialize<Zespol>(sr.ReadToEnd());
            sr.Close();
            return zespol;
        }

        public void ZapiszJSON(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var path = Path.GetFullPath(sciezka);
            StreamWriter sw = File.CreateText(path);
            string output = JsonSerializer.Serialize<Zespol>(this);
            sw.Write(output);
            sw.Flush();
            sw.Close();
        }

        public Zespol OdczytajYaml(string sciezka)
        {
            return OdczytajYamlStatic(sciezka);
        }
        
        public static Zespol OdczytajYamlStatic(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new PascalCaseNamingConvention())
                .Build();
            var path = Path.GetFullPath(sciezka);
            StreamReader sr = File.OpenText(path);
            Zespol zespol = deserializer.Deserialize<Zespol>(sr.ReadToEnd());
            sr.Close();
            return zespol;
        }

        public void ZapiszYaml(string sciezka)
        {
            sciezka = Regex.Unescape(sciezka);
            var serializer = new SerializerBuilder()
                .WithNamingConvention(new PascalCaseNamingConvention())
                .Build();
            var path = Path.GetFullPath(sciezka);
            StreamWriter sw = File.CreateText(path);
            string output = serializer.Serialize(this);
            sw.Write(output);
            sw.Flush();
            sw.Close();
        }
    }
}