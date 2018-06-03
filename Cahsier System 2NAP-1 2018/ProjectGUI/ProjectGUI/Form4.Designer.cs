namespace ProjectGUI
{
    partial class searchproform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchproform));
            this.closebutton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchcmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grupboxkeyword = new System.Windows.Forms.GroupBox();
            this.keywordtxbx = new System.Windows.Forms.TextBox();
            this.grupboxvalue = new System.Windows.Forms.GroupBox();
            this.maximumtxbx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.minimumtxbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchbtn = new System.Windows.Forms.Button();
            this.descbtn = new System.Windows.Forms.Button();
            this.ascbtn = new System.Windows.Forms.Button();
            this.sortingcmbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grupboxkeyword.SuspendLayout();
            this.grupboxvalue.SuspendLayout();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.BackColor = System.Drawing.Color.Red;
            this.closebutton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebutton.ForeColor = System.Drawing.SystemColors.Info;
            this.closebutton.Location = new System.Drawing.Point(155, 302);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(94, 35);
            this.closebutton.TabIndex = 21;
            this.closebutton.Text = "CLOSE";
            this.closebutton.UseVisualStyleBackColor = false;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPro,
            this.ProName,
            this.Stock,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(398, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(490, 195);
            this.dataGridView1.TabIndex = 20;
            // 
            // IDPro
            // 
            this.IDPro.HeaderText = "Product ID";
            this.IDPro.Name = "IDPro";
            // 
            // ProName
            // 
            this.ProName.HeaderText = "Name";
            this.ProName.Name = "ProName";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(911, 288);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // searchcmbx
            // 
            this.searchcmbx.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchcmbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchcmbx.FormattingEnabled = true;
            this.searchcmbx.Location = new System.Drawing.Point(174, 79);
            this.searchcmbx.Name = "searchcmbx";
            this.searchcmbx.Size = new System.Drawing.Size(201, 21);
            this.searchcmbx.TabIndex = 23;
            this.searchcmbx.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "SEARCH BY";
            // 
            // grupboxkeyword
            // 
            this.grupboxkeyword.Controls.Add(this.keywordtxbx);
            this.grupboxkeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupboxkeyword.Location = new System.Drawing.Point(16, 106);
            this.grupboxkeyword.Name = "grupboxkeyword";
            this.grupboxkeyword.Size = new System.Drawing.Size(359, 102);
            this.grupboxkeyword.TabIndex = 24;
            this.grupboxkeyword.TabStop = false;
            this.grupboxkeyword.Text = "keyword";
            this.grupboxkeyword.Visible = false;
            // 
            // keywordtxbx
            // 
            this.keywordtxbx.Location = new System.Drawing.Point(19, 45);
            this.keywordtxbx.Name = "keywordtxbx";
            this.keywordtxbx.Size = new System.Drawing.Size(307, 26);
            this.keywordtxbx.TabIndex = 2;
            // 
            // grupboxvalue
            // 
            this.grupboxvalue.Controls.Add(this.maximumtxbx);
            this.grupboxvalue.Controls.Add(this.label6);
            this.grupboxvalue.Controls.Add(this.minimumtxbx);
            this.grupboxvalue.Controls.Add(this.label5);
            this.grupboxvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupboxvalue.Location = new System.Drawing.Point(16, 106);
            this.grupboxvalue.Name = "grupboxvalue";
            this.grupboxvalue.Size = new System.Drawing.Size(359, 102);
            this.grupboxvalue.TabIndex = 7;
            this.grupboxvalue.TabStop = false;
            this.grupboxvalue.Text = "value";
            this.grupboxvalue.Visible = false;
            // 
            // maximumtxbx
            // 
            this.maximumtxbx.Location = new System.Drawing.Point(115, 62);
            this.maximumtxbx.Name = "maximumtxbx";
            this.maximumtxbx.Size = new System.Drawing.Size(211, 26);
            this.maximumtxbx.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "MAXIMUM";
            // 
            // minimumtxbx
            // 
            this.minimumtxbx.Location = new System.Drawing.Point(115, 24);
            this.minimumtxbx.Name = "minimumtxbx";
            this.minimumtxbx.Size = new System.Drawing.Size(211, 26);
            this.minimumtxbx.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "MINIMUM";
            // 
            // searchbtn
            // 
            this.searchbtn.BackColor = System.Drawing.Color.Green;
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchbtn.Location = new System.Drawing.Point(16, 214);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(359, 30);
            this.searchbtn.TabIndex = 25;
            this.searchbtn.Text = "SEARCH";
            this.searchbtn.UseVisualStyleBackColor = false;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // descbtn
            // 
            this.descbtn.BackColor = System.Drawing.Color.Yellow;
            this.descbtn.FlatAppearance.BorderSize = 0;
            this.descbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.descbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descbtn.Location = new System.Drawing.Point(398, 307);
            this.descbtn.Name = "descbtn";
            this.descbtn.Size = new System.Drawing.Size(233, 30);
            this.descbtn.TabIndex = 26;
            this.descbtn.Text = "Descending";
            this.descbtn.UseVisualStyleBackColor = false;
            this.descbtn.Click += new System.EventHandler(this.descbtn_Click);
            // 
            // ascbtn
            // 
            this.ascbtn.BackColor = System.Drawing.Color.Yellow;
            this.ascbtn.FlatAppearance.BorderSize = 0;
            this.ascbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ascbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ascbtn.Location = new System.Drawing.Point(655, 307);
            this.ascbtn.Name = "ascbtn";
            this.ascbtn.Size = new System.Drawing.Size(233, 30);
            this.ascbtn.TabIndex = 27;
            this.ascbtn.Text = "Ascending";
            this.ascbtn.UseVisualStyleBackColor = false;
            this.ascbtn.Click += new System.EventHandler(this.ascbtn_Click);
            // 
            // sortingcmbx
            // 
            this.sortingcmbx.Cursor = System.Windows.Forms.Cursors.Default;
            this.sortingcmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortingcmbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sortingcmbx.FormattingEnabled = true;
            this.sortingcmbx.Location = new System.Drawing.Point(543, 277);
            this.sortingcmbx.Name = "sortingcmbx";
            this.sortingcmbx.Size = new System.Drawing.Size(345, 21);
            this.sortingcmbx.TabIndex = 29;
            this.sortingcmbx.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(394, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "SEARCH BY";
            // 
            // searchproform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(900, 350);
            this.Controls.Add(this.grupboxkeyword);
            this.Controls.Add(this.grupboxvalue);
            this.Controls.Add(this.sortingcmbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ascbtn);
            this.Controls.Add(this.descbtn);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.searchcmbx);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "searchproform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEARCH PRODUCT";
            this.Load += new System.EventHandler(this.searchproform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grupboxkeyword.ResumeLayout(false);
            this.grupboxkeyword.PerformLayout();
            this.grupboxvalue.ResumeLayout(false);
            this.grupboxvalue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox searchcmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grupboxkeyword;
        private System.Windows.Forms.TextBox keywordtxbx;
        private System.Windows.Forms.GroupBox grupboxvalue;
        private System.Windows.Forms.TextBox maximumtxbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox minimumtxbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Button descbtn;
        private System.Windows.Forms.Button ascbtn;
        private System.Windows.Forms.ComboBox sortingcmbx;
        private System.Windows.Forms.Label label2;
    }
}