﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
     {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Truyền các tham số thích hợp vào đây
            bool ismenuQuyen = true;
            string username = "ExampleUser";

            //Application.Run(new Main(ismenuQuyen, username));
            Application.Run(new DangNhap());
        }
    }
}
