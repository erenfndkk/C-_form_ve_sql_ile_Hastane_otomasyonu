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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        public string TC;
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TC;
            // ad Soyad çekme
            SqlCommand komut1 = new SqlCommand("select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", LblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branşları datagride aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_Branslarrrrrrrr", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // doktorları datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select (DoktorAd + ' ' + DoktorSoyad) as ' Doktorlar', DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            // branşları combo ya aktarma
            SqlCommand komut2 = new SqlCommand("select BransAd From Tbl_Branslarrrrrrrr", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while(dr.Read())
            {
                CmbBrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih," +
                "RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu oluşturuldu.");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            // doktorları combo ya aktarma
            CmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                CmbDoktor.Items.Add(dr2[0] + " " + dr2[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", RChDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Kaydedildi", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr = new FrmDoktorPaneli();
            fr.Show();
        }

        private void BtnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBrans fr = new FrmBrans();
            fr.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.Show();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }
    }
}
