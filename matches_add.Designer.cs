namespace football
{
    partial class matches_add
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_team2 = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_date = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_team1 = new System.Windows.Forms.ComboBox();
            this.textBox_team2_score = new System.Windows.Forms.TextBox();
            this.comboBox_referee = new System.Windows.Forms.ComboBox();
            this.textBox_team1_score = new System.Windows.Forms.TextBox();
            this.textBox_viewers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::football.Properties.Resources.button_color4;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1301, 100);
            this.panel3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(699, 53);
            this.label4.TabIndex = 18;
            this.label4.Text = "Матчи - добавление";
            // 
            // comboBox_team2
            // 
            this.comboBox_team2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.comboBox_team2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_team2.ForeColor = System.Drawing.Color.White;
            this.comboBox_team2.FormattingEnabled = true;
            this.comboBox_team2.Items.AddRange(new object[] {
            "male",
            "female"});
            this.comboBox_team2.Location = new System.Drawing.Point(719, 80);
            this.comboBox_team2.Name = "comboBox_team2";
            this.comboBox_team2.Size = new System.Drawing.Size(349, 37);
            this.comboBox_team2.TabIndex = 82;
            this.comboBox_team2.TabStop = false;
            // 
            // maskedTextBox_date
            // 
            this.maskedTextBox_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.maskedTextBox_date.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_date.ForeColor = System.Drawing.Color.White;
            this.maskedTextBox_date.Location = new System.Drawing.Point(205, 168);
            this.maskedTextBox_date.Mask = "0000-00-00";
            this.maskedTextBox_date.Name = "maskedTextBox_date";
            this.maskedTextBox_date.Size = new System.Drawing.Size(177, 36);
            this.maskedTextBox_date.TabIndex = 81;
            this.maskedTextBox_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.button1.BackgroundImage = global::football.Properties.Resources.button_color4;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(352, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 42);
            this.button1.TabIndex = 76;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_team1
            // 
            this.comboBox_team1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.comboBox_team1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_team1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_team1.ForeColor = System.Drawing.Color.White;
            this.comboBox_team1.FormattingEnabled = true;
            this.comboBox_team1.Location = new System.Drawing.Point(205, 80);
            this.comboBox_team1.Name = "comboBox_team1";
            this.comboBox_team1.Size = new System.Drawing.Size(349, 37);
            this.comboBox_team1.TabIndex = 75;
            this.comboBox_team1.TabStop = false;
            // 
            // textBox_team2_score
            // 
            this.textBox_team2_score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.textBox_team2_score.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_team2_score.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_team2_score.ForeColor = System.Drawing.Color.White;
            this.textBox_team2_score.Location = new System.Drawing.Point(654, 80);
            this.textBox_team2_score.Multiline = true;
            this.textBox_team2_score.Name = "textBox_team2_score";
            this.textBox_team2_score.Size = new System.Drawing.Size(48, 31);
            this.textBox_team2_score.TabIndex = 85;
            // 
            // comboBox_referee
            // 
            this.comboBox_referee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.comboBox_referee.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_referee.ForeColor = System.Drawing.Color.White;
            this.comboBox_referee.FormattingEnabled = true;
            this.comboBox_referee.Location = new System.Drawing.Point(205, 124);
            this.comboBox_referee.Name = "comboBox_referee";
            this.comboBox_referee.Size = new System.Drawing.Size(349, 37);
            this.comboBox_referee.TabIndex = 86;
            this.comboBox_referee.TabStop = false;
            // 
            // textBox_team1_score
            // 
            this.textBox_team1_score.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.textBox_team1_score.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_team1_score.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_team1_score.ForeColor = System.Drawing.Color.White;
            this.textBox_team1_score.Location = new System.Drawing.Point(577, 80);
            this.textBox_team1_score.Multiline = true;
            this.textBox_team1_score.Name = "textBox_team1_score";
            this.textBox_team1_score.Size = new System.Drawing.Size(48, 31);
            this.textBox_team1_score.TabIndex = 87;
            this.textBox_team1_score.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_viewers
            // 
            this.textBox_viewers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.textBox_viewers.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_viewers.ForeColor = System.Drawing.Color.White;
            this.textBox_viewers.Location = new System.Drawing.Point(205, 213);
            this.textBox_viewers.Multiline = true;
            this.textBox_viewers.Name = "textBox_viewers";
            this.textBox_viewers.Size = new System.Drawing.Size(177, 33);
            this.textBox_viewers.TabIndex = 88;
            this.textBox_viewers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(634, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 31);
            this.label1.TabIndex = 89;
            this.label1.Text = ":";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::football.Properties.Resources.button_color4;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_team1_score);
            this.panel1.Controls.Add(this.textBox_team2_score);
            this.panel1.Controls.Add(this.textBox_viewers);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox_team1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maskedTextBox_date);
            this.panel1.Controls.Add(this.comboBox_team2);
            this.panel1.Controls.Add(this.comboBox_referee);
            this.panel1.Location = new System.Drawing.Point(12, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 484);
            this.panel1.TabIndex = 90;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(75, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 78);
            this.label8.TabIndex = 95;
            this.label8.Text = "Количество зрителей:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(75, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 37);
            this.label7.TabIndex = 94;
            this.label7.Text = "Дата:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(75, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 37);
            this.label6.TabIndex = 93;
            this.label6.Text = "Судья:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(613, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 37);
            this.label5.TabIndex = 92;
            this.label5.Text = "Счёт";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(964, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 37);
            this.label3.TabIndex = 91;
            this.label3.Text = "Команда 2";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(199, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 37);
            this.label2.TabIndex = 90;
            this.label2.Text = "Команда 1";
            // 
            // matches_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1302, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "matches_add";
            this.Text = "Матчи - добавление";
            this.Load += new System.EventHandler(this.matches_add_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_team2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_team1;
        private System.Windows.Forms.TextBox textBox_team2_score;
        private System.Windows.Forms.ComboBox comboBox_referee;
        private System.Windows.Forms.TextBox textBox_team1_score;
        private System.Windows.Forms.TextBox textBox_viewers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}