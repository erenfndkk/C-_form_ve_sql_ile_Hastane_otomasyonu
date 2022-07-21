using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane__Proje
{
    public partial class FrmHastakayit : Form
    {
        public FrmHastakayit()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
                
            SqlCommand komut = new SqlCommand("insert into tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p0,@p1,@p2,@3,@p4,@5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p0", txtAd.Text);
            komut.Parameters.AddWithValue("@p1", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p2", MskTC.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("kaydınız yapılmıştır şifreniz : " + TxtSifre.Text, "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmHastakayit_Load(object sender, EventArgs e)
        {

        }
    }
}
