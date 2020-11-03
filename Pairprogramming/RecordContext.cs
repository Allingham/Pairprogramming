using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLib;

namespace Pairprogramming
{
    public class RecordContext : DbContext
    {
        // her laver vi en context til vores inMemory "database" så man kan få fat på dataen
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {

        }

        //her laver vi et entityframework set - vi får adgang til vores liste af records
        public DbSet<Record> Records { get; set; }

    }
}
