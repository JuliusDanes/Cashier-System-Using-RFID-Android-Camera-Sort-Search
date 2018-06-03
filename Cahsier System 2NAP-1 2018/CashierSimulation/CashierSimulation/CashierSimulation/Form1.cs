using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace CashierSimulation
{
    public partial class Form1 : Form
    {
        public static string path = @"" + Environment.CurrentDirectory + "\\" + "EmployeeData.txt";

        static int ActvMenu, idxDataX, idxDataY, valSeaM, valSortM, valAscDesc;
        static dynamic keyW;
        static dynamic[,] data;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close(); ///close form
        }


        static int EIDNum(string value)
        {
            return int.Parse(value.Substring(value.Length - 4)); ;
        }

        private void tbxSearch_Enter(object sender, EventArgs e)
        {
            if (tbxSearch.Text == "Search")
                tbxSearch.ResetText();
        }

        private void tbxSearch_Leave(object sender, EventArgs e)
        {
            if (tbxSearch.Text.Length == 0)
                tbxSearch.Text = "Search";
        }

        private void dwnDOB_onValueChanged(object sender, EventArgs e)
        {
            lblDOB.Visible = false;
            keyW = dwnDOB.Value;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (sideMenu.Width == 80)
            {
                ///EXPAND
                /// 1. Expand the panel
                /// 2. Show logo

                sideMenu.Visible = false;
                sideMenu.Width = 280;
                PanelAnimatorShow.ShowSync(sideMenu);
                LogoAnimator.ShowSync(icon);
                dgvEmp.Visible = false;
                TCMainEmp.SelectedIndex = 0;
            }
            else
            {
                ///MINIMIZE
                /// 1. Hide the logo
                /// 2. Slide the panel
                LogoAnimator.HideSync(icon);
                sideMenu.Visible = false;
                sideMenu.Width = 80;
                PanelAnimatorHide.ShowSync(sideMenu);
                dgvEmp.Visible = true;
                TCMainEmp.SelectedIndex = 1;
                dwnSortBy.selectedIndex = 0;
                tbxSearch.Visible = true;
                dwnDOB.Visible = lblDOB.Visible = false;
            }
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            ActvMenu = 1; /// 1 => Add Employee
            ucAddUpdateDelEmp.ActiveMenu(ActvMenu);
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            ActvMenu = 2; /// 2 => Update Emfployee
            ucAddUpdateDelEmp.ActiveMenu(ActvMenu);
        }

        private void btnDelEmp_Click(object sender, EventArgs e)
        {
            ActvMenu = 3; /// 3 => Delete Employee
            ucAddUpdateDelEmp.ActiveMenu(ActvMenu);
        }

        private void TCMainEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgEmp.Rows.Clear();
            foreach (var Celldataay in File.ReadAllLines(path))
            {
                var cell = Celldataay.Split('#');
                dgEmp.Rows.Add(cell);
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dwnDOB.Value = DateTime.Now.Date;
            Set();
        }

        private void rbtnLinear_CheckedChanged(object sender, EventArgs e)
        {
            Set();
        }

        private void rbtnBinary_CheckedChanged(object sender, EventArgs e)
        {
            Set();
        }

        private void SlidSortM_ValueChanged(object sender, EventArgs e)
        {
            Set();
        }

        private void lblBubble_Click(object sender, EventArgs e)
        {
            SlidSortM.Value = 0;
        }

        private void lblSelection_Click(object sender, EventArgs e)
        {
            SlidSortM.Value = 25;
        }

        private void lblInsertion_Click(object sender, EventArgs e)
        {
            SlidSortM.Value = 50;
        }

        private void lblShell_Click(object sender, EventArgs e)
        {
            SlidSortM.Value = 75;
        }

        private void lblQuick_Click(object sender, EventArgs e)
        {
            SlidSortM.Value = 100;
        }

        private void lblAsc_Click(object sender, EventArgs e)
        {
            SwtAscDesc.Value = false;
            lblAsc.Visible = false;
        }

        private void lblDesc_Click(object sender, EventArgs e)
        {
            SwtAscDesc.Value = true;
            lblAsc.Visible = true;
        }

        void Set()
        {
            idxDataX = dwnSortBy.selectedIndex;
            idxDataY = dwnSearchBy.selectedIndex;

            if (idxDataY == 4) //DOB
                keyW = dwnDOB.Value; //DateTime
            else
                keyW = tbxSearch.Text; //String

            if (rbtnLinear.Checked == true)
            {
                valSeaM = 1;
                rbtnBinary.Checked = false;
            }
            else
            {
                valSeaM = 2;
                rbtnLinear.Checked = false;
            }

            if ((SlidSortM.Value >= 0) && (SlidSortM.Value < 12))
                valSortM = 1;
            else if ((SlidSortM.Value >= 12) && (SlidSortM.Value < 37))
                valSortM = 2;
            else if ((SlidSortM.Value >= 37) && (SlidSortM.Value < 62))
                valSortM = 3;
            else if ((SlidSortM.Value >= 62) && (SlidSortM.Value < 87))
                valSortM = 4;
            else if ((SlidSortM.Value >= 87) && (SlidSortM.Value < 100))
                valSortM = 5;

            if (SwtAscDesc.Value == true)
                valAscDesc = 1;
            else
                valAscDesc = 0;
        }


        private void dwnSearchBy_onItemSelected(object sender, EventArgs e)
        {
            if (dwnSearchBy.selectedIndex != -1)
                lblSearchBy.Visible = false;
            else
                lblSearchBy.Visible = true;

            if (dwnSearchBy.selectedIndex == 4)
            {
                tbxSearch.Visible = dwnDOB.Visible = false;
                lblDOB.Visible = false;
                DOBAnimation.ShowSync(dwnDOB);
                DOBAnimation.ShowSync(lblDOB);
            }
            else
            {
                tbxSearch.Visible = false;
                dwnDOB.Visible = lblDOB.Visible = false;
                SearchAnimation.ShowSync(tbxSearch);
            }

            Set();
        }

        private void dwnSortBy_onItemSelected(object sender, EventArgs e)
        {
            if (dwnSortBy.selectedIndex != -1)
                lblSortBy.Visible = false;
            else
                lblSortBy.Visible = true;

            Set();
            Drive();
            Display();
        }

        private static void Drive()
        {
            /// Drive in Array
            dynamic datai = File.ReadAllLines(path), dataj = datai[0].Split('#');
            data = new dynamic[datai.Length, dataj.Length];
            for (int i = 0; i < datai.Length; i++)
            {
                dataj = datai[i].Split('#');
                for (int j = 0; j < dataj.Length; j++)
                {
                    if (j != 4)
                        data[i, j] = dataj[j];
                    else
                        data[i, j] = DateTime.Parse(dataj[j]);
                }
            }

            if (valSortM == 1)
                BubbleS();
            else if (valSortM == 2)
                SelectionS();
            else if (valSortM == 3)
                InsertionS();
            else if (valSortM == 4)
                ShellS();
            else if (valSortM == 5)
                QuickS(0, data.GetLength(0) - 1);
        }

        private static bool compData(dynamic d1, dynamic d2, Type tp)
        {
            bool cond = false;
            if (tp == typeof(string)) // for String
            {
                int c = 0;
                Sort:
                if (d1.ToLower()[c] != d2.ToLower()[c])
                {
                    if (d1.ToLower()[c] > d2.ToLower()[c])
                        cond = true;
                    else
                        cond = false;
                }
                else if ((d1.Length > d2.Length) && (d2.Length == c + 1))
                    cond = true;
                else if ((d1.Length <= d2.Length) && (d1.Length == c + 1))
                    cond = false;
                else
                {
                    c++;
                    goto Sort;
                }
            }
            else // for Int || DateTime
            {
                if (d1 > d2)
                    return true;
            }
            return cond;
        }

        private static void Swap(int x, int y)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                dynamic temp = data[x, j];
                data[x, j] = data[y, j];
                data[y, j] = temp;
            }
        }

        private static void BubbleS()
        {
            for (int i = 1; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(0) - 1; j++)
                {
                    if (compData(data[j, idxDataX], data[j + 1, idxDataX], data[j, idxDataX].GetType()))
                        Swap(j, j + 1);
                }
            }
        }

        private static void SelectionS()
        {
            /// Selection Sort
            for (int i = 0; i < data.GetLength(0) - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < data.GetLength(0); j++)
                {
                    if (compData(data[minIdx, idxDataX], data[j, idxDataX], data[j, idxDataX].GetType()))
                        minIdx = j;
                }

                if (minIdx != i) //Swap
                    Swap(i, minIdx);
            }
        }

        private static void InsertionS()
        {
            /// Insertion Sort
            for (int i = 1; i < data.GetLength(0); i++)
            {
                for (int k = i; k > 0; k--)
                {
                    if (compData(data[k - 1, idxDataX], data[k, idxDataX], data[k, idxDataX].GetType()))
                        Swap(k - 1, k);
                    else
                        break;
                }
            }
        }

        private static void ShellS()
        {
            /// Shell Sort
            for (int mid = data.GetLength(0) / 2; mid > 0; mid /= 2)
            {
                for (int i = 0; i + mid < data.GetLength(0); i++)
                {
                    int ub = i + mid; // Upperbound     // lb lowerbound or range =>> (ub - mid)
                    while ((ub - mid >= 0) && (compData(data[ub - mid, idxDataX], data[ub, idxDataX], data[ub - mid, idxDataX].GetType())))
                    {
                        Swap(ub, ub - mid);
                        ub -= mid;
                    }
                }
            }
        }

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void tbxSearch_OnValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private static void QuickS(int low, int high)
        {
            /// Quick Sort
            if (low > high)
                return;
            int i = low + 1, j = high;
            dynamic pivot = data[low, idxDataX];

            while (i <= j)
            {
                while ((i <= high) && (compData(pivot, data[i, idxDataX], data[i, idxDataX].GetType()) || (pivot == data[i, idxDataX])))
                    i++;
                while ((compData(data[j, idxDataX], pivot, data[j, idxDataX].GetType())) && (j >= low))
                    j--;
                if (i < j)
                    Swap(i, j);
            }
            if (low < j)
                Swap(low, j);

            QuickS(low, j - 1); // Recursive
            QuickS(j + 1, high); // Recursive
        }

        private void SwtAscDesc_Click(object sender, EventArgs e)
        {
            if (SwtAscDesc.Value == true)
            {
                lblAsc.Visible = true; lblDesc.Visible = false;
            }
            else
            {
                lblAsc.Visible = false; lblDesc.Visible = true;
            }
            Set();
            Drive();
            Display();
        }

        private void btnSearchV_Click(object sender, EventArgs e)
        {
            Search();
        }

        void Search()
        {
            Set();
            Drive();
            if (!string.IsNullOrWhiteSpace(keyW.ToString()))
            {
                //Linear Search
                if (valSeaM == 1)
                {
                    Display();
                }
                //Binary Search
                else
                {
                    idxDataX = idxDataY;
                    Drive();
                    int ln = data.GetLength(0);
                    int lb = 0, ub = ln - 1, mid = (lb + ub) / 2;

                    if (idxDataY == 0)
                        EIDNum(data[mid, idxDataY]);
                    while ((!data[mid, idxDataY].ToString().ToLower().Contains(keyW.ToString().ToLower())) && (lb <= ub))
                    {
                        if (compData(keyW, data[mid, idxDataY], data[mid, idxDataY].GetType()))
                            lb = mid + 1;
                        else
                            ub = mid - 1;
                        mid = (lb + ub) / 2;
                        if (idxDataY == 0)
                            EIDNum(data[mid, idxDataY]);
                    }

                    if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && ((keyW.GetType() == typeof(string)) && (((idxDataY != 2) && (data[mid, idxDataY].ToLower().Contains(keyW.ToLower()))) ^ ((idxDataY == 2) && (data[mid, idxDataY].ToLower().Contains(keyW.ToLower())))))) { }
                    else if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && (data[mid, idxDataY] == keyW)) { }
                    else if ((string.IsNullOrWhiteSpace(keyW.ToString())) || ((keyW.GetType() == typeof(string) && (keyW == "Search"))) || ((keyW.GetType() == typeof(DateTime) && (keyW == DateTime.Now.Date)))) { }
                    else
                    {
                        dgEmp.Rows.Clear(); MessageBox.Show(dwnSearchBy.selectedValue + " Keyword \n\"" + keyW.ToString() + "\"\n\nNot Found"); return;
                    }
                    Display();
                }
            }
        }

        void Display()
        {
            dgEmp.Rows.Clear();
            if (valAscDesc == 1) //Asc
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && ((keyW.GetType() == typeof(string)) && (((idxDataY != 2) && (data[i, idxDataY].ToLower().Contains(keyW.ToLower()))) ^ ((idxDataY == 2) && (data[i, idxDataY].ToLower().Equals(keyW.ToLower())))))) { }
                    else if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && (data[i, idxDataY] == keyW)) { }
                    else if ((string.IsNullOrWhiteSpace(keyW.ToString())) || ((keyW.GetType() == typeof(string) && (keyW == "Search"))) || ((keyW.GetType() == typeof(DateTime) && (keyW == DateTime.Now.Date)))) { }
                    else continue;
                    dgEmp.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4].ToShortDateString(), data[i, 5], data[i, 6], data[i, 7], data[i, 8], data[i, 9]);
                }
            }
            else //Desc
            {
                for (int i = data.GetLength(0) - 1; i >= 0; i--)
                {
                    if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && ((keyW.GetType() == typeof(string)) && (((idxDataY != 2) && (data[i, idxDataY].ToLower().Contains(keyW.ToLower()))) ^ ((idxDataY == 2) && (data[i, idxDataY].ToLower().Equals(keyW.ToLower())))))) { }
                    else if ((!string.IsNullOrWhiteSpace(keyW.ToString())) && (data[i, idxDataY] == keyW)) { }
                    else if ((string.IsNullOrWhiteSpace(keyW.ToString())) || ((keyW.GetType() == typeof(string) && (keyW == "Search"))) || ((keyW.GetType() == typeof(DateTime) && (keyW == DateTime.Now.Date)))) { }
                    else continue;
                    dgEmp.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4].ToShortDateString(), data[i, 5], data[i, 6], data[i, 7], data[i, 8], data[i, 9]);
                }
            }

            if (dgEmp.RowCount == 1)
                MessageBox.Show(dwnSearchBy.selectedValue + " Keyword \n\"" + keyW.ToString() + "\"\n\nNot Found");
        }
    }
}