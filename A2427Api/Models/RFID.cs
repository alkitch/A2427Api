using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace A2427Api.Models
{
    public class RFID
    {
        [Key]
        public int RFIDid { get; set; }
        public string RFDidTag { get; set; }
        public string RFDidSectorData { get; set; }
    }
}
