namespace MainMenuForms
{
    partial class ChangeProduct
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
            this.dishListLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commandResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dishListLabel
            // 
            this.dishListLabel.AutoSize = true;
            this.dishListLabel.Font = new System.Drawing.Font("Times New Roman", 9.5F);
            this.dishListLabel.Location = new System.Drawing.Point(206, 378);
            this.dishListLabel.Name = "dishListLabel";
            this.dishListLabel.Size = new System.Drawing.Size(13, 19);
            this.dishListLabel.TabIndex = 33;
            this.dishListLabel.Text = " ";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button4.Location = new System.Drawing.Point(12, 605);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 36);
            this.button4.TabIndex = 32;
            this.button4.Text = "Назад";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(318, 185);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 22);
            this.textBox1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(210, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 50);
            this.button1.TabIndex = 30;
            this.button1.Text = "Изменить вес";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.label3.Location = new System.Drawing.Point(43, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 26);
            this.label3.TabIndex = 29;
            this.label3.Text = "Укажите номер продукта: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(301, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Изменение продукта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(301, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "Хранилище продуктов";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(318, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 22);
            this.textBox2.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.label4.Location = new System.Drawing.Point(96, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 26);
            this.label4.TabIndex = 34;
            this.label4.Text = "Укажите новый вес:";
            // 
            // commandResult
            // 
            this.commandResult.AutoSize = true;
            this.commandResult.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commandResult.Location = new System.Drawing.Point(261, 346);
            this.commandResult.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandResult.Name = "commandResult";
            this.commandResult.Size = new System.Drawing.Size(18, 26);
            this.commandResult.TabIndex = 36;
            this.commandResult.Text = " ";
            this.commandResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChangeProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.commandResult);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dishListLabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ChangeProduct";
            this.Text = "ChangeProduct";
            this.Load += new System.EventHandler(this.ChangeProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dishListLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label commandResult;
    }
}