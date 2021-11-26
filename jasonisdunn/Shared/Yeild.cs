using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboard.Shared
{
    public class Yeild 
    {
        [Key]
        public int? _worker { get; set; }
        public string? _value { get; set; }
        public string? _datetime { get; set; }
        public int? _status { get; set; }
    }
}
