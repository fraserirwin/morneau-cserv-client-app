using MorneauCServClient.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorneauCServClient
{
    public partial class frmMain : Form
    {
        private readonly MasterDataRepository _masterDataRepositories;
        private readonly CServRepository _ediRepository;
        private DataTable dtFilters;

        public frmMain()
        {
            InitializeComponent();

            _masterDataRepositories = new MasterDataRepository();
            _ediRepository = new CServRepository();
        }

        private async void RefreshEDIGrid()
        {
            string whereClause = "";
            if (cbFilter.Text.Length > 0)
            {
                foreach (DataRow row in dtFilters.Rows)
                {
                    if (row["QRY_TITLE"].ToString() == cbFilter.Text)
                    {
                        whereClause = row["STATEMENT"].ToString();
                    }
                }
            }
            if (whereClause != "")
            {
                whereClause = " AND " + whereClause;
            }

            gridPendingEDI.DataSource = await _ediRepository.GetFreightBills(whereClause);

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshEDIGrid();
        }

        private async void gridPendingEDI_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPendingEDI.CurrentRow != null)
            {
                int dlid = Convert.ToInt32(gridPendingEDI.CurrentRow.Cells["DETAIL_LINE_ID"].Value);
                string fieldValue = gridPendingEDI.CurrentCell.Value.ToString();
                string columnName = gridPendingEDI.Columns[e.ColumnIndex].Name.ToString();
                string clientType = "";
                if (columnName == "CUSTOMER")
                {
                    clientType = "Caller";
                }
                else if (columnName == "ORIGIN")
                {
                    clientType = "Shipper";
                }
                else if (columnName == "DESTINATION")
                {
                    clientType = "Consignee";
                }

                if ((dlid > 0) && (clientType != ""))
                {

                    frmClientLookup clientLookup = new frmClientLookup(clientType, gridPendingEDI.CurrentRow);
                    if (clientLookup.ShowDialog() == DialogResult.OK)
                    {
                        if (clientLookup.ClientID == "")
                        {
                            RefreshEDIGrid();
                        }
                        else
                        {
                            var result = await _ediRepository.ProcessClientChange(dlid, clientType, clientLookup.ClientID);
                            if (result.isSuccess)
                            {
                                RefreshEDIGrid();
                            }
                            else
                            {
                                MessageBox.Show($"An error occurred updating the Freight Bill. Error: {result.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dtFilters = _masterDataRepositories.GetFilters();

            foreach (DataRow row in dtFilters.Rows)
            {
                cbFilter.Items.Add(row["QRY_TITLE"] .ToString());
            }

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEDIGrid();
        }
    }
}
