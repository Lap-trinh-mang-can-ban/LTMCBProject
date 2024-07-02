using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangKi_DangNhap
{

    public partial class LapLich : Form

    {
        private readonly string userName;
        int month, year, day;
        public static int static_month, static_year;
        public LapLich(string user, string temp)
        {
            InitializeComponent();
            userName = user;


        }
        private void OpenEventForm()
        {
            EventForm eventForm = new EventForm(userName); // Truyền giá trị userName vào constructor của EventForm
            eventForm.Show();
        }
        private void LapLich_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            day = now.Day;
            static_month = month;
            static_year = year;
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDates.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 uscontrol = new UserControl1();
                flowLayoutPanel1.Controls.Add(uscontrol);

            }
            for (int i = 1; i <= days; i++)
            {
                UserControl2 uscontrol2 = new UserControl2(userName);
                uscontrol2.Days(i);
                uscontrol2.DisplayEvent(i);
                uscontrol2.ColorBack(i, month);
                flowLayoutPanel1.Controls.Add(uscontrol2);
            }
        }

   

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            month--;

            static_month = month;
            static_year = year;
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDates.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 uscontrol = new UserControl1();
                flowLayoutPanel1.Controls.Add(uscontrol);

            }
            for (int i = 1; i <= days; i++)
            {
                UserControl2 uscontrol2 = new UserControl2(userName);
                uscontrol2.Days(i);
                uscontrol2.DisplayEvent(i);
                uscontrol2.ColorBack(i, month);
                flowLayoutPanel1.Controls.Add(uscontrol2);
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            month++;
            static_month = month;
            static_year = year;
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDates.Text = monthname + " " + year;
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControl1 uscontrol = new UserControl1();
                flowLayoutPanel1.Controls.Add(uscontrol);

            }
            for (int i = 1; i <= days; i++)
            {
                UserControl2 uscontrol2 = new UserControl2(userName);
                uscontrol2.Days(i);
                uscontrol2.DisplayEvent(i);
                uscontrol2.ColorBack(i, month);
                flowLayoutPanel1.Controls.Add(uscontrol2);
            }
        }
    }
}
