using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Diagnostics;
using Bunifu.UI.WinForms.BunifuAnimatorNS;
using Bunifu.UI.WinForms;


namespace DangKi_DangNhap
{
    public partial class TrangChuThatSu : Form
    {
        private NewsService newsService;

        private List<Image> imageList;
        private int currentImageIndex;
        private BunifuTransition bunifuTransition;
        public TrangChuThatSu()
        {
            InitializeComponent();
            newsService = new NewsService();

            imageList = new List<Image>();
            currentImageIndex = 0;
            bunifuTransition = new BunifuTransition();

            // Add your images to the imageList
            imageList.Add(Properties.Resources.Image1);
            imageList.Add(Properties.Resources.Image2);
            imageList.Add(Properties.Resources.Image3);
            imageList.Add(Properties.Resources.Image4);
            imageList.Add(Properties.Resources.Image5);
            imageList.Add(Properties.Resources.Image6);
            imageList.Add(Properties.Resources.Image7);

            // Set initial image
            bunifuPictureBox1.Image = imageList[currentImageIndex];
            // Start the image slideshow
            StartImageSlideshow();
        }

        private void TrangChuThatSu_Load(object sender, EventArgs e)
        {
            try
            {
                var news = newsService.GetRandomNews();
                lblTitle.Text = news.Title;
                tbDescription.Text = news.Description;
                linkLabel1.Text = "Xem chi tiết ";
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(0, linkLabel1.Text.Length, news.Link);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải tin tức: " + ex.Message);
            }
        }
        private void StartImageSlideshow()
        {
            timer1.Interval = 5000; // Change image every 2 seconds
            timer1.Tick += new EventHandler(OnTimerTick);
            timer1.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            bunifuTransition.HideSync(bunifuPictureBox1);
            currentImageIndex = (currentImageIndex + 1) % imageList.Count;
            bunifuPictureBox1.Image = imageList[currentImageIndex];
            bunifuTransition.ShowSync(bunifuPictureBox1);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string url = e.Link.LinkData.ToString();
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("Liên kết không hợp lệ: " + url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở liên kết: " + ex.Message);
            }
        }

       
    }
    public class NewsService
    {
        private string rssUrl = "https://vnexpress.net/rss/giao-duc.rss"; // URL của RSS feed

        public NewsService() { }

        public (string Title, string Description, string Link) GetRandomNews()
        {
            var reader = XmlReader.Create(rssUrl);
            var feed = SyndicationFeed.Load(reader);
            reader.Close();

            if (feed == null) throw new Exception("Unable to load RSS feed.");

            var items = feed.Items.ToList();
            var randomIndex = new Random().Next(items.Count);
            var randomItem = items[randomIndex];

            return (randomItem.Title.Text, randomItem.Summary.Text, randomItem.Links[0].Uri.ToString());
        }
    }
}
