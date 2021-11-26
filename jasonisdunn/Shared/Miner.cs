using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboard.Shared
{
    public class Miner
    {
        [Key]
        public int _worker { get; set; }

        public string? _name { get; set; }

        public Int64? _total { get; set; }

        public int? _payload { get; set; }

        public byte? _rank { get; set; }

    }
}
