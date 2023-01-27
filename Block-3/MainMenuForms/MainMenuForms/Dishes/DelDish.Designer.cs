namespace MainMenuForms
{
    partial class DelDish
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dishListLabel = new System.Windows.Forms.Label();
            this.commandResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.button4.Location = new System.Drawing.Point(16, 502);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 36);
            this.button4.TabIndex = 25;
            this.button4.Text = "Назад";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(322, 180);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 22);
            this.textBox1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(214, 228);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(379, 50);
            this.button1.TabIndex = 23;
            this.button1.Text = "Удалить блюдо";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.label3.Location = new System.Drawing.Point(48, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "Укажите номер рецепта: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(286, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Удаление рецепта блюда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(326, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 26);
            this.label2.TabIndex = 20;
            this.label2.Text = "Блюда и рецепты";
            // 
            // dishListLabel
            // 
            this.dishListLabel.AutoSize = true;
            this.dishListLabel.Font = new System.Drawing.Font("Times New Roman", 9.5F);
            this.dishListLabel.Location = new System.Drawing.Point(210, 340);
            this.dishListLabel.Name = "dishListLabel";
            this.dishListLabel.Size = new System.Drawing.Size(13, 19);
            this.dishListLabel.TabIndex = 26;
            this.dishListLabel.Text = " ";
            // 
            // commandResult
            // 
            this.commandResult.AutoSize = true;
            this.commandResult.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commandResult.Location = new System.Drawing.Point(255, 292);
            this.commandResult.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.commandResult.Name = "commandResult";
            this.commandResult.Size = new System.Drawing.Size(18, 26);
            this.commandResult.TabIndex = 27;
            this.commandResult.Text = " ";
            this.commandResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DelDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.commandResult);
            this.Controls.Add(this.dishListLabel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "DelDish";
            this.Text = "DelDish";
            this.Load += new System.EventHandler(this.DelDish_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dishListLabel;
        private System.Windows.Forms.Label commandResult;
    }
}