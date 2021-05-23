using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStudent.Models
{
    /// <summary>
    /// Entity Sinh Vien
    /// </summary>
    public class SinhVienModel
    {
        public int MaSV { get; set; }
        public string HoTen { get;set;}
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MaLop { get; set; }
    }
}