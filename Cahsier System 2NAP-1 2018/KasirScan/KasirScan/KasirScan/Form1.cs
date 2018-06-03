using MaterialSkin.Controls;
using MaterialSkin;
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

namespace KasirScan
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {

            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.materialLabel4.Text = DateTime.Now.ToString();
            comboSearch.Items.Add(new Item("Date", 0));
            comboSearch.Items.Add(new Item("Transaksi ID", 1));
            comboSearch.Items.Add(new Item("Payment Method", 2));
            comboSearch.Items.Add(new Item("Price", 3));
            comboSearch.Items.Add(new Item("Nama Kasir", 4));
        }
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        class Mergesort
        {
            public static void sort<T>(ref List<T> a)
            where T : IComparable<T>
            {
                sort(ref a, 0, a.Count);
            }

            public static void sort<T>(ref List<T> a, int low, int high)
                where T : IComparable<T>
            {
                int N = high - low;
                if (N <= 1)
                    return;

                int mid = low + N / 2;

                sort(ref a, low, mid);
                sort(ref a, mid, high);

                T[] aux = new T[N];
                int i = low, j = mid;
                for (int k = 0; k < N; k++)
                {
                    if (i == mid) aux[k] = a[j++];
                    else if (j == high) aux[k] = a[i++];
                    else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
                    else aux[k] = a[i++];
                }

                for (int k = 0; k < N; k++)
                {
                    a[low + k] = aux[k];
                }
            }
        }
        class DataAsc : IComparable<DataAsc>
        {
            public DateTime Date { get; set; }
            public string TransID { get; set; }
            public string Payment { get; set; }
            public int Price { get; set; }
            public string Cashier { get; set; }

            public int CompareTo(DataAsc other)
            {
                // Alphabetic sort if salary is equal. [A to Z]
                if (this.Date == other.Date)
                {
                    return this.Price.CompareTo(other.Price);
                }
                // Default to salary sort. [High to low]
                return this.Date.CompareTo(other.Date);
            }

            public override string ToString()
            {
                // String representation.
                //return this.Salary.ToString() + "," + this.Name+"," + this.Date.ToShortDateString() ;
                return this.Date.ToShortDateString() + "," + this.TransID + "," + this.Payment + "," + this.Price.ToString() + "," + this.Cashier;
            }
        }
        class DataDesc : IComparable<DataDesc>
        {
            public DateTime Date { get; set; }
            public string TransID { get; set; }
            public string Payment { get; set; }
            public int Price { get; set; }
            public string Cashier { get; set; }

            public int CompareTo(DataDesc other)
            {
                // Alphabetic sort if salary is equal. [A to Z]
                if (this.Date == other.Date)
                {
                    return this.Price.CompareTo(other.Price);
                }
                // Default to salary sort. [High to low]
                return other.Date.CompareTo(this.Date);
            }

            public override string ToString()
            {
                // String representation.
                //return this.Salary.ToString() + "," + this.Name+"," + this.Date.ToShortDateString() ;
                return this.Date.ToShortDateString() + "," + this.TransID + "," + this.Payment + "," + this.Price.ToString() + "," + this.Cashier;
            }
        }
        public static Random rnd = new Random();
        public string trxid;
        private static string path = "ProductData.txt";
        public static PictureBoxScan frmScan = new PictureBoxScan();
        private void ClearTextBox()
        {
            materialSingleLineTextField1.Clear();
            materialSingleLineTextField2.Clear();
            textBox4.Clear();
            textBox1.Clear();
            materialSingleLineTextField5.Clear();
            textBox2.Clear();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            materialLabel4.Text = DateTime.Now.ToString();
            if (!string.IsNullOrWhiteSpace(frmScan.textBox1.Text))
            {
                materialSingleLineTextField1.Text = frmScan.textBox1.Text;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            frmScan.Show();
            
        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialListView1.SelectedItems.Count > 0)
            {
                ListViewItem item = materialListView1.SelectedItems[0];
                materialSingleLineTextField1.Text = item.SubItems[0].Text;
                materialSingleLineTextField5.Text = item.SubItems[2].Text;
                textBox1.Text = item.SubItems[3].Text;
                textBox2.Text = item.SubItems[4].Text;
                
            }
        }

        private void materialListView1_KeyDown(object sender, KeyEventArgs e)
        {
            {

                if (Keys.Delete == e.KeyCode)
                {
                    foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                    {
                        listViewItem.Remove();
                    }
                    ClearTextBox();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Up && !string.IsNullOrWhiteSpace(materialSingleLineTextField5.Text))
                {
                    if (Convert.ToInt32(materialSingleLineTextField5.Text) < Convert.ToInt32(textBox4.Text))
                    {
                        materialSingleLineTextField5.Text = (Convert.ToInt32(materialSingleLineTextField5.Text) + 1).ToString();
                    }

                }
                else if (e.KeyCode == Keys.Down && !string.IsNullOrWhiteSpace(materialSingleLineTextField5.Text))
                {
                    materialSingleLineTextField5.Text = (Convert.ToInt32(materialSingleLineTextField5.Text) - 1).ToString();
                    
                    
                }
                else if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text) && !string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(materialSingleLineTextField5.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {

                    var search = materialListView1.FindItemWithText(materialSingleLineTextField1.Text);
                    if (search != null)
                    {
                        ListViewItem item = materialListView1.Items[Convert.ToInt32(materialListView1.Items.IndexOf(search))];
                        if ((Convert.ToInt32(item.SubItems[2].Text) + Convert.ToInt32(materialSingleLineTextField5.Text)) <= Convert.ToInt32(textBox4.Text))
                        {
                            item.SubItems[2].Text = (Convert.ToInt32(item.SubItems[2].Text) + Convert.ToInt32(materialSingleLineTextField5.Text)).ToString();
                            item.SubItems[4].Text = (Convert.ToInt32(item.SubItems[2].Text) * Convert.ToInt32(item.SubItems[3].Text)).ToString();
                            ClearTextBox();
                            frmScan.textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Out of stock!");
                        }
                    }
                    else
                    {
                        string[] row = { materialSingleLineTextField1.Text, materialSingleLineTextField2.Text, materialSingleLineTextField5.Text, textBox1.Text, textBox2.Text };
                        var listViewItem = new ListViewItem(row);
                        materialListView1.Items.Add(listViewItem);
                        frmScan.textBox1.Clear();
                        ClearTextBox();
                    }
                }
                else if (e.KeyCode == Keys.U && !string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text) && !string.IsNullOrWhiteSpace(materialSingleLineTextField2.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(materialSingleLineTextField5.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    var search = materialListView1.FindItemWithText(materialSingleLineTextField1.Text);
                    if (search != null)
                    {
                        ListViewItem item = materialListView1.SelectedItems[Convert.ToInt32(materialListView1.Items.IndexOf(search))];
                        item.SubItems[0].Text = materialSingleLineTextField1.Text;
                        item.SubItems[1].Text = materialSingleLineTextField2.Text;
                        item.SubItems[3].Text = textBox1.Text;
                        item.SubItems[2].Text = materialSingleLineTextField5.Text; 
                        item.SubItems[4].Text = textBox2.Text;
                    }
                }

                else if (e.KeyCode == Keys.D1 && e.Alt)
                {
                    materialCheckBox2.Checked = false;
                    materialCheckBox1.Checked = true;
                    comboBox1.SelectedIndex = 0;
                    groupBox4.Visible = true;
                    groupBox2.Visible = false;

                }
                else if (e.KeyCode == Keys.D2 && e.Alt)
                {
                    materialCheckBox1.Checked = false;
                    materialCheckBox2.Checked = true;
                    comboBox1.SelectedIndex = 1;
                    groupBox2.Visible = true;
                    groupBox4.Visible = false;
                }
                else if (e.KeyCode == Keys.F2)
                {
                    if ((!materialCheckBox1.Checked) && (!materialCheckBox2.Checked))
                    {
                        MessageBox.Show("Please choose a payment method");
                    }
                    else
                    {
                        int jumlah = 0;
                        foreach (ListViewItem item in materialListView1.Items)
                        {
                            jumlah += Convert.ToInt32(item.SubItems[4].Text);
                        }
                        textBox3.Text = jumlah.ToString();
                        materialTabControl1.SelectedTab = materialTabControl1.TabPages[1];
                        frmScan.Hide();
                        textBox6.Focus();
                    }
                      
                }
            
            }
            else if(materialTabControl1.SelectedIndex == 1)
            {
                if (e.KeyCode == Keys.F1)
                {
                    materialTabControl1.SelectedTab = materialTabControl1.TabPages[0];
                    frmScan.Show();
                }
                
            }
        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            if(materialSingleLineTextField1.Text.Length >= 10)
            {
                dynamic hasil = new dynamic[5];
                foreach (string file in File.ReadLines(path))
                {
                    hasil = file.Split(',');
                    if (hasil[0].Equals(materialSingleLineTextField1.Text))
                    {
                        break;
                    }
                }
                if (hasil[0].Equals(materialSingleLineTextField1.Text))
                {
                    if (!string.IsNullOrWhiteSpace(materialSingleLineTextField1.Text))
                    {
                        materialSingleLineTextField5.Text = "1";
                        if (!hasil[0].Equals(materialSingleLineTextField1.Text))
                        {
                            MessageBox.Show("Product not found");
                            frmScan.textBox1.Clear();
                            ClearTextBox();
                        }
                        else
                        {
                            materialSingleLineTextField2.Text = hasil[1];
                            textBox4.Text = hasil[2];
                            textBox1.Text = hasil[3];
                            textBox2.Text = hasil[3];
                            materialSingleLineTextField1.Text = hasil[0];
                        }
                    }
                }
                else
                {
                    frmScan.textBox1.Clear();
                    materialSingleLineTextField1.Clear();
                    materialSingleLineTextField2.Clear();
                    textBox4.Clear();
                    textBox1.Clear();
                    materialSingleLineTextField5.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void materialSingleLineTextField5_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (!int.TryParse(materialSingleLineTextField5.Text, out a))
            {
                materialSingleLineTextField5.Text = "1";
            }
            else if (Convert.ToInt32(materialSingleLineTextField5.Text) < 1)
            {
                materialSingleLineTextField5.Text = "1";
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(materialSingleLineTextField5.Text))
            {
                textBox2.Text = (Convert.ToInt32(textBox1.Text) * Convert.ToInt32(materialSingleLineTextField5.Text)).ToString();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox3.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dynamic hasil = new dynamic[5];
            foreach (string file in File.ReadLines("CardData.txt"))
            {
                hasil = file.Split(',');
                if (hasil[0].Equals(textBox6.Text))
                {
                    break;
                }
            }
            if (hasil[0].Equals(textBox6.Text))
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    if (!hasil[0].Equals(textBox6.Text))
                    {
                        MessageBox.Show("Card not found");
                        ClearTextBox();
                    }
                    else
                    {
                        textBox8.Text = hasil[1];
                        textBox7.Text = hasil[2];
                    }
                }
            }
            else
            {
                textBox8.Clear();
                textBox7.Clear();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                textBox9.Text = (Convert.ToInt32(textBox10.Text) - Convert.ToInt32(textBox5.Text)).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please input number only");
                textBox9.Clear();
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox10.Text))
            {
                if ((Convert.ToInt32(textBox10.Text) >= Convert.ToInt32(textBox5.Text)))
                {
                    
                    panel1.Visible = true;
                    label1.Visible = true;
                    label2.Visible = false;
                    materialLabel29.Text = DateTime.Now.ToString();
                    trxid = rnd.Next(100000, 999999).ToString();
                    materialLabel25.Text = "TRX"+trxid;
                    materialLabel27.Text = comboBox1.Text;
                    materialLabel23.Text = textBox5.Text;
                    materialLabel28.Text = textBox5.Text;
                    materialLabel26.Text = textBox9.Text;
                    //materialLabel24.Text = "Cashier";
         
                    string a = materialLabel29.Text + "," + materialLabel25.Text + "," + materialLabel27.Text + "," + materialLabel23.Text + "," + materialLabel28.Text + "," + materialLabel26.Text + "," + materialLabel24.Text+",";
                    for (int i = 0; i < materialListView1.Items.Count; i++)
                    {
                        string id = "", qty = "";
                        ListViewItem item = materialListView1.Items[i];
                        id = item.SubItems[0].Text.ToString();
                        qty = item.SubItems[2].Text.ToString();
                        a += id + "@" + qty+ "#";                        
                    }
                    FileStream fs = new FileStream("TRX" + trxid + ".txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs);
                    ClearTextBox();
                    materialListView1.Items.Clear();
                    sw.WriteLine(a);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    DateTime asd = Convert.ToDateTime(materialLabel29.Text);
                    string abcdef = asd.ToShortDateString();
                    fs = new FileStream("TRX-INDEX.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sw = new StreamWriter(fs);

                    sw.WriteLine(abcdef + "," + materialLabel25.Text + "," + materialLabel27.Text + "," + materialLabel23.Text + "," + materialLabel24.Text);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    for (int i = 0; i < materialListView1.Items.Count; i++)
                    {
                        string id = "", qty = "";
                        int linecount = 1;
                        ListViewItem item = materialListView1.Items[i];
                        id = item.SubItems[0].Text.ToString();
                        qty = item.SubItems[2].Text.ToString();

                        object[] data = new object[10];
                        foreach (string line in File.ReadLines("ProductData.txt"))
                        {
                            data = line.Split(',');
                            if (data[0].Equals(id))
                            {
                                break;
                            }
                            else
                            {
                                linecount++;
                                continue;
                            }
                        }
                        string[] line_detect = File.ReadAllLines("ProductData.txt");
                        string[] line_specific = line_detect[linecount - 1].Split(',');
                        File.WriteAllText("ProductData.txt", File.ReadAllText("ProductData.txt").Replace(line_detect[linecount - 1], data[0]+","+data[1]+","+ (Convert.ToInt32(data[2]) - Convert.ToInt32(qty))+","+data[3]));
                    }
                }
                else
                {
                    label2.Visible = true;
                    label1.Visible = false;
                    panel1.Visible = false;
                }
            }
            
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            dynamic data = new dynamic[4];
            foreach(string line in File.ReadLines("CardData.txt"))
            {
                data = line.Split(',');
                if(textBox6.Text.Equals(data[0]))
                {
                    break;
                }
            }
            if(textBox6.Text.Equals(data[0]))
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    if ((Convert.ToInt32(textBox7.Text) >= Convert.ToInt32(textBox5.Text)) && textBox8.Text.Equals("Active"))
                    {
                        
                        panel1.Visible = true;
                        label1.Visible = true;
                        label2.Visible = false;
                        materialLabel29.Text = DateTime.Now.ToString();
                        materialLabel25.Text = "TRX"+trxid;
                        materialLabel27.Text = comboBox1.Text;
                        materialLabel23.Text = textBox5.Text;
                        materialLabel28.Text = textBox5.Text;
                        materialLabel26.Text = "0";
                        //materialLabel24.Text = "Cashier";
                        string a = materialLabel29.Text + "," + materialLabel25.Text + "," + materialLabel27.Text + "," + materialLabel23.Text + "," + materialLabel28.Text + "," + materialLabel26.Text + "," + materialLabel24.Text + ",";
                        for (int i = 0; i < materialListView1.Items.Count; i++)
                        {
                            string id = "", qty = "";
                            ListViewItem item = materialListView1.Items[i];
                            id = item.SubItems[0].Text.ToString();
                            qty = item.SubItems[2].Text.ToString();
                            a += id + "@" + qty + "#";
                        }
                        FileStream fs = new FileStream("TRX" + trxid + ".txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                        StreamWriter sw = new StreamWriter(fs);
                        ClearTextBox();
                        materialListView1.Items.Clear();
                        sw.WriteLine(a);
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        DateTime asd = Convert.ToDateTime(materialLabel29.Text);
                        string abcdef = asd.ToShortDateString();
                        fs = new FileStream("TRX-INDEX.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                        sw = new StreamWriter(fs);

                        sw.WriteLine(abcdef + "," + materialLabel25.Text + "," + materialLabel27.Text + "," + materialLabel23.Text + "," + materialLabel24.Text);
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                        for (int i = 0; i < materialListView1.Items.Count; i++)
                        {
                            string id = "", qty = "";
                            int linecount = 1;
                            ListViewItem item = materialListView1.Items[i];
                            id = item.SubItems[0].Text.ToString();
                            qty = item.SubItems[2].Text.ToString();

                            
                            foreach (string line in File.ReadLines("ProductData.txt"))
                            {
                                data = line.Split(',');
                                if (data[0].Equals(id))
                                {
                                    break;
                                }
                                else
                                {
                                    linecount++;
                                    continue;
                                }
                            }
                            string[] line_detect = File.ReadAllLines("ProductData.txt");
                            string[] line_specific = line_detect[linecount - 1].Split(',');
                            File.WriteAllText("ProductData.txt", File.ReadAllText("ProductData.txt").Replace(line_detect[linecount - 1], data[0] + "," + data[1] + "," + (Convert.ToInt32(data[2]) - Convert.ToInt32(qty)) + "," + data[3]));
                        }
                        int baris = 0;
                        dynamic nokartu = new dynamic[4];
                        foreach(string line in File.ReadLines("CardData.txt"))
                        {
                            nokartu = line.Split(',');
                            if(textBox6.Text.Equals(nokartu[0]))
                            {
                                break;
                            }
                            else
                            {
                                baris++;
                            }
                        }
                        if (textBox6.Text.Equals(nokartu[0]))
                        {
                            string[] line_detect = File.ReadAllLines("CardData.txt");
                            string[] line_specific = line_detect[baris].Split(',');
                            File.WriteAllText("CardData.txt", File.ReadAllText("CardData.txt").Replace(line_detect[baris], line_detect[baris].Replace(textBox7.Text, (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox5.Text)).ToString())));
                        }
                    }
                    else
                    {
                        label2.Visible = true;
                        label1.Visible = false;
                        panel1.Visible = false;
                    }
                }
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                materialFlatButton1.PerformClick();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                materialFlatButton2.PerformClick();
            }
        }
        
        private void materialCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            materialCheckBox4.Checked = false;
            if(materialCheckBox3.Checked)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }

        }

        private void materialCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            materialCheckBox3.Checked = false;
            if (materialCheckBox4.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                materialListView3.Items.Clear();
                dynamic dataidx = new dynamic[10];
                string[] split1 = new string[10];
                string[] split2 = new string[10];
                foreach (string line in File.ReadLines(textBox11.Text+".txt"))
                {
                    dataidx = line.Split(',');
                    split1 = dataidx[7].Split('#');
                    split1 = split1.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    foreach(string lines in split1)
                    {
                        split2 = lines.Split('@');
                        dynamic cekcekcek = new dynamic[5];
                        foreach(string garis in File.ReadLines("ProductData.txt"))
                        {
                            cekcekcek = garis.Split(',');
                            if(cekcekcek[0].Equals(split2[0]))
                            {
                                break;
                            }
                        }
                        string[] push = new string[4];
                        push[0] = cekcekcek[1];
                        push[1] = split2[1];
                        push[2] = (Convert.ToInt32(split2[1]) * Convert.ToInt32(cekcekcek[3])).ToString();
                        var listViewItem = new ListViewItem(push);
                        materialListView3.Items.Add(listViewItem);
                    }
                    //foreach(string[] produklist in split2)
                    //{
                    //    var listViewItem = new ListViewItem(produklist);
                    //    materialListView3.Items.Add(listViewItem);
                    //}
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if ((textBoxMin.Text == "") || (textBoxMin.Text == null))
            {
                textBoxMin.Text = "0";
            }
            else if ((textBoxMax.Text == "") || (textBoxMax.Text == null))
            {
                textBoxMax.Text = "0";
            }

            Item itm = (Item)comboSearch.SelectedItem;
            listViewSearchSort.Items.Clear();
            dynamic dataidx;
            if (comboSearch.SelectedIndex == 0)
            {
                foreach (string line in File.ReadLines("TRX-INDEX.txt"))
                {
                    dataidx = line.Split(',');
                    string date1 = dateTimePicker1.Value.ToShortDateString();
                    string date2 = dateTimePicker2.Value.ToShortDateString();
                    if ((Convert.ToDateTime(dataidx[0]) >= Convert.ToDateTime(date1)) && (Convert.ToDateTime(dataidx[0]) <= Convert.ToDateTime(date2)))
                    {
                        var listViewItem = new ListViewItem(dataidx);
                        listViewSearchSort.Items.Add(listViewItem);

                    }
                }
            }
            else if (comboSearch.SelectedIndex == 3)
            {
                foreach (string line in File.ReadLines("TRX-INDEX.txt"))
                {
                    dataidx = line.Split(',');
                    int min = Convert.ToInt32(textBoxMin.Text);
                    int max = Convert.ToInt32(textBoxMax.Text);
                    if ((Convert.ToInt32(dataidx[itm.Value]) > min) && (Convert.ToInt32(dataidx[itm.Value]) < max))
                    {
                        var listViewItem = new ListViewItem(dataidx);
                        listViewSearchSort.Items.Add(listViewItem);
                    }

                }

            }
            else
            {
                foreach (string line in File.ReadLines("TRX-INDEX.txt"))
                {
                    dataidx = line.Split(',');
                    if (dataidx[itm.Value] == textboxKeyword.Text)
                    {
                        var listViewItem = new ListViewItem(dataidx);
                        listViewSearchSort.Items.Add(listViewItem);
                    }

                }
            }

        }

        public void sortBtn_Click(object sender, EventArgs e)
        {

            if (listViewSearchSort.Items.Count > 0)
            {
                if (comboSrt.SelectedIndex == 0)
                {
                    string[] items = new string[listViewSearchSort.Items.Count];
                    for (int i = 0; i < listViewSearchSort.Items.Count; i++)
                    {
                        string a = "";
                        for (int b = 0; b < 5; b++)
                        {
                            if (b == 4)
                            {
                                a += listViewSearchSort.Items[i].SubItems[b].Text;
                            }
                            else
                            {
                                a += listViewSearchSort.Items[i].SubItems[b].Text + ",";
                            }
                        }
                        items[i] = a;
                    }
                    List<DataAsc> list = new List<DataAsc>();
                    for (int i = 0; i < items.Length; i++)
                    {
                        string a;
                        a = items[i];
                        dynamic b;
                        b = a.Split(',');

                        list.Add(new DataAsc() { Date = Convert.ToDateTime(b[0]), TransID = b[1].ToString(), Payment = b[2].ToString(), Price = Convert.ToInt32(b[3]), Cashier = b[4].ToString() });
                    }
                    Mergesort.sort<DataAsc>(ref list);
                    listViewSearchSort.Items.Clear();
                    foreach (var lists in list)
                    {
                        string a = Convert.ToString(lists);
                        dynamic b;
                        b = a.Split(',');
                        var listViewItem = new ListViewItem(b);
                        listViewSearchSort.Items.Add(listViewItem);
                    }
                }
                else
                {
                    string[] items = new string[listViewSearchSort.Items.Count];
                    for (int i = 0; i < listViewSearchSort.Items.Count; i++)
                    {
                        string a = "";
                        for (int b = 0; b < 5; b++)
                        {
                            if (b == 4)
                            {
                                a += listViewSearchSort.Items[i].SubItems[b].Text;
                            }
                            else
                            {
                                a += listViewSearchSort.Items[i].SubItems[b].Text + ",";
                            }
                        }
                        items[i] = a;
                    }
                    List<DataDesc> list = new List<DataDesc>();
                    for (int i = 0; i < items.Length; i++)
                    {
                        string a;
                        a = items[i];
                        dynamic b;
                        b = a.Split(',');

                        list.Add(new DataDesc() { Date = Convert.ToDateTime(b[0]), TransID = b[1].ToString(), Payment = b[2].ToString(), Price = Convert.ToInt32(b[3]), Cashier = b[4].ToString() });
                    }
                    Mergesort.sort<DataDesc>(ref list);
                    listViewSearchSort.Items.Clear();
                    foreach (var lists in list)
                    {
                        string a = Convert.ToString(lists);
                        dynamic b;
                        b = a.Split(',');
                        var listViewItem = new ListViewItem(b);
                        listViewSearchSort.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                MessageBox.Show("cant");
            }
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSearch.SelectedIndex == 0)
            {
                datepickerbox.Visible = true;
                keywordbox.Visible = false;
                pricebox.Visible = false;
            }
            else if (comboSearch.SelectedIndex == 3)
            {
                pricebox.Visible = true;
                datepickerbox.Visible = false;
                keywordbox.Visible = false;
            }
            else
            {
                pricebox.Visible = false;
                datepickerbox.Visible = false;
                keywordbox.Visible = true;
            }

        }
    }
}
