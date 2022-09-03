using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Result
    {
        public Subject MonHoc { get; set; }
        public Scores DiemMonHoc { get; set; }
        public Result() { }
        public Result(Subject monHoc, Scores diem)
        {
            this.MonHoc = monHoc;
            this.DiemMonHoc = diem;
        }
        public string danhGia()
        {
            if (DiemMonHoc.DiemQuaTrinh == -1 || DiemMonHoc.DiemThanhPhan == -1)
                return "";
            if (DiemMonHoc.DiemQuaTrinh * MonHoc.TyLeQT + DiemMonHoc.DiemThanhPhan * MonHoc.TyLeTP >= 4)
                return "Đỗ";
            return "Rớt";
        }
    }
}
