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
    public partial class frmLogin : Form
    {
        private readonly DatabaseRepository _databaseRepository;
        public frmLogin()
        {
            InitializeComponent();
            _databaseRepository = new DatabaseRepository();

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            string dataBase;
            if (cbDataBase.Text == "Borea") { dataBase = "ESKIMO"; }
            else if (cbDataBase.Text == "Geo") { dataBase = "MORNEAU"; }
            else if (cbDataBase.Text == "Global") { dataBase = "GLOBAL"; }
            else if (cbDataBase.Text == "Mornbea") { dataBase = "MORNBEA"; }
            //else if (cbDataBase.Text == "Fraser") { dataBase = "fi222"; }
            //else if (cbDataBase.Text == "GeoTest") { dataBase = "morntest"; }
            else { dataBase = ""; }

            if (eUsername.Text.ToUpper() == "FIRWIN") // Use for testing
            {
                dataBase = "FRASER";
                //ePassword.Text = "";
            }

            if (_databaseRepository.TestConnectionString(dataBase, eUsername.Text, ePassword.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
