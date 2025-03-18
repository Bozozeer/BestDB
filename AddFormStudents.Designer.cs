namespace BestDB
{
    partial class AddFormStudents
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.last_nameTxt = new System.Windows.Forms.TextBox();
            this.first_nameTxt = new System.Windows.Forms.TextBox();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.facultetTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(64, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(419, 41);
            this.button4.TabIndex = 19;
            this.button4.Text = "Выйти в главную форму";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(64, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(419, 46);
            this.button3.TabIndex = 18;
            this.button3.Text = "Добавить запись";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(275, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 42);
            this.button2.TabIndex = 17;
            this.button2.Text = ">>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(64, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 42);
            this.button1.TabIndex = 16;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // last_nameTxt
            // 
            this.last_nameTxt.Location = new System.Drawing.Point(250, 109);
            this.last_nameTxt.Name = "last_nameTxt";
            this.last_nameTxt.Size = new System.Drawing.Size(262, 20);
            this.last_nameTxt.TabIndex = 15;
            // 
            // first_nameTxt
            // 
            this.first_nameTxt.Location = new System.Drawing.Point(250, 65);
            this.first_nameTxt.Name = "first_nameTxt";
            this.first_nameTxt.Size = new System.Drawing.Size(262, 20);
            this.first_nameTxt.TabIndex = 14;
            this.first_nameTxt.TextChanged += new System.EventHandler(this.first_nameTxt_TextChanged);
            // 
            // idTxt
            // 
            this.idTxt.Location = new System.Drawing.Point(250, 23);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(262, 20);
            this.idTxt.TabIndex = 13;
            this.idTxt.TextChanged += new System.EventHandler(this.idTxt_TextChanged);
            this.idTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idTxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 33);
            this.label3.TabIndex = 12;
            this.label3.Text = "Фамииля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 33);
            this.label2.TabIndex = 11;
            this.label2.Text = "Имя";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Номер студ.бил";
            // 
            // facultetTxt
            // 
            this.facultetTxt.Location = new System.Drawing.Point(251, 155);
            this.facultetTxt.Name = "facultetTxt";
            this.facultetTxt.Size = new System.Drawing.Size(262, 20);
            this.facultetTxt.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 33);
            this.label4.TabIndex = 20;
            this.label4.Text = "Факультет";
            // 
            // AddFormStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 355);
            this.Controls.Add(this.facultetTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.last_nameTxt);
            this.Controls.Add(this.first_nameTxt);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(541, 394);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(541, 394);
            this.Name = "AddFormStudents";
            this.Text = "Добавление записи";
            this.Load += new System.EventHandler(this.AddFormStudents_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox last_nameTxt;
        private System.Windows.Forms.TextBox first_nameTxt;
        private System.Windows.Forms.TextBox idTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox facultetTxt;
        private System.Windows.Forms.Label label4;
    }
}