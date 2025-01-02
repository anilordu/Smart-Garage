namespace Akıllı_Garaj_Proje
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fan = new Label();
            fanBar = new TrackBar();
            isitici = new Label();
            isiticiBar = new TrackBar();
            branda = new Label();
            brandaBar = new TrackBar();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)fanBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)isiticiBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)brandaBar).BeginInit();
            SuspendLayout();
            // 
            // fan
            // 
            fan.AutoSize = true;
            fan.Location = new Point(115, 128);
            fan.Name = "fan";
            fan.Size = new Size(126, 25);
            fan.TabIndex = 0;
            fan.Text = "Fan Çalışmıyor";
            fan.Click += fan_Click;
            // 
            // fanBar
            // 
            fanBar.Location = new Point(115, 190);
            fanBar.Maximum = 3;
            fanBar.Name = "fanBar";
            fanBar.Size = new Size(250, 69);
            fanBar.TabIndex = 1;
            fanBar.Scroll += fanBar_Scroll;
            // 
            // isitici
            // 
            isitici.AutoSize = true;
            isitici.Location = new Point(115, 276);
            isitici.Name = "isitici";
            isitici.Size = new Size(138, 25);
            isitici.TabIndex = 2;
            isitici.Text = "Isıtıcı Çalışmıyor";
            isitici.Click += isitici_Click;
            // 
            // isiticiBar
            // 
            isiticiBar.Location = new Point(115, 324);
            isiticiBar.Maximum = 1;
            isiticiBar.Name = "isiticiBar";
            isiticiBar.Size = new Size(250, 69);
            isiticiBar.TabIndex = 1;
            isiticiBar.Scroll += isiticiBar_Scroll;
            // 
            // branda
            // 
            branda.AutoSize = true;
            branda.Location = new Point(495, 128);
            branda.Name = "branda";
            branda.Size = new Size(119, 25);
            branda.TabIndex = 4;
            branda.Text = "Branda Kapalı";
            branda.Click += branda_Click;
            // 
            // brandaBar
            // 
            brandaBar.Location = new Point(495, 190);
            brandaBar.Maximum = 2;
            brandaBar.Name = "brandaBar";
            brandaBar.Size = new Size(250, 69);
            brandaBar.TabIndex = 5;
            brandaBar.Scroll += brandaBar_Scroll;
            // 
            // button1
            // 
            button1.Location = new Point(821, 128);
            button1.Name = "button1";
            button1.Size = new Size(250, 140);
            button1.TabIndex = 6;
            button1.Text = "Fotoğraf Çek ve Mail Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(495, 85);
            label1.Name = "label1";
            label1.Size = new Size(171, 25);
            label1.TabIndex = 7;
            label1.Text = "Yağmur bekleniyor...";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 85);
            label2.Name = "label2";
            label2.Size = new Size(167, 25);
            label2.TabIndex = 8;
            label2.Text = "Sıcaklık Bekleniyor...";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(821, 85);
            label3.Name = "label3";
            label3.Size = new Size(240, 25);
            label3.TabIndex = 9;
            label3.Text = "Hareket Sensörü Bekleniyor...";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(821, 287);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 574);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(brandaBar);
            Controls.Add(branda);
            Controls.Add(isiticiBar);
            Controls.Add(isitici);
            Controls.Add(fanBar);
            Controls.Add(fan);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fanBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)isiticiBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)brandaBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fan;
        private TrackBar fanBar;
        private Label isitici;
        private TrackBar isiticiBar;
        private Label branda;
        private TrackBar brandaBar;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
