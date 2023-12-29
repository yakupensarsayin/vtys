using Npgsql;
using System.Data;
using System.Data.SqlClient;

namespace vtys
{
    public partial class Form1 : Form
    {
        NpgsqlConnection baglanti;
        public Form1()
        {
            InitializeComponent();
            baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=aracKiralama; userID=postgres; password=12345");
        }

        private void buttonekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("select * from insert_arabalar(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBoxarbno.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(textBoxarbturid.Text));
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBoxkm.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBoxknmid.Text));
            komut1.Parameters.AddWithValue("@p5", textBoxmarka.Text);
            komut1.Parameters.AddWithValue("@p6", textBoxmdl.Text);
            komut1.Parameters.AddWithValue("@p7", textBoxplaka.Text);
            komut1.Parameters.AddWithValue("@p8", textBoxrenk.Text);
            komut1.Parameters.AddWithValue("@p9", int.Parse(textBoxurtmyil.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            MessageBox.Show("Araba ekleme iþlemi baþarýlý.");
        }

        private void buttonsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from arabalar where arabano=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBoxarbno.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araba silme iþlemi baþarýlý.");
        }

        private void buttongnclle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("select * from update_arabalar(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBoxarbno.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBoxarbturid.Text));
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBoxkm.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBoxknmid.Text));
            komut3.Parameters.AddWithValue("@p5", textBoxmarka.Text);
            komut3.Parameters.AddWithValue("@p6", textBoxmdl.Text);
            komut3.Parameters.AddWithValue("@p7", textBoxplaka.Text);
            komut3.Parameters.AddWithValue("@p8", textBoxrenk.Text);
            komut3.Parameters.AddWithValue("@p9", int.Parse(textBoxurtmyil.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut3);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
            MessageBox.Show("Araba güncelleme iþlemi baþarýlý.");
        }

        private void buttonara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("select * from arabalar where arabano=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(textBoxarbno.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void buttonlist_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from arabalar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void buttonsayi_Click(object sender, EventArgs e)
        {
            string sorgu1 = "select * from toplamaraba";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu1, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void buttonekpmnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("select * from insert_ekipman(@p1,@p2,@p3,@p4)", baglanti);
            komut5.Parameters.AddWithValue("@p1", int.Parse(textBoxekpmnno.Text));
            komut5.Parameters.AddWithValue("@p2", textBoxekpmnad.Text);
            komut5.Parameters.AddWithValue("@p3", int.Parse(textBoxekpmnturid.Text));
            komut5.Parameters.AddWithValue("@p4", int.Parse(textBoxekpmnknm.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut5);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            baglanti.Close();
            MessageBox.Show("Ekipman ekleme iþlemi baþarýlý.");
        }

        private void buttonekpmnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut6 = new NpgsqlCommand("delete from ekipman where ekipmanno=@p1", baglanti);
            komut6.Parameters.AddWithValue("@p1", int.Parse(textBoxekpmnno.Text));
            komut6.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ekipman silme iþlemi baþarýlý.");
        }

        private void buttonekpmngnclle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut7 = new NpgsqlCommand("select * from update_ekipman(@p1,@p2,@p3,@p4)", baglanti);
            komut7.Parameters.AddWithValue("@p1", int.Parse(textBoxekpmnno.Text));
            komut7.Parameters.AddWithValue("@p2", textBoxekpmnad.Text);
            komut7.Parameters.AddWithValue("@p3", int.Parse(textBoxekpmnturid.Text));
            komut7.Parameters.AddWithValue("@p4", int.Parse(textBoxekpmnknm.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut7);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            baglanti.Close();
            MessageBox.Show("Ekipman güncelleme iþlemi baþarýlý.");
        }

        private void buttonekpmnara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut8 = new NpgsqlCommand("select * from ekipman where ekipmanno=@p1", baglanti);
            komut8.Parameters.AddWithValue("@p1", int.Parse(textBoxekpmnno.Text));
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut8);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void buttonekpmnlist_Click(object sender, EventArgs e)
        {
            string sorgu2 = "select * from ekipman";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu2, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
        }

        private void buttonekpmnsayi_Click(object sender, EventArgs e)
        {
            string sorgu3 = "select * from toplamekpmn";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}