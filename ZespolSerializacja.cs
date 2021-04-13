using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ZespolLib
{
    public partial class Zespol
    {
        public object OdczytajBin(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open);
            Zespol zespol = (Zespol) formatter.Deserialize(stream);
            stream.Close();
            return zespol;
        }

        public void ZapiszBin(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, this);
            stream.Flush();
            stream.Close();
        }
        
        public object OdczytajXML(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            Stream stream = new FileStream(path, FileMode.Open);
            Zespol zespol = (Zespol) serializer.Deserialize(stream);
            stream.Close();
            return zespol;
        }

        public void ZapiszXML(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            Stream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, this);
            stream.Flush();
            stream.Close();
        }
        
        public object OdczytajJSON(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            StreamReader sr = File.OpenText(path);
            Zespol zespol = (Zespol) JsonSerializer.Deserialize<Zespol>(sr.ReadToEnd());
            sr.Close();
            return zespol;
        }

        public void ZapiszJSON(string sciezka)
        {
            var path = Path.GetFullPath(sciezka);
            StreamWriter sw = File.CreateText(path);
            string output = JsonSerializer.Serialize<Zespol>(this);
            sw.Write(output);
            sw.Flush();
            sw.Close();
        }
        
        public object OdczytajYaml(string sciezka)
        {
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