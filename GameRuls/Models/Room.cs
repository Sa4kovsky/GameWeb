using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameRuls.Models
{
    public class Room
    {
        [Key]
        public string Name { get; set; }
        public int SizePlaingFaild { get; set; }
        public int SizeWin { get; set; }
    }
}
