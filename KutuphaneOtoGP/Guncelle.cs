﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KutuphaneOtoGP
{
    public partial class Guncelle : Form
    {
        public Guncelle()
        {
            InitializeComponent();
        }


        public static int select;
        private void Guncelle_Load(object sender, EventArgs e)
        {

            UyeListele frm1 = new UyeListele();
            tcTXT.Text = UyeListele.tc;
            adTXT.Text = UyeListele.ad;
            soyadTXT.Text = UyeListele.soyad;
            telTXT.Text = UyeListele.tel;
            mailTXT.Text = UyeListele.e_mail;
            adresTXT.Text = UyeListele.adres;
            select = UyeListele.selectedValue;
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            string tc = tcTXT.Text;
            string ad = adTXT.Text;
            string soyad = soyadTXT.Text;
            string mail = mailTXT.Text;
            string adres = adresTXT.Text;

            string dosyaYolu = "E://AddUser.csv"; // CSV dosya yolunu burada belirtin

            if (File.Exists(dosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu);

                if (satirlar.Length > 0)
                {
                    // Güncellenmiş verileri al
                    string[] guncellenmisVeriler = new string[6];
                    guncellenmisVeriler[0] = tcTXT.Text;
                    guncellenmisVeriler[1] = adTXT.Text;
                    guncellenmisVeriler[2] = soyadTXT.Text;
                    guncellenmisVeriler[3] = telTXT.Text;
                    guncellenmisVeriler[4] = mailTXT.Text;
                    guncellenmisVeriler[5] = adresTXT.Text;

                    // İlgili satırdaki verileri güncelle
                    satirlar[select] = string.Join(";", guncellenmisVeriler);

                    // Dosyaya güncellenmiş verileri yaz
                    File.WriteAllLines(dosyaYolu, satirlar);

                    MessageBox.Show("Veriler güncellendi!");

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
