using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using StudentManagerment.Models;
using System.IO;
using System.Text.Json;

namespace StudentManagerment
{
    public class SubjectList
    {
        List<Subject> list = new List<Subject>();

        public void loadFileJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                list = JsonSerializer.Deserialize<List<Subject>>(json);
            }
        }
        public void loadFileXML(string fileName)
        {
            XmlDocument reader = new XmlDocument();
            try
            {
                reader.Load(fileName);
                XmlNodeList dsMH = reader.SelectNodes("/DanhSachMonHoc/MonHoc");
                foreach (XmlNode node in dsMH)
                {
                    string tenMH = node["TenMonHoc"].InnerText;
                    int soTiet = int.Parse(node["SoTiet"].InnerText);
                    double tlQT = double.Parse(node["TyLeQuaTrinh"].InnerText);
                    double tlTP = double.Parse(node["TyLeThanhPhan"].InnerText);
                    list.Add(new Subject(tenMH, soTiet, tlQT, tlTP));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void xuat()
        {
            Console.WriteLine("\t\t\t\tDANH SÁCH MÔN HỌC");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t" + "Tên môn".PadRight(50) + "Số tiết".PadRight(10));
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 60; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            foreach (Subject mh in list)
            {
                Console.WriteLine("\t" + mh.TenMonHoc.PadRight(50) + mh.SoTiet.ToString().PadRight(10));
            }
        }

        public Subject findMH(string tenMH)
        {
            return list.Find(t => t.TenMonHoc == tenMH);
        }
        public List<Subject> getAllSubject()
        {
            return list;
        }
    }
}
