using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using StudentManagerment.Models;
using System.Text.Json;
using System.IO;

namespace StudentManagerment
{
    public class StudentList
    {
        List<Student> list = new List<Student>();

        public void loadFileJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                list = JsonSerializer.Deserialize<List<Student>>(json);
            }
        }
        public void loadFileXML(string fileName)
        {
            XmlDocument reader = new XmlDocument();
            try
            {
                reader.Load(fileName);
                XmlNodeList dsSV = reader.SelectNodes("/DanhSachSinhVien/SinhVien");
                foreach (XmlNode node in dsSV)
                {
                    string mssv = node["MaSV"].InnerText;
                    string ten = node["Ten"].InnerText;
                    string gt = node["GioiTinh"].InnerText;
                    DateTime ns = DateTime.ParseExact(node["NgaySinh"].InnerText, "dd/MM/yyyy", null);
                    DateTime nvt = DateTime.ParseExact(node["NgayVaoTruong"].InnerText, "dd/MM/yyyy", null);
                    string lop = node["Lop"].InnerText;
                    string khoa = node["Khoa"].InnerText;
                    string trangthai = node["TrangThai"].InnerText;
                    string bacdaotao = node["BacDaoTao"].InnerText;
                    string sdt = node["SDT"].InnerText;
                    string cmnd = node["CMND"].InnerText;
                    string diachithuongtru = node["DCTT"].InnerText;
                    string dantoc = node["DanToc"].InnerText;
                    string tongiao = node["TonGiao"].InnerText;
                    list.Add(new Student(mssv, ten, gt, lop, ns, nvt, khoa, trangthai, bacdaotao, sdt, cmnd, diachithuongtru, dantoc, tongiao));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void xuat()
        {
            Console.WriteLine("\t\t\t\t\tDANH SÁCH SINH VIÊN");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine('\t' + "Mã sinh viên".PadRight(15) + "Họ và tên".PadRight(30) + "Lớp".PadRight(15) + "Giới tính".PadRight(15) + "Ngày sinh".PadRight(10));
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 15 + 30 + 15 + 15 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            foreach (Student sv in list)
            {
                sv.xuat();
            }
        }

        public Student findSV(string masv)
        {
            return list.Find(t => t.MaSinhVien == masv);
        }
        public List<Student> getAllStudent()
        {
            return list;
        }
    }
}
