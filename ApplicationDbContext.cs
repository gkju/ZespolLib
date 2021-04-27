using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZespolLib
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ZespolCluster> ZespolClusters { get; set; }
        public DbSet<Zespol> Zespoly { get; set; }
        public DbSet<CzlonekZespolu> CzlonkowieZespolow { get; set; }
        public DbSet<KierownikZespolu> KierownicyZespolow { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
