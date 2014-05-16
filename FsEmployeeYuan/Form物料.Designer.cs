namespace FsEmployeeYuan
{
    partial class Form物料
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb名称 = new System.Windows.Forms.TextBox();
            this.tb编号 = new System.Windows.Forms.TextBox();
            this.tb单位 = new System.Windows.Forms.TextBox();
            this.编号 = new System.Windows.Forms.Label();
            this.名称 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn保存 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(539, 243);
            this.dataGridView1.TabIndex = 0;
            // 
            // tb名称
            // 
            this.tb名称.Location = new System.Drawing.Point(112, 46);
            this.tb名称.Name = "tb名称";
            this.tb名称.Size = new System.Drawing.Size(100, 21);
            this.tb名称.TabIndex = 1;
            // 
            // tb编号
            // 
            this.tb编号.Location = new System.Drawing.Point(112, 12);
            this.tb编号.Name = "tb编号";
            this.tb编号.Size = new System.Drawing.Size(100, 21);
            this.tb编号.TabIndex = 2;
            // 
            // tb单位
            // 
            this.tb单位.Location = new System.Drawing.Point(112, 80);
            this.tb单位.Name = "tb单位";
            this.tb单位.Size = new System.Drawing.Size(100, 21);
            this.tb单位.TabIndex = 3;
            // 
            // 编号
            // 
            this.编号.AutoSize = true;
            this.编号.Location = new System.Drawing.Point(53, 15);
            this.编号.Name = "编号";
            this.编号.Size = new System.Drawing.Size(29, 12);
            this.编号.TabIndex = 4;
            this.编号.Text = "编号";
            // 
            // 名称
            // 
            this.名称.AutoSize = true;
            this.名称.Location = new System.Drawing.Point(53, 49);
            this.名称.Name = "名称";
            this.名称.Size = new System.Drawing.Size(29, 12);
            this.名称.TabIndex = 5;
            this.名称.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "单位";
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(476, 83);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(75, 23);
            this.btn保存.TabIndex = 7;
            this.btn保存.Text = "保存";
            this.btn保存.UseVisualStyleBackColor = true;
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // Form物料
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 374);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.名称);
            this.Controls.Add(this.编号);
            this.Controls.Add(this.tb单位);
            this.Controls.Add(this.tb编号);
            this.Controls.Add(this.tb名称);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form物料";
            this.Text = "Form物料";
            this.Load += new System.EventHandler(this.Form物料_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb名称;
        private System.Windows.Forms.TextBox tb编号;
        private System.Windows.Forms.TextBox tb单位;
        private System.Windows.Forms.Label 编号;
        private System.Windows.Forms.Label 名称;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn保存;
    }
}