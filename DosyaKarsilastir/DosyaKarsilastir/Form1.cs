using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DosyaKarsilastir
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        string line = "";
        public Form1()
        {
            InitializeComponent();
        }
        List<string> liste_A = new List<string>();
        List<string> liste_B = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            openFile.Filter = "Text Files (.txt)| *.txt";
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                liste_A.Clear();
                listBox1.Items.Clear();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFile.FileName);
                    lbl_dosyaAdi1.Text = openFile.FileName;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {

                            listBox1.Items.Add(line.Trim());
                            liste_A.Add(line.Trim());
                        }
                    }
                    line = "";
                    sr.Dispose();
                    sr.Close();
                }
                label2.Text = listBox1.Items.Count.ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Listelenmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                label3.Text = openFile.FileName;
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {

                        listBox2.Items.Add(line.Trim());
                        liste_A.Add(line.Trim());
                    }
                }
                line = "";
                sr.Dispose();
                sr.Close();
            }
            label6.Text = listBox2.Items.Count.ToString();
            button5.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbl_dosyaAdi1.Text = "";
            label2.Text = "";
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label6.Text = "";
            listBox2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.DataSource = null;
            liste_B.Clear();
            
            ////Aynı Olanlar
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = 0; j < listBox2.Items.Count; j++)
                {
                    if (listBox1.Items[i].ToString() == listBox2.Items[j].ToString())
                    {
                        listBox3.Items.Add(listBox1.Items[i].ToString());
                        // listBox3.Items.Add(listBox1.Items[i].ToString() + " " + i);
                        //listBox2.Items.Remove(j);
                        liste_B.Add(listBox1.Items[i].ToString());
                    }

                }
                //listBox1.Items.Remove(i);
            }

            label9.Text = listBox3.Items.Count.ToString();//Aynı Olanlar
                                                          //listBox3.Items.Add(listBox1.Items.Count + " *** " + listBox2.Items.Count + " *** " + listBox3.Items.Count);

            //for (int i = 0; i < listBox3.Items.Count; i++)
            //{
               
            //}
         


            




            listBox4.DataSource = liste_A.Except(liste_B).ToList();//A da olup B de olmayan
            //listBox4.DataSource= liste_B.Except(liste_A).ToList();//B de olup A da olmayan
            label11.Text = listBox4.Items.Count.ToString();//Aynı Olanlar
            // listBox4.DataSource = liste_A.Except(liste_B).ToList();
            //listBox4.DataSource = listBox1.Items.OfType<string>().ToArray().Except(listBox2.Items.OfType<string>().ToArray()).Union(listBox2.Items.OfType<string>().ToArray().Except(listBox1.Items.OfType<string>().ToArray())).ToArray();

            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox4.DataSource=null;
            liste_B.Clear();            
            button1.Enabled = true;
            button2.Enabled = true;
            label9.Text = "";
            label11.Text = "";
            lbl_dosyaAdi1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label6.Text = "";
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFile.FileName);
                    //label3.Text = openFile.FileName;
                    sr.Dispose();
                    sr.Close();
                    string dosya_yolu = openFile.FileName;
                    using (TextWriter TW = new StreamWriter(dosya_yolu))
                    {
                        foreach (string itemText in listBox3.Items)
                        {
                            TW.WriteLine(itemText);
                        }
                        foreach (string itemText in listBox4.Items)
                        {
                            TW.WriteLine(itemText);
                        }
                    }
                    Process.Start(dosya_yolu);
                    //string[] kayit_Dizisi = new string[listBox3.Items.Count + listBox4.Items.Count];
                    //listBox3.Items.CopyTo(kayit_Dizisi, 0);
                    //listBox4.Items.CopyTo(kayit_Dizisi, 0);
                    //System.IO.File.WriteAllLines(dosya_yolu, kayit_Dizisi);
                    //MessageBox.Show("Başarılı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Hata Bilgisi");
            }
            

               

            }
           
        }
    }

    