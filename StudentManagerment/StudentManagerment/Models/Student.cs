using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Student
    {
        public Student() { }
        public Student(string maSV, string tenSV, string gioiTinh, string lop, DateTime ngaySinh, DateTime ngayVaoTruong, string khoa, string trangThai, string bacDaoTao, string sdt, string cmnd, string diaChiThuongTru, string danToc, string tonGiao)
        {
            this.MaSinhVien = maSV;
            this.Ten = tenSV;
            this.GioiTinh = gioiTinh;
            this.Lop = lop;
            this.NgaySinh = ngaySinh;
            this.NgayVaoTruong = ngayVaoTruong;
            this.Khoa = khoa;
            this.TrangThai = trangThai;
            this.BacDaoTao = bacDaoTao;
            this.SDT = sdt;
            this.CMND = cmnd;
            this.DiaChiTT = diaChiThuongTru;
            this.DanToc = danToc;
            this.TonGiao = tonGiao;
        }

        public string MaSinhVien { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        //-----------------
        public int KhoaHoc // Khóa học
        {
            get { return NgayVaoTruong.Year; }
        }
        public DateTime NgayVaoTruong { get; set; } // Ngày vào trường
        public string Khoa { get; set; } // Khoa: Công nghệ Thông tin, Quản Trị Kinh Doanh, ...
        public string TrangThai { get; set; } // Trạng thái: Đang học, ra trường, ...
        public string BacDaoTao { get; set; } // Bậc đào tạo: Đại học, cao đẳng, ...
        public string SDT { get; set; } // Số điện thoại
        public string CMND { get; set; }
        public string DiaChiTT { get; set; } // Địa chỉ thường trú
        public string DanToc { get; set; }
        public string TonGiao { get; set; }

        public void xuat()
        {
            Console.WriteLine("\t{0,-15}{1,-30}{2,-15}{3,-15}{4,-10}", MaSinhVien, Ten, Lop, GioiTinh, NgaySinh.ToShortDateString());
        }
        public void xuatCT() // xuất chi tiết
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tTHÔNG TIN SINH VIÊN");
            Console.ResetColor();
            Console.WriteLine("\tMã sinh viên: " + MaSinhVien);
            Console.WriteLine("\tHọ tên: " + Ten);
            Console.WriteLine("\tGiới tính: " + GioiTinh);
            Console.WriteLine(("\tNgày sinh: " + NgaySinh.ToShortDateString()).PadRight(30) + ("Dân tộc: " + DanToc).PadRight(20) + "Tôn giáo: " + TonGiao);
            Console.WriteLine("\tSố CMND: " + CMND);
            Console.WriteLine("\tĐiện thoại: " + SDT);
            Console.WriteLine("\tĐịa chỉ thường trú: " + DiaChiTT);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tTHÔNG TIN HỌC VẤN");
            Console.ResetColor();
            Console.WriteLine(("\tTrạng thái: " + TrangThai).PadRight(50) + "Ngày vào trường: " + NgayVaoTruong.ToShortDateString());
            Console.WriteLine(("\tLớp: " + Lop).PadRight(50) + "Bậc đào tạo: " + BacDaoTao);
            Console.WriteLine(("\tKhoa: " + Khoa).PadRight(50) + "Khóa học: " + KhoaHoc);
        }
    }
}
