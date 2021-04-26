using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZespolLib
{
    public class ZespolCluster
    {
        [Key]
        public string Nazwa { get; set; }

        public List<ZespolArchive> ZespolHistory { get; set; } = new List<ZespolArchive>();

        private Zespol _Zespol { get; set; }
        public Zespol Zespol
        {
            get
            {
                return _Zespol;
            }
            set
            {
                ZespolHistory.Add(new ZespolArchive(value));
                _Zespol = value;
            }
        }

        public class ZespolArchive
        {
            [Key]
            public string Id { get; set; }

            public readonly Zespol Zespol;
            public readonly DateTime DataZapisu;

            public ZespolArchive()
            {
                Id = Guid.NewGuid().ToString();
            }

            public ZespolArchive(Zespol Zespol) : this()
            {
                DataZapisu = DateTime.Now;
                this.Zespol = Zespol;
            }
        }
    }
}
