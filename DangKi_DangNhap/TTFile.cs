using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKi_DangNhap
{
    public partial class TTFile : Form
    {

        private TaiLieu tenfile;

        public TTFile(TaiLieu tl)
        {
            InitializeComponent();
            this.tenfile = tl;
            SetTenTaiLieuToLabel3();
        }
        private void SetTenTaiLieuToLabel3()
        {

                label3.Text = tenfile.fileName;
            label5.Text = tenfile.UserUp;
            label7.Text = tenfile.Date;
            label9.Text = tenfile.PathFile;
        }
        private void TTFile_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
