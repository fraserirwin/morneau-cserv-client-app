using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorneauCServClient.Repositories
{
    internal class DatabaseRepository
    {
        private readonly string _connectionString;
        private readonly bool _isMultiCompany = false;
        private readonly int _multiCompanyId;

        public DatabaseRepository()
        {
            _connectionString = Properties.Settings.Default["TruckMateDatabaseConnectionString"].ToString();

            // Retrieve the CurrentSchema value
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder(_connectionString);

            if (builder.TryGetValue("CurrentSchema", out object schema))
            {
                Globals.schema = schema.ToString();
            }
            else
            {
                Globals.schema = "LYNX"; //assume TMWIN if omitted
            }

            _connectionString = builder.ConnectionString;

            _multiCompanyId = Properties.Settings.Default.MultiCompanyId;

            _isMultiCompany = (_multiCompanyId > 0);
        }

        public bool TestConnectionString(string dbName, string userID, string passWord)
        {
            // Retrieve the CurrentSchema value
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder(_connectionString);

            builder["Database"] = dbName;
            builder["uid"] = userID;
            builder["pwd"] = passWord;
            builder["CurrentSchema"] = Globals.schema;
            if (dbName == "FLDEV")
            {
                builder["CurrentSchema"] = "LYNX";
            }

            using (OdbcConnection cn = new OdbcConnection(builder.ConnectionString))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("SQL30082N"))
                    {
                        MessageBox.Show("Your username or password are incorrect.", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    return false;
                }

                cn.Close();
            }
            Globals.connectionString = builder.ConnectionString;
            Globals.userID = userID;
            Globals.passWord = passWord;
            
            return true;

        }

        public async Task SetTruckMateStandardPropertiesAsync()
        {
            using (OdbcConnection cn = new OdbcConnection(Globals.connectionString))
            {
                await cn.OpenAsync();

                OdbcCommand cmdSetProperties = new OdbcCommand($"SET SCHEMA = {Globals.schema}; SET PATH = {Globals.schema};", cn);
                await cmdSetProperties.ExecuteNonQueryAsync();

                if (_isMultiCompany)
                {
                    cmdSetProperties.CommandText += $@"SET {Globals.schema}.GV_COMPANY_ID = {this._multiCompanyId}";
                    await cmdSetProperties.ExecuteNonQueryAsync();
                }

                cn.Close();
            }
        }
    }
}
