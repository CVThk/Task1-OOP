using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Transcript
    {
        public List<Result> bangDiem { get; set; }
        public string MaSinhVien { get; set; }
        public Transcript() { }
        public Transcript(string maSV, List<Result> bangDiem)
        {
            MaSinhVien = maSV;
            this.bangDiem = bangDiem;
        }
        public void xuat(StudentList dssv)
        {
            Student sv = dssv.findSV(MaSinhVien);
            sv.xuat();
            Console.WriteLine("\n >> BẢNG ĐIỂM");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t{0,-50}{1,-10}{2,-20}{3,-20}", "Tên môn học", "Số tiết", "Điểm quá trình", "Điểm thành phần");
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 50 + 20 + 20 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            foreach (Result result in bangDiem)
            {
                string diemQuaTrinh = (result.DiemMonHoc.DiemQuaTrinh == -1) ? "" : result.DiemMonHoc.DiemQuaTrinh.ToString();
                string diemThanhPhan = (result.DiemMonHoc.DiemThanhPhan == -1) ? "" : result.DiemMonHoc.DiemThanhPhan.ToString();
                Console.WriteLine("\t{0,-50}{1,-10}{2,-20}{3,-20}", result.MonHoc.TenMonHoc, result.MonHoc.SoTiet, diemQuaTrinh, diemThanhPhan);
            }
        }

        public void nhapDiemMonHoc()
        {
            Console.Write("\n\tNhập tên môn học muốn nhập điểm: ");
            string tenMH = Console.ReadLine();
            foreach (Result result in bangDiem)
            {
                if (result.MonHoc.TenMonHoc == tenMH)
                {
                    double diemQuaTrinh, diemThanhPhan;
                    bool kt;
                    do
                    {
                        Console.Write("\tNhập điểm quá trình: ");
                        kt = double.TryParse(Console.ReadLine(), out diemQuaTrinh);
                    } while (kt == false || diemQuaTrinh < 0 || diemQuaTrinh > 10);
                    do
                    {
                        Console.Write("\tNhập điểm thành phần: ");
                        kt = double.TryParse(Console.ReadLine(), out diemThanhPhan);
                    } while (kt == false || diemThanhPhan < 0 || diemThanhPhan > 10);
                    result.DiemMonHoc.DiemQuaTrinh = diemQuaTrinh;
                    result.DiemMonHoc.DiemThanhPhan = diemThanhPhan;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t >> Hoàn tất.");
                    Console.ResetColor();
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy môn học trong danh sách hiện tại!");
            Console.ResetColor();
        }

        public void xuatKQ(StudentList dssv)
        {
            Student sv = dssv.findSV(MaSinhVien);
            sv.xuat();
            Console.WriteLine("\n >> BẢNG ĐIỂM");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t{0,-40}{1,-10}{2,-20}{3,-20}{4,-10}", "Tên môn học", "Số tiết", "Điểm quá trình", "Điểm thành phần", "Kết quả");
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 50 + 20 + 20 + 10 + 20; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            foreach (Result result in bangDiem)
            {
                string diemQuaTrinh = (result.DiemMonHoc.DiemQuaTrinh == -1) ? "" : result.DiemMonHoc.DiemQuaTrinh.ToString();
                string diemThanhPhan = (result.DiemMonHoc.DiemThanhPhan == -1) ? "" : result.DiemMonHoc.DiemThanhPhan.ToString();
                Console.WriteLine("\t{0,-40}{1,-10}{2,-20}{3,-20}{4,-10}", result.MonHoc.TenMonHoc, result.MonHoc.SoTiet, diemQuaTrinh, diemThanhPhan, result.danhGia());
            }
        }
    }
}
