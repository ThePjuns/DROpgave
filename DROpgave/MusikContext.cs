using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DROpgave
{
    public class MusikContext : DbContext
    {
        public MusikContext(DbContextOptions<MusikContext> options) : base(options)
        {

        }

        public DbSet<ClassLibraryMusik.MusikModel> Musiks { get; set; }

    }
}
