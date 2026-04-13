namespace MorneauCServClient
{
    partial class frmMain
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
            this.panTop = new System.Windows.Forms.Panel();
            this.lFilter = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.bRefresh = new System.Windows.Forms.Button();
            this.gridPendingEDI = new System.Windows.Forms.DataGridView();
            this.DETAIL_LINE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORIGIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILL_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingEDI)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.lFilter);
            this.panTop.Controls.Add(this.cbFilter);
            this.panTop.Controls.Add(this.bRefresh);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1095, 45);
            this.panTop.TabIndex = 2;
            // 
            // lFilter
            // 
            this.lFilter.AutoSize = true;
            this.lFilter.Location = new System.Drawing.Point(32, 17);
            this.lFilter.Name = "lFilter";
            this.lFilter.Size = new System.Drawing.Size(29, 13);
            this.lFilter.TabIndex = 4;
            this.lFilter.Text = "Filter";
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "No Filter"});
            this.cbFilter.Location = new System.Drawing.Point(81, 14);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(308, 21);
            this.cbFilter.TabIndex = 3;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // bRefresh
            // 
            this.bRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh.Location = new System.Drawing.Point(995, 12);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 2;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // gridPendingEDI
            // 
            this.gridPendingEDI.AllowUserToAddRows = false;
            this.gridPendingEDI.AllowUserToDeleteRows = false;
            this.gridPendingEDI.AllowUserToOrderColumns = true;
            this.gridPendingEDI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendingEDI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DETAIL_LINE_ID,
            this.CUSTOMER,
            this.ORIGIN,
            this.DESTINATION,
            this.BILL_NUMBER});
            this.gridPendingEDI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPendingEDI.Location = new System.Drawing.Point(0, 45);
            this.gridPendingEDI.Name = "gridPendingEDI";
            this.gridPendingEDI.ReadOnly = true;
            this.gridPendingEDI.Size = new System.Drawing.Size(1095, 516);
            this.gridPendingEDI.TabIndex = 3;
            this.gridPendingEDI.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPendingEDI_CellDoubleClick);
            // 
            // DETAIL_LINE_ID
            // 
            this.DETAIL_LINE_ID.DataPropertyName = "DETAIL_LINE_ID";
            this.DETAIL_LINE_ID.HeaderText = "DLID";
            this.DETAIL_LINE_ID.Name = "DETAIL_LINE_ID";
            this.DETAIL_LINE_ID.ReadOnly = true;
            this.DETAIL_LINE_ID.Visible = false;
            // 
            // CUSTOMER
            // 
            this.CUSTOMER.DataPropertyName = "CUSTOMER";
            this.CUSTOMER.HeaderText = "Customer";
            this.CUSTOMER.Name = "CUSTOMER";
            this.CUSTOMER.ReadOnly = true;
            // 
            // ORIGIN
            // 
            this.ORIGIN.DataPropertyName = "ORIGIN";
            this.ORIGIN.HeaderText = "Shipper";
            this.ORIGIN.Name = "ORIGIN";
            this.ORIGIN.ReadOnly = true;
            // 
            // DESTINATION
            // 
            this.DESTINATION.DataPropertyName = "DESTINATION";
            this.DESTINATION.HeaderText = "Consignee";
            this.DESTINATION.Name = "DESTINATION";
            this.DESTINATION.ReadOnly = true;
            // 
            // BILL_NUMBER
            // 
            this.BILL_NUMBER.DataPropertyName = "BILL_NUMBER";
            this.BILL_NUMBER.HeaderText = "Bill Number";
            this.BILL_NUMBER.Name = "BILL_NUMBER";
            this.BILL_NUMBER.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 561);
            this.Controls.Add(this.gridPendingEDI);
            this.Controls.Add(this.panTop);
            this.Name = "frmMain";
            this.Text = "Morneau Customer Service Client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendingEDI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.DataGridView gridPendingEDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETAIL_LINE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORIGIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_NUMBER;
        private System.Windows.Forms.Label lFilter;
        private System.Windows.Forms.ComboBox cbFilter;
    }
}

