using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Subject
    {
        public Subject() { }

        public Subject(string tenMonHoc, int soTiet, double tyLeQuaTrinh, double tyLeThanhPhan)
        {
            this.TenMonHoc = tenMonHoc;
            this.SoTiet = soTiet;
            this.TyLeQT = tyLeQuaTrinh;
            this.TyLeTP = tyLeThanhPhan;
        }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }
        public double TyLeQT { get; set; }
        public double TyLeTP { get; set; }
    }
}
