using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Giriş çıkış olayları için.

namespace MetinBelgesiİşlemler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string belgeadi, belgeyolu;
        StreamWriter sw;

        private void button2_Click(object sender, EventArgs e)
        {
            belgeadi = textBox1.Text;
            sw = File.CreateText(belgeyolu + "\\" + belgeadi + ".txt"); //belge oluşturuluyor.
            sw.Close();
            MessageBox.Show("Belge başarıyla kaydedildi.");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
               
                StreamReader oku = new StreamReader(openFileDialog1.FileName);
               

                string satır = oku.ReadLine();
                while(satır!= null)
                {
                    listBox1.Items.Add(satır);
                    satır = oku.ReadLine();
                   
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Filter = "Metin dosyası(*.txt) | *.txt";
            ac.Multiselect = false;
            if(ac.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ac.SafeFileName;
            }

            try
            {
                StreamReader oku = new StreamReader(ac.FileName);
                richTextBox1.Text = oku.ReadToEnd();
                oku.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Dosya okunmasında hata meydana geldi!");
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            { //saveFileDialog kayıt için kullanılabilir.
                saveFileDialog1.Title = "Kayıt yerini seçiniz"; //başlık ekledi.
                saveFileDialog1.Filter = "Metin Dosyası (*.txt) | *.txt"; //filtresi,txt ye izin var sadece.
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.InitialDirectory = "C:\\"; //C'den açar.
                saveFileDialog1.ShowDialog();
                StreamWriter yaz = new StreamWriter(saveFileDialog1.FileName);
                yaz.WriteLine(richTextBox2.Text);
                yaz.Close();
                MessageBox.Show("Kaynak metin belgesine başarıyla kaydedildi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata oluştu, işlem gerçekleştirilemedi!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                belgeyolu = folderBrowserDialog1.SelectedPath.ToString();
                textBox2.Text = belgeyolu.ToString();
                
            }
            
        }
    }
}
