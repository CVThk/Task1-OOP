﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Scores
    {
        public Scores() { }
        public Scores(double diemQuaTrinh, double diemThanhPhan)
        {
            this.DiemQuaTrinh = diemQuaTrinh;
            this.DiemThanhPhan = diemThanhPhan;
        }
        public double DiemQuaTrinh { get; set; }
        public double DiemThanhPhan { get; set; }
    }
}
