using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using StudentManagerment.Models;
using System.IO;
using System.Text.Json;

namespace StudentManagerment
{
    public class TranscriptList
    {
        List<Transcript> list = new List<Transcript>();

        public void loadFileJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                list = JsonSerializer.Deserialize<List<Transcript>>(json);
            }
        }
        public Transcript findBD(string mssv)
        {
            return list.Find(t => t.MaSinhVien == mssv);
        }

        public void loadFileXML(StudentList dssv, SubjectList dsmh, string fileName)
        {
            XmlDocument reader = new XmlDocument();
            try
            {
                reader.Load(fileName);
                XmlNodeList dsdk = reader.SelectNodes("/DSMHDK/DangKy");
                foreach (XmlNode node in dsdk)
                {
                    string mssv = node["MSSV"].InnerText;
                    if (dssv.findSV(mssv) != null)
                    {
                        string tenMH = node["MonHoc"]["TenMH"].InnerText;
                        Subject monHoc = dsmh.findMH(tenMH);
                        if (monHoc != null)
                        {
                            int soTiet = int.Parse(node["MonHoc"]["SoTiet"].InnerText);
                            double diemQuaTrinh = double.Parse(node["MonHoc"]["DiemQuaTrinh"].InnerText);
                            double diemThanhPhan = double.Parse(node["MonHoc"]["DiemThanhPhan"].InnerText);
                            Transcript tam = this.findBD(mssv);
                            if (tam != null)
                            {
                                tam.bangDiem.Add(new Result(new Subject(tenMH, soTiet, monHoc.TyLeQT, monHoc.TyLeTP), new Scores(diemQuaTrinh, diemThanhPhan)));
                            }
                            else
                            {
                                List<Result> kqmh = new List<Result>();
                                kqmh.Add(new Result(new Subject(tenMH, soTiet, monHoc.TyLeQT, monHoc.TyLeTP), new Scores(diemQuaTrinh, diemThanhPhan)));
                                list.Add(new Transcript(mssv, kqmh));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void xuat(StudentList dssv)
        {
            foreach (Transcript transcript in list)
            {
                transcript.xuat(dssv);
            }
        }

        public void xemMonHocSVDangKy()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t" + "Tên môn".PadRight(50) + "Số tiết".PadRight(10));
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 50 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            List<string> dsMH_DaXuat = new List<string>();
            foreach (Transcript transcript in list)
            {
                foreach (Result result in transcript.bangDiem)
                {
                    if (dsMH_DaXuat.Find(t => t == result.MonHoc.TenMonHoc) == null)
                    {
                        Console.WriteLine("\t{0,-50}{1,-10}", result.MonHoc.TenMonHoc, result.MonHoc.SoTiet);
                        dsMH_DaXuat.Add(result.MonHoc.TenMonHoc);
                    }
                }
            }
        }
        public List<Transcript> getAllTranscript()
        {
            return list;
        }
    }
}
