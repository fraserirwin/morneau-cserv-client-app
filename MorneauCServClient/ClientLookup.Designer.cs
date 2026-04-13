namespace MorneauCServClient
{
    partial class frmClientLookup
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
            this.components = new System.ComponentModel.Container();
            this.panTop = new System.Windows.Forms.Panel();
            this.eCountry = new System.Windows.Forms.TextBox();
            this.lCountry = new System.Windows.Forms.Label();
            this.gbCreate = new System.Windows.Forms.GroupBox();
            this.eContact = new System.Windows.Forms.TextBox();
            this.eEMail = new System.Windows.Forms.TextBox();
            this.eFax = new System.Windows.Forms.TextBox();
            this.eCell = new System.Windows.Forms.TextBox();
            this.ePhoneExt = new System.Windows.Forms.TextBox();
            this.ePhone = new System.Windows.Forms.TextBox();
            this.lContact = new System.Windows.Forms.Label();
            this.lEMail = new System.Windows.Forms.Label();
            this.lFax = new System.Windows.Forms.Label();
            this.lCell = new System.Windows.Forms.Label();
            this.lPhone = new System.Windows.Forms.Label();
            this.bCreate = new System.Windows.Forms.Button();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.eFilterCity = new System.Windows.Forms.TextBox();
            this.eFilterName = new System.Windows.Forms.TextBox();
            this.lFilterCity = new System.Windows.Forms.Label();
            this.lFilterName = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.eFilterPostalCode = new System.Windows.Forms.TextBox();
            this.eFilterAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lFAddress = new System.Windows.Forms.Label();
            this.eProv = new System.Windows.Forms.TextBox();
            this.lPostalCode = new System.Windows.Forms.Label();
            this.ePostalCode = new System.Windows.Forms.TextBox();
            this.eCity = new System.Windows.Forms.TextBox();
            this.eAddress2 = new System.Windows.Forms.TextBox();
            this.eAddress1 = new System.Windows.Forms.TextBox();
            this.eName = new System.Windows.Forms.TextBox();
            this.lCity = new System.Windows.Forms.Label();
            this.lAddress = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.gridClients = new System.Windows.Forms.DataGridView();
            this.CLIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVINCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSTAL_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEFAULT_DELIVERY_Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COUNTRY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_REVIEW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuClients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UseClient = new System.Windows.Forms.ToolStripMenuItem();
            this.ReviewClient = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveReview = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateClientProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.cblShipping = new System.Windows.Forms.CheckedListBox();
            this.panTop.SuspendLayout();
            this.gbCreate.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClients)).BeginInit();
            this.menuClients.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTop.Controls.Add(this.eCountry);
            this.panTop.Controls.Add(this.lCountry);
            this.panTop.Controls.Add(this.gbCreate);
            this.panTop.Controls.Add(this.gbFilter);
            this.panTop.Controls.Add(this.eProv);
            this.panTop.Controls.Add(this.lPostalCode);
            this.panTop.Controls.Add(this.ePostalCode);
            this.panTop.Controls.Add(this.eCity);
            this.panTop.Controls.Add(this.eAddress2);
            this.panTop.Controls.Add(this.eAddress1);
            this.panTop.Controls.Add(this.eName);
            this.panTop.Controls.Add(this.lCity);
            this.panTop.Controls.Add(this.lAddress);
            this.panTop.Controls.Add(this.lName);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1133, 199);
            this.panTop.TabIndex = 0;
            // 
            // eCountry
            // 
            this.eCountry.Location = new System.Drawing.Point(106, 157);
            this.eCountry.Name = "eCountry";
            this.eCountry.Size = new System.Drawing.Size(57, 20);
            this.eCountry.TabIndex = 18;
            // 
            // lCountry
            // 
            this.lCountry.AutoSize = true;
            this.lCountry.Location = new System.Drawing.Point(26, 164);
            this.lCountry.Name = "lCountry";
            this.lCountry.Size = new System.Drawing.Size(43, 13);
            this.lCountry.TabIndex = 17;
            this.lCountry.Text = "Country";
            // 
            // gbCreate
            // 
            this.gbCreate.Controls.Add(this.cblShipping);
            this.gbCreate.Controls.Add(this.eContact);
            this.gbCreate.Controls.Add(this.eEMail);
            this.gbCreate.Controls.Add(this.eFax);
            this.gbCreate.Controls.Add(this.eCell);
            this.gbCreate.Controls.Add(this.ePhoneExt);
            this.gbCreate.Controls.Add(this.ePhone);
            this.gbCreate.Controls.Add(this.lContact);
            this.gbCreate.Controls.Add(this.lEMail);
            this.gbCreate.Controls.Add(this.lFax);
            this.gbCreate.Controls.Add(this.lCell);
            this.gbCreate.Controls.Add(this.lPhone);
            this.gbCreate.Controls.Add(this.bCreate);
            this.gbCreate.Location = new System.Drawing.Point(650, 15);
            this.gbCreate.Name = "gbCreate";
            this.gbCreate.Size = new System.Drawing.Size(470, 177);
            this.gbCreate.TabIndex = 16;
            this.gbCreate.TabStop = false;
            this.gbCreate.Text = " Create Client ";
            // 
            // eContact
            // 
            this.eContact.Location = new System.Drawing.Point(81, 149);
            this.eContact.Name = "eContact";
            this.eContact.Size = new System.Drawing.Size(120, 20);
            this.eContact.TabIndex = 13;
            // 
            // eEMail
            // 
            this.eEMail.Location = new System.Drawing.Point(81, 124);
            this.eEMail.Name = "eEMail";
            this.eEMail.Size = new System.Drawing.Size(120, 20);
            this.eEMail.TabIndex = 12;
            // 
            // eFax
            // 
            this.eFax.Location = new System.Drawing.Point(81, 98);
            this.eFax.Name = "eFax";
            this.eFax.Size = new System.Drawing.Size(120, 20);
            this.eFax.TabIndex = 11;
            // 
            // eCell
            // 
            this.eCell.Location = new System.Drawing.Point(81, 72);
            this.eCell.Name = "eCell";
            this.eCell.Size = new System.Drawing.Size(120, 20);
            this.eCell.TabIndex = 10;
            // 
            // ePhoneExt
            // 
            this.ePhoneExt.Location = new System.Drawing.Point(226, 47);
            this.ePhoneExt.Name = "ePhoneExt";
            this.ePhoneExt.Size = new System.Drawing.Size(41, 20);
            this.ePhoneExt.TabIndex = 9;
            // 
            // ePhone
            // 
            this.ePhone.Location = new System.Drawing.Point(81, 47);
            this.ePhone.Name = "ePhone";
            this.ePhone.Size = new System.Drawing.Size(120, 20);
            this.ePhone.TabIndex = 8;
            // 
            // lContact
            // 
            this.lContact.AutoSize = true;
            this.lContact.Location = new System.Drawing.Point(16, 152);
            this.lContact.Name = "lContact";
            this.lContact.Size = new System.Drawing.Size(44, 13);
            this.lContact.TabIndex = 7;
            this.lContact.Text = "Contact";
            // 
            // lEMail
            // 
            this.lEMail.AutoSize = true;
            this.lEMail.Location = new System.Drawing.Point(16, 127);
            this.lEMail.Name = "lEMail";
            this.lEMail.Size = new System.Drawing.Size(33, 13);
            this.lEMail.TabIndex = 6;
            this.lEMail.Text = "EMail";
            // 
            // lFax
            // 
            this.lFax.AutoSize = true;
            this.lFax.Location = new System.Drawing.Point(16, 101);
            this.lFax.Name = "lFax";
            this.lFax.Size = new System.Drawing.Size(24, 13);
            this.lFax.TabIndex = 5;
            this.lFax.Text = "Fax";
            // 
            // lCell
            // 
            this.lCell.AutoSize = true;
            this.lCell.Location = new System.Drawing.Point(16, 75);
            this.lCell.Name = "lCell";
            this.lCell.Size = new System.Drawing.Size(24, 13);
            this.lCell.TabIndex = 4;
            this.lCell.Text = "Cell";
            // 
            // lPhone
            // 
            this.lPhone.AutoSize = true;
            this.lPhone.Location = new System.Drawing.Point(16, 50);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(38, 13);
            this.lPhone.TabIndex = 3;
            this.lPhone.Text = "Phone";
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(217, 16);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(75, 23);
            this.bCreate.TabIndex = 2;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.eFilterCity);
            this.gbFilter.Controls.Add(this.eFilterName);
            this.gbFilter.Controls.Add(this.lFilterCity);
            this.gbFilter.Controls.Add(this.lFilterName);
            this.gbFilter.Controls.Add(this.bSearch);
            this.gbFilter.Controls.Add(this.eFilterPostalCode);
            this.gbFilter.Controls.Add(this.eFilterAddress);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Controls.Add(this.lFAddress);
            this.gbFilter.Location = new System.Drawing.Point(335, 14);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(293, 178);
            this.gbFilter.TabIndex = 15;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // eFilterCity
            // 
            this.eFilterCity.Location = new System.Drawing.Point(77, 99);
            this.eFilterCity.Name = "eFilterCity";
            this.eFilterCity.Size = new System.Drawing.Size(100, 20);
            this.eFilterCity.TabIndex = 8;
            // 
            // eFilterName
            // 
            this.eFilterName.Location = new System.Drawing.Point(78, 73);
            this.eFilterName.Name = "eFilterName";
            this.eFilterName.Size = new System.Drawing.Size(100, 20);
            this.eFilterName.TabIndex = 7;
            // 
            // lFilterCity
            // 
            this.lFilterCity.AutoSize = true;
            this.lFilterCity.Location = new System.Drawing.Point(13, 102);
            this.lFilterCity.Name = "lFilterCity";
            this.lFilterCity.Size = new System.Drawing.Size(24, 13);
            this.lFilterCity.TabIndex = 6;
            this.lFilterCity.Text = "City";
            // 
            // lFilterName
            // 
            this.lFilterName.AutoSize = true;
            this.lFilterName.Location = new System.Drawing.Point(13, 76);
            this.lFilterName.Name = "lFilterName";
            this.lFilterName.Size = new System.Drawing.Size(35, 13);
            this.lFilterName.TabIndex = 5;
            this.lFilterName.Text = "Name";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(198, 24);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // eFilterPostalCode
            // 
            this.eFilterPostalCode.Location = new System.Drawing.Point(77, 48);
            this.eFilterPostalCode.Name = "eFilterPostalCode";
            this.eFilterPostalCode.Size = new System.Drawing.Size(101, 20);
            this.eFilterPostalCode.TabIndex = 3;
            // 
            // eFilterAddress
            // 
            this.eFilterAddress.Location = new System.Drawing.Point(78, 23);
            this.eFilterAddress.Name = "eFilterAddress";
            this.eFilterAddress.Size = new System.Drawing.Size(100, 20);
            this.eFilterAddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Postal Code";
            // 
            // lFAddress
            // 
            this.lFAddress.AutoSize = true;
            this.lFAddress.Location = new System.Drawing.Point(13, 27);
            this.lFAddress.Name = "lFAddress";
            this.lFAddress.Size = new System.Drawing.Size(45, 13);
            this.lFAddress.TabIndex = 0;
            this.lFAddress.Text = "Address";
            // 
            // eProv
            // 
            this.eProv.Location = new System.Drawing.Point(229, 98);
            this.eProv.Name = "eProv";
            this.eProv.Size = new System.Drawing.Size(81, 20);
            this.eProv.TabIndex = 14;
            // 
            // lPostalCode
            // 
            this.lPostalCode.AutoSize = true;
            this.lPostalCode.Location = new System.Drawing.Point(26, 134);
            this.lPostalCode.Name = "lPostalCode";
            this.lPostalCode.Size = new System.Drawing.Size(64, 13);
            this.lPostalCode.TabIndex = 13;
            this.lPostalCode.Text = "Postal Code";
            // 
            // ePostalCode
            // 
            this.ePostalCode.Location = new System.Drawing.Point(106, 131);
            this.ePostalCode.Name = "ePostalCode";
            this.ePostalCode.Size = new System.Drawing.Size(79, 20);
            this.ePostalCode.TabIndex = 12;
            // 
            // eCity
            // 
            this.eCity.Location = new System.Drawing.Point(106, 98);
            this.eCity.Name = "eCity";
            this.eCity.Size = new System.Drawing.Size(117, 20);
            this.eCity.TabIndex = 11;
            this.eCity.DoubleClick += new System.EventHandler(this.eCity_DoubleClick);
            // 
            // eAddress2
            // 
            this.eAddress2.Location = new System.Drawing.Point(106, 67);
            this.eAddress2.Name = "eAddress2";
            this.eAddress2.Size = new System.Drawing.Size(204, 20);
            this.eAddress2.TabIndex = 10;
            // 
            // eAddress1
            // 
            this.eAddress1.Location = new System.Drawing.Point(106, 40);
            this.eAddress1.Name = "eAddress1";
            this.eAddress1.Size = new System.Drawing.Size(204, 20);
            this.eAddress1.TabIndex = 9;
            // 
            // eName
            // 
            this.eName.Location = new System.Drawing.Point(106, 14);
            this.eName.Name = "eName";
            this.eName.Size = new System.Drawing.Size(204, 20);
            this.eName.TabIndex = 8;
            this.eName.DoubleClick += new System.EventHandler(this.eName_DoubleClick);
            // 
            // lCity
            // 
            this.lCity.AutoSize = true;
            this.lCity.Location = new System.Drawing.Point(26, 98);
            this.lCity.Name = "lCity";
            this.lCity.Size = new System.Drawing.Size(57, 13);
            this.lCity.TabIndex = 7;
            this.lCity.Text = "City / Prov";
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(26, 38);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(45, 13);
            this.lAddress.TabIndex = 6;
            this.lAddress.Text = "Address";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(26, 15);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 2;
            this.lName.Text = "Name";
            // 
            // gridClients
            // 
            this.gridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLIENT_ID,
            this.NAME,
            this.ADDRESS_1,
            this.ADDRESS_2,
            this.CITY,
            this.PROVINCE,
            this.POSTAL_CODE,
            this.DEFAULT_DELIVERY_Z,
            this.COUNTRY,
            this.IN_REVIEW});
            this.gridClients.ContextMenuStrip = this.menuClients;
            this.gridClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClients.Location = new System.Drawing.Point(0, 199);
            this.gridClients.Name = "gridClients";
            this.gridClients.Size = new System.Drawing.Size(1133, 333);
            this.gridClients.TabIndex = 1;
            this.gridClients.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridClients_CellFormatting);
            // 
            // CLIENT_ID
            // 
            this.CLIENT_ID.DataPropertyName = "CLIENT_ID";
            this.CLIENT_ID.HeaderText = "Client ID";
            this.CLIENT_ID.Name = "CLIENT_ID";
            this.CLIENT_ID.ReadOnly = true;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "Name";
            this.NAME.MaxInputLength = 40;
            this.NAME.Name = "NAME";
            this.NAME.Width = 200;
            // 
            // ADDRESS_1
            // 
            this.ADDRESS_1.DataPropertyName = "ADDRESS_1";
            this.ADDRESS_1.HeaderText = "Address 1";
            this.ADDRESS_1.MaxInputLength = 40;
            this.ADDRESS_1.Name = "ADDRESS_1";
            this.ADDRESS_1.Width = 200;
            // 
            // ADDRESS_2
            // 
            this.ADDRESS_2.DataPropertyName = "ADDRESS_2";
            this.ADDRESS_2.HeaderText = "Address 2";
            this.ADDRESS_2.MaxInputLength = 40;
            this.ADDRESS_2.Name = "ADDRESS_2";
            this.ADDRESS_2.Width = 200;
            // 
            // CITY
            // 
            this.CITY.DataPropertyName = "CITY";
            this.CITY.HeaderText = "City";
            this.CITY.MaxInputLength = 30;
            this.CITY.Name = "CITY";
            this.CITY.Width = 120;
            // 
            // PROVINCE
            // 
            this.PROVINCE.DataPropertyName = "PROVINCE";
            this.PROVINCE.HeaderText = "Province";
            this.PROVINCE.MaxInputLength = 4;
            this.PROVINCE.Name = "PROVINCE";
            this.PROVINCE.Width = 50;
            // 
            // POSTAL_CODE
            // 
            this.POSTAL_CODE.DataPropertyName = "POSTAL_CODE";
            this.POSTAL_CODE.HeaderText = "PostalCode";
            this.POSTAL_CODE.MaxInputLength = 10;
            this.POSTAL_CODE.Name = "POSTAL_CODE";
            this.POSTAL_CODE.ReadOnly = true;
            this.POSTAL_CODE.Width = 80;
            // 
            // DEFAULT_DELIVERY_Z
            // 
            this.DEFAULT_DELIVERY_Z.DataPropertyName = "DEFAULT_DELIVERY_Z";
            this.DEFAULT_DELIVERY_Z.HeaderText = "Zone";
            this.DEFAULT_DELIVERY_Z.MaxInputLength = 10;
            this.DEFAULT_DELIVERY_Z.Name = "DEFAULT_DELIVERY_Z";
            this.DEFAULT_DELIVERY_Z.Visible = false;
            // 
            // COUNTRY
            // 
            this.COUNTRY.DataPropertyName = "COUNTRY";
            this.COUNTRY.HeaderText = "Country";
            this.COUNTRY.MaxInputLength = 2;
            this.COUNTRY.Name = "COUNTRY";
            this.COUNTRY.Width = 50;
            // 
            // IN_REVIEW
            // 
            this.IN_REVIEW.DataPropertyName = "IN_REVIEW";
            this.IN_REVIEW.HeaderText = "Review";
            this.IN_REVIEW.Name = "IN_REVIEW";
            this.IN_REVIEW.ReadOnly = true;
            this.IN_REVIEW.Width = 50;
            // 
            // menuClients
            // 
            this.menuClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UseClient,
            this.ReviewClient,
            this.RemoveReview,
            this.UpdateClientProfile});
            this.menuClients.Name = "menuClients";
            this.menuClients.Size = new System.Drawing.Size(194, 92);
            this.menuClients.Opening += new System.ComponentModel.CancelEventHandler(this.menuClients_Opening);
            // 
            // UseClient
            // 
            this.UseClient.Name = "UseClient";
            this.UseClient.Size = new System.Drawing.Size(193, 22);
            this.UseClient.Text = "Use this client";
            this.UseClient.Click += new System.EventHandler(this.UseClient_Click);
            // 
            // ReviewClient
            // 
            this.ReviewClient.Name = "ReviewClient";
            this.ReviewClient.Size = new System.Drawing.Size(193, 22);
            this.ReviewClient.Text = "Mark Client for Review";
            this.ReviewClient.Click += new System.EventHandler(this.AddClientReview_Click);
            // 
            // RemoveReview
            // 
            this.RemoveReview.Name = "RemoveReview";
            this.RemoveReview.Size = new System.Drawing.Size(193, 22);
            this.RemoveReview.Text = "Remove Review";
            this.RemoveReview.Click += new System.EventHandler(this.RemoveReview_Click);
            // 
            // UpdateClientProfile
            // 
            this.UpdateClientProfile.Name = "UpdateClientProfile";
            this.UpdateClientProfile.Size = new System.Drawing.Size(193, 22);
            this.UpdateClientProfile.Text = "UpdateClientProfile";
            this.UpdateClientProfile.Click += new System.EventHandler(this.UpdateClientProfile_Click);
            // 
            // cblShipping
            // 
            this.cblShipping.FormattingEnabled = true;
            this.cblShipping.Location = new System.Drawing.Point(233, 78);
            this.cblShipping.Name = "cblShipping";
            this.cblShipping.Size = new System.Drawing.Size(231, 94);
            this.cblShipping.TabIndex = 14;
            // 
            // frmClientLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 532);
            this.Controls.Add(this.gridClients);
            this.Controls.Add(this.panTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ClientLookup";
            this.Load += new System.EventHandler(this.frmClientLookup_Load);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.gbCreate.ResumeLayout(false);
            this.gbCreate.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClients)).EndInit();
            this.menuClients.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.DataGridView gridClients;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lCity;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.TextBox eProv;
        private System.Windows.Forms.Label lPostalCode;
        private System.Windows.Forms.TextBox ePostalCode;
        private System.Windows.Forms.TextBox eCity;
        private System.Windows.Forms.TextBox eAddress2;
        private System.Windows.Forms.TextBox eAddress1;
        private System.Windows.Forms.TextBox eName;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lFAddress;
        private System.Windows.Forms.TextBox eFilterPostalCode;
        private System.Windows.Forms.TextBox eFilterAddress;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.ContextMenuStrip menuClients;
        private System.Windows.Forms.ToolStripMenuItem UseClient;
        private System.Windows.Forms.GroupBox gbCreate;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Label lEMail;
        private System.Windows.Forms.Label lFax;
        private System.Windows.Forms.Label lCell;
        private System.Windows.Forms.Label lPhone;
        private System.Windows.Forms.TextBox eContact;
        private System.Windows.Forms.TextBox eEMail;
        private System.Windows.Forms.TextBox eFax;
        private System.Windows.Forms.TextBox eCell;
        private System.Windows.Forms.TextBox ePhoneExt;
        private System.Windows.Forms.TextBox ePhone;
        private System.Windows.Forms.Label lContact;
        private System.Windows.Forms.TextBox eCountry;
        private System.Windows.Forms.Label lCountry;
        private System.Windows.Forms.TextBox eFilterCity;
        private System.Windows.Forms.TextBox eFilterName;
        private System.Windows.Forms.Label lFilterCity;
        private System.Windows.Forms.Label lFilterName;
        private System.Windows.Forms.ToolStripMenuItem ReviewClient;
        private System.Windows.Forms.ToolStripMenuItem RemoveReview;
        private System.Windows.Forms.ToolStripMenuItem UpdateClientProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROVINCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSTAL_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEFAULT_DELIVERY_Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn COUNTRY;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_REVIEW;
        private System.Windows.Forms.CheckedListBox cblShipping;
    }
}