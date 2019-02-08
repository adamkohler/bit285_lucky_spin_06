using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckySpin.ViewModels
{
    public class Spin_ViewModel
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int Luck { get; set; }
        public bool IsWinning { get; set; }
        public string playerNAme { get; set; }
        public decimal balance { get; set; }
        
    }
}
