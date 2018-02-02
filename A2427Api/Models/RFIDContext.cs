using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2427Api.Models
{
    public class RFIDContext: DbContext
    {
        public RFIDContext(DbContextOptions<RFIDContext> options)
            : base(options)
        {
        }

        public DbSet<RFID> Rfids { get; set; }

    }

}
