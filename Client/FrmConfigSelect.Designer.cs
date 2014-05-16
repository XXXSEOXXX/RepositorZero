namespace Client
{
    partial class FrmConfigSelect
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
            this.btnIntranet = new System.Windows.Forms.Button();
            this.btnExtranet = new System.Windows.Forms.Button();
            this.lab1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIntranet
            // 
            this.btnIntranet.Location = new System.Drawing.Point(55, 48);
            this.btnIntranet.Name = "btnIntranet";
            this.btnIntranet.Size = new System.Drawing.Size(75, 23);
            this.btnIntranet.TabIndex = 0;
            this.btnIntranet.Text = "内网";
            this.btnIntranet.UseVisualStyleBackColor = true;
            this.btnIntranet.Click += new System.EventHandler(this.btnIntranet_Click);
            // 
            // btnExtranet
            // 
            this.btnExtranet.Location = new System.Drawing.Point(182, 48);
            this.btnExtranet.Name = "btnExtranet";
            this.btnExtranet.Size = new System.Drawing.Size(75, 23);
            this.btnExtranet.TabIndex = 1;
            this.btnExtranet.Text = "外网";
            this.btnExtranet.UseVisualStyleBackColor = true;
            this.btnExtranet.Click += new System.EventHandler(this.btnExtranet_Click);
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("宋体", 11F);
            this.lab1.Location = new System.Drawing.Point(23, 19);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(55, 15);
            this.lab1.TabIndex = 2;
            this.lab1.Text = "label1";
            // 
            // FrmConfigSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 120);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.btnExtranet);
            this.Controls.Add(this.btnIntranet);
            this.Name = "FrmConfigSelect";
            this.Text = "内外网切换程序";
            this.Load += new System.EventHandler(this.FrmConfigSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIntranet;
        private System.Windows.Forms.Button btnExtranet;
        private System.Windows.Forms.Label lab1;
    }
}