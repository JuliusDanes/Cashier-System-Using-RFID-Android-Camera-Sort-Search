﻿namespace ProjectGUI
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.empbutton = new System.Windows.Forms.Button();
            this.probutton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exitbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // empbutton
            // 
            this.empbutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.empbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.empbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.empbutton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empbutton.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.empbutton.Location = new System.Drawing.Point(12, 229);
            this.empbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.empbutton.Name = "empbutton";
            this.empbutton.Size = new System.Drawing.Size(421, 57);
            this.empbutton.TabIndex = 0;
            this.empbutton.Text = "EMPLOYEE DATA";
            this.empbutton.UseVisualStyleBackColor = false;
            this.empbutton.Click += new System.EventHandler(this.empbutton_Click);
            // 
            // probutton
            // 
            this.probutton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.probutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.probutton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probutton.Location = new System.Drawing.Point(467, 229);
            this.probutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.probutton.Name = "probutton";
            this.probutton.Size = new System.Drawing.Size(421, 57);
            this.probutton.TabIndex = 1;
            this.probutton.Text = "PRODUCT DATA";
            this.probutton.UseVisualStyleBackColor = false;
            this.probutton.Click += new System.EventHandler(this.probutton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.BackColor = System.Drawing.Color.Red;
            this.exitbutton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.ForeColor = System.Drawing.SystemColors.Info;
            this.exitbutton.Location = new System.Drawing.Point(448, 357);
            this.exitbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(110, 51);
            this.exitbutton.TabIndex = 13;
            this.exitbutton.Text = "EXIT";
            this.exitbutton.UseVisualStyleBackColor = false;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(400, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 158);
            this.label1.TabIndex = 16;
            this.label1.Text = "#";
            // 
            // exitbtn
            // 
            this.exitbtn.BackColor = System.Drawing.Color.Red;
            this.exitbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.SystemColors.Info;
            this.exitbtn.Location = new System.Drawing.Point(411, 303);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(94, 35);
            this.exitbtn.TabIndex = 17;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(900, 350);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.probutton);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.empbutton);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Mistral", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUPER USER";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button empbutton;
        private System.Windows.Forms.Button probutton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitbtn;
    }
}

