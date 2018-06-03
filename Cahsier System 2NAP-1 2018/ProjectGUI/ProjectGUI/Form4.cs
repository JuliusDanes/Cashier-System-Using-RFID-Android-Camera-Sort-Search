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
using MaterialSkin.Controls;
using MaterialSkin;

namespace ProjectGUI
{
    public partial class searchproform : MaterialForm
    {
        public static int dataindexA, dataindexB;
        public static dynamic[,] data;
        public searchproform()
        {
            InitializeComponent();
            searchcmbx.Items.Add(new ProductItem("Product ID", 0));
            searchcmbx.Items.Add(new ProductItem("Name", 1));
            searchcmbx.Items.Add(new ProductItem("Stock", 2));
            searchcmbx.Items.Add(new ProductItem("Price", 3));
            sortingcmbx.Items.Add(new ProductItem("Product ID", 0));
            sortingcmbx.Items.Add(new ProductItem("Name", 1));
            sortingcmbx.Items.Add(new ProductItem("Stock", 2));
            sortingcmbx.Items.Add(new ProductItem("Price", 3));
        }
        private class ProductItem
        {
            public string Name;
            public int Value;
            public ProductItem(string nama, int angka)
            {
                Name = nama; Value = angka;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        private void closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
            productdataform obj = new productdataform();
            obj.Show();
        }

        private void searchproform_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchcmbx.SelectedIndex == 0 || searchcmbx.SelectedIndex == 1)
            {
                grupboxkeyword.Visible = true;
                grupboxvalue.Visible = false;
            }
            else
            {
                grupboxkeyword.Visible = false;
                grupboxvalue.Visible = true;
            }

            if (searchcmbx.SelectedIndex == 0)
                dataindexB = 0;
            else if (searchcmbx.SelectedIndex == 1)
                dataindexB = 1;
            else if (searchcmbx.SelectedIndex == 2)
                dataindexB = 2;
            else if (searchcmbx.SelectedIndex == 3)
                dataindexB = 3;
        }

        //LINEAR SEARCH
        private void searchbtn_Click(object sender, EventArgs e)
        {
            //Sort();
            if ((minimumtxbx.Text == "") || (minimumtxbx.Text == null))
            {
                minimumtxbx.Text = "0";
            }
            else if ((maximumtxbx.Text == "") || (maximumtxbx.Text == null))
            {
                maximumtxbx.Text = "0";
            }

            ProductItem itm = (ProductItem)searchcmbx.SelectedItem;
            dataGridView1.Rows.Clear();
            dynamic dataindexs;
            if (searchcmbx.SelectedIndex == 0 || searchcmbx.SelectedIndex == 1)
            {
                foreach (string line in File.ReadLines("ProductData.txt"))
                {
                    dataindexs = line.Split(',');
                    if (dataindexs[itm.Value].Contains(keywordtxbx.Text))
                        dataGridView1.Rows.Add(dataindexs);
                }
            }
            else
            {
                foreach (string line in File.ReadLines("ProductData.txt"))
                {
                    dataindexs = line.Split(',');
                    int min = Convert.ToInt32(minimumtxbx.Text);
                    int max = Convert.ToInt32(maximumtxbx.Text);
                    if ((Convert.ToInt32(dataindexs[itm.Value]) > min) && (Convert.ToInt32(dataindexs[itm.Value]) < max))
                        dataGridView1.Rows.Add(dataindexs);
                }
            }
        }

        // SELECTION SORT
        private static bool compData(dynamic a, dynamic b, Type Type)
        {
            bool cond = false;
            if (Type == typeof(string))
            {
                int c = 0;
                Sort:
                if (a.ToLower()[c] != b.ToLower()[c])
                {
                    if (a.ToLower()[c] > b.ToLower()[c])
                        cond = true;
                    else
                        cond = false;
                }
                else if ((a.Length > b.Length) && (b.Length == c + 1))
                    cond = true;
                else if ((a.Length <= b.Length) && (a.Length == c + 1))
                    cond = false;
                else
                {
                    c++;
                    goto Sort;
                }
            }
            else
            {
                if (a > b)
                    cond = true;
            }
            return cond;
        }

        private static void Sort()
        {
            dynamic prodatax = File.ReadAllLines("ProductData.txt"), prodatay = prodatax[0].Split(',');
            data = new dynamic[prodatax.Length, prodatay.Length];
            for (int i = 0; i < prodatax.Length; i++)
            {
                prodatay = prodatax[i].Split(',');
                for (int j = 0; j < prodatay.Length; j++)
                {
                    if (j == 1)
                        data[i, j] = prodatay[j];
                    else if (j == 0)
                        data[i, 0] = Convert.ToInt64(prodatay[j]);
                    else if (j == 2)
                        data[i, 2] = Convert.ToInt64(prodatay[j]);
                    else
                        data[i, 3] = Convert.ToInt64(prodatay[j]);
                }
            }

            for (int i = 0; i < data.GetLength(0) - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < data.GetLength(0); j++)
                {
                    if (compData(data[minIdx, dataindexA], data[j, dataindexA], data[j, dataindexA].GetType()))
                        minIdx = j;
                }

                if (minIdx != i) //Swap
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        dynamic[,] temp = new dynamic[data.GetLength(0), data.GetLength(1)];
                        temp[i, j] = data[i, j];
                        data[i, j] = data[minIdx, j];
                        data[minIdx, j] = temp[i, j];
                    }
                }
            }
        }

        private void ascbtn_Click(object sender, EventArgs e)
        {
            Sort();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < data.GetLength(0); i++)
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
        }

        private void descbtn_Click(object sender, EventArgs e)
        {
            Sort();
            dataGridView1.Rows.Clear();
            for (int i = data.GetLength(0) - 1; i >= 0; i--)
                dataGridView1.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
        }


        private void cmbx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Sort();
            if (sortingcmbx.SelectedIndex == 0)
                dataindexA = 0;
            else if (sortingcmbx.SelectedIndex == 1)
                dataindexA = 1;
            else if (sortingcmbx.SelectedIndex == 2)
                dataindexA = 2;
            else if (sortingcmbx.SelectedIndex == 3)
                dataindexA = 3;
        }
    }

}
