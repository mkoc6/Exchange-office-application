using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteBuying").InnerXml;
            LblDolarAlıs.Text = dolaralis.ToString();

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='USD']/BanknoteSelling").InnerXml;
            LblDolarSatis.Text = dolarsatis.ToString();

            string EuroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/BanknoteSelling").InnerXml;
            LblEuroAlis.Text = EuroAlis.ToString();

            string EuroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='EUR']/BanknoteSelling").InnerXml;
            LblEuroSatis.Text = EuroSatis.ToString();

            string SterlinAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='GBP']/BanknoteSelling").InnerXml;
            LblSterlinAlis.Text = SterlinAlis.ToString();

            string SterlinSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod ='GBP']/BanknoteSelling").InnerXml;
            LblSterlinSatis.Text = SterlinSatis.ToString();

        }

        private void BtnDolarAl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblDolarAlıs.Text;
        }

        private void BtnDolarSat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblDolarSatis.Text;
        }

        private void BtnEuroAl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblEuroAlis.Text;
        }

        private void BtnEuroSat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblSterlinSatis.Text;
        }

        private void BtnSterlinAl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblSterlinAlis.Text;
        }

        private void BtnSterlinSat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TxtKur.Text = LblSterlinSatis.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtKalan.Text = "";
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = kur * miktar;
            TxtToplam.Text = tutar.ToString();
        }

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtToplam.Text = "";
            TxtKalan.Text = "";
            double ku = Convert.ToDouble(TxtKur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar = Convert.ToInt32((miktar / ku)) ;
            textBox1.Text = tutar.ToString();
            double kalan;
            kalan = miktar % ku;
            TxtKalan.Text = kalan.ToString();

        }
    }
}
