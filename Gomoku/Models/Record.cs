using System;
using System.Collections.Generic;

namespace Gomoku.Models
{
    public class Record
    {
        public bool Sente { set; get; }
        public List<int[]> Records { set; get; }
        public int[] Black { set; get; }
        public int[] White { set; get; }

        public Record(bool Sente)
        {
            this.Sente = Sente;
            this.Records = new List<int[]>();
        }
    }
}
