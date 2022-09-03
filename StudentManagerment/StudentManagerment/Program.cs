using System;
using System.Text;
using StudentManagerment.Models;
using System.Text.Json;
using System.IO;

namespace StudentManagerment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;


            StudentList dssv = new StudentList();
            dssv.loadFileJson("../../../Files/DSSV.json");
            //dssv.loadFileXML("../../../Files/DSSV.xml");

            SubjectList dsmh = new SubjectList();
            dsmh.loadFileJson("../../../Files/DSMH.json");
            //dsmh.loadFileXML("../../../Files/DSMH.xml");
            TranscriptList dsbd = new TranscriptList();
            dsbd.loadFileJson("../../../Files/DSMHDangKy.json");
            //dsbd.loadFileXML(dssv, dsmh, "../../../Files/DSMHDangKy.xml");

            Console.WriteLine("\t\t----------------- CHỨC NĂNG -----------------");
            Console.WriteLine("\t\t1. Xem danh sách sinh viên.");
            Console.WriteLine("\t\t2. Xem chi tiết sinh viên.");
            Console.WriteLine("\t\t3. Xem số môn học sinh viên đăng ký.");
            Console.WriteLine("\t\t4. Xem điểm môn học của sinh viên.");
            Console.WriteLine("\t\t5. Nhập điểm của sinh viên.");
            Console.WriteLine("\t\t6. Xem kết quả trượt đỗ của sinh viên.");
            Console.WriteLine("\t\t7. Cập nhật file Json.");
            Console.WriteLine("\t\t0. Thoát.");
            Console.Write("\t\t---------------------------------------------");

            int luachon;
            while (true)
            {
                //Console.Clear();
                bool ktNhap;
                do
                {
                    Console.Write("\n\tNhập chức năng >> ");
                    ktNhap = int.TryParse(Console.ReadLine(), out luachon);
                } while (!ktNhap);

                if (luachon == 0)
                    break;
                else if (luachon == 1)
                {
                    dssv.xuat();
                }
                else if (luachon == 2)
                {
                    string masv;
                    Console.Write("\n\tNhập mã sinh viên để xem thông tin: ");
                    masv = Console.ReadLine();
                    Student f = dssv.findSV(masv);
                    if (f == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" √ Tìm thấy.");
                        Console.ResetColor();
                        f.xuatCT();
                    }
                }
                else if (luachon == 3)
                {
                    dsbd.xemMonHocSVDangKy();
                }
                else if (luachon == 4)
                {
                    string masv;
                    Console.Write("\n\tNhập mã sinh viên để xem điểm: ");
                    masv = Console.ReadLine();
                    Transcript bdsv = dsbd.findBD(masv);
                    if (bdsv == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" √ Tìm thấy.");
                        Console.ResetColor();
                        bdsv.xuat(dssv);
                    }
                }
                else if (luachon == 5)
                {
                    string masv;
                    Console.Write("\n\tNhập mã sinh viên để nhập điểm: ");
                    masv = Console.ReadLine();
                    Transcript bdsv = dsbd.findBD(masv);
                    if (bdsv == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" √ Tìm thấy.");
                        Console.ResetColor();
                        bdsv.xuat(dssv);


                        bdsv.nhapDiemMonHoc();
                    }
                }
                else if (luachon == 6)
                {
                    string masv;
                    Console.Write("\n\tNhập mã sinh viên để xem kết quả: ");
                    masv = Console.ReadLine();
                    Transcript bdsv = dsbd.findBD(masv);
                    if (bdsv == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" √ Tìm thấy.");
                        Console.ResetColor();
                        bdsv.xuatKQ(dssv);
                    }
                }
                else if(luachon == 7)
                {
                    string jsonString = JsonSerializer.Serialize(dssv.getAllStudent(), new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("../../../Files/DSSV.json", jsonString);
                    jsonString = JsonSerializer.Serialize(dsmh.getAllSubject(), new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("../../../Files/DSMH.json", jsonString);
                    jsonString = JsonSerializer.Serialize(dsbd.getAllTranscript(), new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("../../../Files/DSMHDangKy.json", jsonString);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" √ Successful.");
                    Console.ResetColor();
                }    
                else Console.WriteLine("\tVui lòng nhập chức năng cho chính xác!");
            }
        }
    }
}
