namespace FsEmployeeYuan
{
    partial class Form9
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
            this.dgv物料 = new System.Windows.Forms.DataGridView();
            this.dgv订单Detail = new System.Windows.Forms.DataGridView();
            this.btn删除 = new System.Windows.Forms.Button();
            this.btn保存 = new System.Windows.Forms.Button();
            this.btn物料 = new System.Windows.Forms.Button();
            this.dgv订单 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv物料)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv订单Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv订单)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv物料
            // 
            this.dgv物料.AllowUserToAddRows = false;
            this.dgv物料.AllowUserToDeleteRows = false;
            this.dgv物料.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv物料.Location = new System.Drawing.Point(26, 157);
            this.dgv物料.Name = "dgv物料";
            this.dgv物料.ReadOnly = true;
            this.dgv物料.RowTemplate.Height = 23;
            this.dgv物料.Size = new System.Drawing.Size(304, 353);
            this.dgv物料.TabIndex = 1;
            this.dgv物料.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv物料_CellDoubleClick);
            // 
            // dgv订单Detail
            // 
            this.dgv订单Detail.AllowUserToAddRows = false;
            this.dgv订单Detail.AllowUserToDeleteRows = false;
            this.dgv订单Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv订单Detail.Location = new System.Drawing.Point(353, 157);
            this.dgv订单Detail.Name = "dgv订单Detail";
            this.dgv订单Detail.RowTemplate.Height = 23;
            this.dgv订单Detail.Size = new System.Drawing.Size(464, 353);
            this.dgv订单Detail.TabIndex = 2;
            this.dgv订单Detail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv订单Detail_CellValueChanged);
            this.dgv订单Detail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv订单Detail_CellDoubleClick);
            this.dgv订单Detail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv订单Detail_CellEndEdit);
            this.dgv订单Detail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv订单Detail_DataError);
            // 
            // btn删除
            // 
            this.btn删除.Location = new System.Drawing.Point(727, 37);
            this.btn删除.Name = "btn删除";
            this.btn删除.Size = new System.Drawing.Size(75, 23);
            this.btn删除.TabIndex = 3;
            this.btn删除.Text = "删除";
            this.btn删除.UseVisualStyleBackColor = true;
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(621, 37);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(75, 23);
            this.btn保存.TabIndex = 4;
            this.btn保存.Text = "保存";
            this.btn保存.UseVisualStyleBackColor = true;
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // btn物料
            // 
            this.btn物料.Location = new System.Drawing.Point(26, 128);
            this.btn物料.Name = "btn物料";
            this.btn物料.Size = new System.Drawing.Size(75, 23);
            this.btn物料.TabIndex = 5;
            this.btn物料.Text = "物料";
            this.btn物料.UseVisualStyleBackColor = true;
            this.btn物料.Click += new System.EventHandler(this.btn物料_Click);
            // 
            // dgv订单
            // 
            this.dgv订单.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv订单.Location = new System.Drawing.Point(353, 12);
            this.dgv订单.Name = "dgv订单";
            this.dgv订单.ReadOnly = true;
            this.dgv订单.RowTemplate.Height = 23;
            this.dgv订单.Size = new System.Drawing.Size(233, 139);
            this.dgv订单.TabIndex = 6;
            this.dgv订单.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv订单_CellDoubleClick);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 522);
            this.Controls.Add(this.dgv订单);
            this.Controls.Add(this.btn物料);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.btn删除);
            this.Controls.Add(this.dgv订单Detail);
            this.Controls.Add(this.dgv物料);
            this.Name = "Form9";
            this.Text = "Form9";
            ((System.ComponentModel.ISupportInitialize)(this.dgv物料)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv订单Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv订单)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv物料;
        private System.Windows.Forms.DataGridView dgv订单Detail;
        private System.Windows.Forms.Button btn删除;
        private System.Windows.Forms.Button btn保存;
        private System.Windows.Forms.Button btn物料;
        private System.Windows.Forms.DataGridView dgv订单;
    }
}