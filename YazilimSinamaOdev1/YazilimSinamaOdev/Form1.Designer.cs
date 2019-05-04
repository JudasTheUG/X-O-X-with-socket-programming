namespace YazilimSinamaOdev
{
    partial class GirisEkrani
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
            this.btnPvC = new System.Windows.Forms.Button();
            this.btnPvP = new System.Windows.Forms.Button();
            this.btnPZ = new System.Windows.Forms.Button();
            this.btnLP = new System.Windows.Forms.Button();
            this.btnLPZ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPvC
            // 
            this.btnPvC.Location = new System.Drawing.Point(209, 71);
            this.btnPvC.Name = "btnPvC";
            this.btnPvC.Size = new System.Drawing.Size(174, 39);
            this.btnPvC.TabIndex = 0;
            this.btnPvC.Text = "Bilgisayara Karşı Modu";
            this.btnPvC.UseVisualStyleBackColor = true;
            this.btnPvC.Click += new System.EventHandler(this.btnPvC_Click);
            // 
            // btnPvP
            // 
            this.btnPvP.Location = new System.Drawing.Point(209, 130);
            this.btnPvP.Name = "btnPvP";
            this.btnPvP.Size = new System.Drawing.Size(174, 39);
            this.btnPvP.TabIndex = 1;
            this.btnPvP.Text = "Aynı Ekran PvP Modu";
            this.btnPvP.UseVisualStyleBackColor = true;
            this.btnPvP.Click += new System.EventHandler(this.btnPvP_Click);
            // 
            // btnPZ
            // 
            this.btnPZ.Location = new System.Drawing.Point(209, 186);
            this.btnPZ.Name = "btnPZ";
            this.btnPZ.Size = new System.Drawing.Size(174, 39);
            this.btnPZ.TabIndex = 2;
            this.btnPZ.Text = "PvP Zaman Modu ";
            this.btnPZ.UseVisualStyleBackColor = true;
            this.btnPZ.Click += new System.EventHandler(this.btnPZ_Click);
            // 
            // btnLP
            // 
            this.btnLP.Location = new System.Drawing.Point(209, 240);
            this.btnLP.Name = "btnLP";
            this.btnLP.Size = new System.Drawing.Size(174, 39);
            this.btnLP.TabIndex = 3;
            this.btnLP.Text = "LAN PvP Modu";
            this.btnLP.UseVisualStyleBackColor = true;
            this.btnLP.Click += new System.EventHandler(this.btnLP_Click);
            // 
            // btnLPZ
            // 
            this.btnLPZ.Location = new System.Drawing.Point(209, 295);
            this.btnLPZ.Name = "btnLPZ";
            this.btnLPZ.Size = new System.Drawing.Size(174, 39);
            this.btnLPZ.TabIndex = 4;
            this.btnLPZ.Text = "LAN PvP Zaman Modu";
            this.btnLPZ.UseVisualStyleBackColor = true;
            this.btnLPZ.Click += new System.EventHandler(this.btnLPZ_Click);
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 408);
            this.Controls.Add(this.btnLPZ);
            this.Controls.Add(this.btnLP);
            this.Controls.Add(this.btnPZ);
            this.Controls.Add(this.btnPvP);
            this.Controls.Add(this.btnPvC);
            this.Name = "GirisEkrani";
            this.Text = "X-O-X Oyununa Hoşgeldiniz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GirisEkrani_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPvC;
        private System.Windows.Forms.Button btnPvP;
        private System.Windows.Forms.Button btnPZ;
        private System.Windows.Forms.Button btnLP;
        private System.Windows.Forms.Button btnLPZ;
    }
}

