using MorneauCServClient.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MorneauCServClient
{
    public partial class frmClientLookup : Form
    {
        private readonly MasterDataRepository _masterDataRepositories;
        private string _clientType;
        private int _dlid;
        private string _name;
        private string _address1;
        private string _address2;
        private string _city;
        private string _prov;
        private string _postalCode;
        private string _country;
        public string ClientID;
        public frmClientLookup(string clientType, DataGridViewRow gridViewRow)
        {
            InitializeComponent();
            _masterDataRepositories = new MasterDataRepository();
            GetShippingInstructions();

            if (clientType == "Caller")
            {
                _name = gridViewRow.Cells["CALLNAME"].Value.ToString();
                _address1 = gridViewRow.Cells["CALLADDR1"].Value.ToString();
                _address2 = gridViewRow.Cells["CALLADDR2"].Value.ToString();
                _postalCode = gridViewRow.Cells["CALLPC"].Value.ToString();
                _city = gridViewRow.Cells["CALLCITY"].Value.ToString();
                _prov = gridViewRow.Cells["CALLPROV"].Value.ToString();
                _country = gridViewRow.Cells["CALLCOUNTRY"].Value.ToString();

                ePhone.Text = gridViewRow.Cells["CALLPHONE"].Value.ToString();
                ePhoneExt.Text = gridViewRow.Cells["CALLPHONEEXT"].Value.ToString();
                eCell.Text = gridViewRow.Cells["CALLCELL"].Value.ToString();
                eFax.Text = gridViewRow.Cells["CALLFAX"].Value.ToString();
                eEMail.Text = gridViewRow.Cells["CALLEMAIL"].Value.ToString();
                eContact.Text = gridViewRow.Cells["CALLCONTACT"].Value.ToString();
            }
            else if (clientType == "Shipper")
            {
                _name = gridViewRow.Cells["ORIGNAME"].Value.ToString();
                _address1 = gridViewRow.Cells["ORIGADDR1"].Value.ToString();
                _address2 = gridViewRow.Cells["ORIGADDR2"].Value.ToString();
                _postalCode = gridViewRow.Cells["ORIGPC"].Value.ToString();
                _city = gridViewRow.Cells["ORIGCITY"].Value.ToString();
                _prov = gridViewRow.Cells["ORIGPROV"].Value.ToString();
                _country = gridViewRow.Cells["ORIGCOUNTRY"].Value.ToString();

                ePhone.Text = gridViewRow.Cells["ORIGPHONE"].Value.ToString();
                ePhoneExt.Text = gridViewRow.Cells["ORIGPHONEEXT"].Value.ToString();
                eCell.Text = gridViewRow.Cells["ORIGCELL"].Value.ToString();
                eFax.Text = gridViewRow.Cells["ORIGFAX"].Value.ToString();
                eEMail.Text = gridViewRow.Cells["ORIGEMAIL"].Value.ToString();
                eContact.Text = gridViewRow.Cells["ORIGCONTACT"].Value.ToString();
            }
            else if (clientType == "Consignee")
            {
                _name = gridViewRow.Cells["DESTNAME"].Value.ToString();
                _address1 = gridViewRow.Cells["DESTADDR1"].Value.ToString();
                _address2 = gridViewRow.Cells["DESTADDR2"].Value.ToString();
                _postalCode = gridViewRow.Cells["DESTPC"].Value.ToString();
                _city = gridViewRow.Cells["DESTCITY"].Value.ToString();
                _prov = gridViewRow.Cells["DESTPROV"].Value.ToString();
                _country = gridViewRow.Cells["DESTCOUNTRY"].Value.ToString();

                ePhone.Text = gridViewRow.Cells["DESTPHONE"].Value.ToString();
                ePhoneExt.Text = gridViewRow.Cells["DESTPHONEEXT"].Value.ToString();
                eCell.Text = gridViewRow.Cells["DESTCELL"].Value.ToString();
                eFax.Text = gridViewRow.Cells["DESTFAX"].Value.ToString();
                eEMail.Text = gridViewRow.Cells["DESTEMAIL"].Value.ToString();
                eContact.Text = gridViewRow.Cells["DESTCONTACT"].Value.ToString();
            }

            _dlid = Convert.ToInt32(gridViewRow.Cells["DETAIL_LINE_ID"].Value);

            this.Text = clientType + " Client Lookup";
            _clientType = clientType;

            eName.Text = _name;
            eAddress1.Text = _address1;
            eAddress2.Text = _address2;
            eCity.Text = _city;
            eProv.Text = _prov;
            eCountry.Text = _country;


            string filterAddress = _address1.TrimStart();
            int pos = filterAddress.IndexOf(" ");
            if (pos > 0) 
            {
                filterAddress = filterAddress.Substring(0, pos);    
            }
            eFilterAddress.Text = filterAddress + " ";

            string filterPC = _postalCode.Trim();
            filterPC = filterPC.ToUpper();
            if (filterPC.Length == 6)
            {
                // Assume PC and add space
                filterPC = filterPC.Insert(3, " ");
            }
            eFilterPostalCode.Text = filterPC;
            ePostalCode.Text = filterPC;
            ClientID = "";
        }

        private async void SearchClients()
        {
            //            string address = "%" + eFilterAddress.Text + "%";
            string address = eFilterAddress.Text + "%";
            string postal_code = eFilterPostalCode.Text + "%";
            string name = eFilterName.Text + "%";
            string city = eFilterCity.Text + "%";

            gridClients.DataSource = await _masterDataRepositories.GetClientsAsync(address, postal_code, name, city);
        }
        private void bSearch_Click(object sender, EventArgs e)
        {
            SearchClients();
        }

        private void UseClient_Click(object sender, EventArgs e)
        {
            string clientID = gridClients.CurrentRow.Cells["CLIENT_ID"].Value.ToString();
            if (MessageBox.Show("Are you sure you want to use this client " + clientID, "Update client", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ClientID = clientID;
                this.DialogResult = DialogResult.OK;
            }
        }

        private async void bCreate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to create a new client profile for " + eName.Text, "Create client", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (eName.Text.Length == 0)
                {
                    MessageBox.Show($"A company name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (eAddress1.Text.Length == 0)
                {
                    MessageBox.Show($"An address is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ePostalCode.Text.Length == 0)
                {
                    MessageBox.Show($"A postal code is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (eName.Text.Length > 40) { eName.Text = eName.Text.Substring(1, 40); }
                if (eAddress1.Text.Length > 40) { eAddress1.Text = eAddress1.Text.Substring(1, 40); }
                if (eAddress2.Text.Length > 40) { eAddress2.Text = eAddress2.Text.Substring(1, 40); }
                if (eCity.Text.Length > 30) { eCity.Text = eCity.Text.Substring(1, 30); }
                if (eProv.Text.Length > 4) { eProv.Text = eProv.Text.Substring(1, 4); }
                if (ePostalCode.Text.Length > 10) { ePostalCode.Text = ePostalCode.Text.Substring(1, 10); }
                if (eCountry.Text.Length > 2) { eCountry.Text = eCountry.Text.Substring(1, 2); }
                if (ePhone.Text.Length > 20) { ePhone.Text = ePhone.Text.Substring(1, 20); }
                if (ePhoneExt.Text.Length > 5) { ePhoneExt.Text = ePhoneExt.Text.Substring(1, 5); }
                if (eCell.Text.Length > 20) { eCell.Text = eCell.Text.Substring(1, 20); }
                if (eFax.Text.Length > 20) { eFax.Text = eFax.Text.Substring(1, 20); }
                if (eEMail.Text.Length > 128) { eEMail.Text = eEMail.Text.Substring(1, 128); }
                if (eContact.Text.Length > 40) { eContact.Text = eContact.Text.Substring(1, 40); }

                string shippingList="";
                foreach (string instruction in cblShipping.CheckedItems) 
                {
                    shippingList = shippingList + instruction + ";";
                }

                var result = await _masterDataRepositories.CreateNewClientChange(_dlid, _clientType, 
                        eName.Text.Trim(), eAddress1.Text.Trim(), eAddress2.Text.Trim(), eCity.Text.Trim(), 
                        eProv.Text.Trim(), ePostalCode.Text.Trim(), eCountry.Text.Trim(),
                        ePhone.Text.Trim(), ePhoneExt.Text.Trim(), eCell.Text.Trim(), eFax.Text.Trim(), 
                        eEMail.Text.Trim(), eContact.Text.Trim(), shippingList);

                if (result.isSuccess)
                {
                    ClientID = "";
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($"An error occurred creating the Client Profile. Error: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void eName_DoubleClick(object sender, EventArgs e)
        {
            eFilterName.Text = eName.Text;
        }

        private void eCity_DoubleClick(object sender, EventArgs e)
        {
            eFilterCity.Text = eCity.Text;
        }

        private void frmClientLookup_Load(object sender, EventArgs e)
        {
            SearchClients();
        }

        private async void AddClientReview_Click(object sender, EventArgs e)
        {
            string clientID = gridClients.CurrentRow.Cells["CLIENT_ID"].Value.ToString();
            if (MessageBox.Show("Are you sure you want to mark this client '" + clientID + "' for review?", "Review Client", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var result = await _masterDataRepositories.MarkClientReview(clientID);

                if (!result.isSuccess)
                {
                    MessageBox.Show($"An error occurred marking the Client ID for review. Error: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SearchClients();
            }

        }

        private void gridClients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.gridClients.Columns[e.ColumnIndex].Name == "IN_REVIEW")
            {
                if (e.Value != null && e.Value.ToString() == "1")
                {
                    gridClients.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void menuClients_Opening(object sender, CancelEventArgs e)
        {
            if (gridClients.CurrentRow != null)
            {
                if (gridClients.CurrentRow.Cells["CLIENT_ID"].Value.ToString() != "")
                {
                    if (gridClients.CurrentRow.Cells["IN_REVIEW"].Value.ToString() == "1")
                    {
                        UseClient.Enabled = true;
                        ReviewClient.Enabled = false;
                        RemoveReview.Enabled = true;
                        UpdateClientProfile.Enabled = true;
                    }
                    else
                    {
                        UseClient.Enabled = true;
                        ReviewClient.Enabled = true;
                        RemoveReview.Enabled = false;
                        UpdateClientProfile.Enabled = true;
                    }
                }
                else 
                {
                    UseClient.Enabled = false;
                    ReviewClient.Enabled = false;
                    RemoveReview.Enabled = false;
                    UpdateClientProfile.Enabled = false;
                };
            }
            else
            { 
                UseClient.Enabled = false;
                ReviewClient.Enabled = false;
                RemoveReview.Enabled = false;
                UpdateClientProfile.Enabled = false;
            }
        }

        private async void RemoveReview_Click(object sender, EventArgs e)
        {
            string clientID = gridClients.CurrentRow.Cells["CLIENT_ID"].Value.ToString();
            if (MessageBox.Show("Are you sure you want to remove the client review for '" + clientID + "' ?", "Remove Review Client", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var result = await _masterDataRepositories.RemoveClientReview(clientID);

                if (!result.isSuccess)
                {
                    MessageBox.Show($"An error occurred removing the Client ID for review. Error: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SearchClients();
            }

        }

        private async void UpdateClientProfile_Click(object sender, EventArgs e)
        {
            string clientID = gridClients.CurrentRow.Cells["CLIENT_ID"].Value.ToString();
            string postalCode = gridClients.CurrentRow.Cells["POSTAL_CODE"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to update the client profile for '" + clientID + "' ?", "Update Client Profile", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var result = await _masterDataRepositories.UpdateClientProfile(
                                clientID,
                                gridClients.CurrentRow.Cells["NAME"].Value.ToString(),
                                gridClients.CurrentRow.Cells["ADDRESS_1"].Value.ToString(),
                                gridClients.CurrentRow.Cells["ADDRESS_2"].Value.ToString(),
                                gridClients.CurrentRow.Cells["CITY"].Value.ToString(),
                                gridClients.CurrentRow.Cells["PROVINCE"].Value.ToString(),
                                gridClients.CurrentRow.Cells["COUNTRY"].Value.ToString());

                    if (!result.isSuccess)
                    {
                        MessageBox.Show($"An error occurred removing the Client ID for review. Error: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SearchClients();
                }

        }
        private  void GetShippingInstructions()
        {

            cblShipping.Items.Clear();
            DataTable dt =  _masterDataRepositories.GetShippingInstructions();
            foreach (DataRow row in dt.Rows)
            {
                cblShipping.Items.Add(row[0].ToString());
            }
        }

    }
}

