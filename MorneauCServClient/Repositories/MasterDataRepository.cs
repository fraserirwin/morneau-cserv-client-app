using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace MorneauCServClient.Repositories
{
    internal class MasterDataRepository
    {
        private readonly string _connectionString;

        public MasterDataRepository()
        {
//            _connectionString = Properties.Settings.Default["TruckMateDatabaseConnectionString"].ToString();
            _connectionString = Globals.connectionString;
        }

        public async Task<DataTable> GetClientsAsync(string address, string postalCode, string name, string city)
        {
            DataTable clientDataTable = new DataTable();

            string clientSql = @"SELECT CLIENT_ID, NAME, ADDRESS_1, ADDRESS_2, CITY, PROVINCE, POSTAL_CODE, DEFAULT_DELIVERY_Z, COUNTRY,
                                    (SELECT 1 FROM MORNEAU_CLIENT_PROFILE_REVIEW R WHERE R.CLIENT_ID = CLIENT.CLIENT_ID AND R.REVIEWED = 'False') IN_REVIEW
                                    FROM CLIENT
									WHERE IS_INACTIVE = 'False'
                                    AND ADDRESS_1 LIKE ?
                                    AND NAME LIKE ?
                                    AND CITY LIKE ?
									AND POSTAL_CODE LIKE ?
                                    ORDER BY CLIENT_ID ";// Use DEFAULT_DELIVERY_Z ???

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcCommand cmdGetCurrentInventory = new OdbcCommand(clientSql, cnTruckMate);
                cmdGetCurrentInventory.Parameters.AddWithValue("Address", address);
                cmdGetCurrentInventory.Parameters.AddWithValue("Name", name);
                cmdGetCurrentInventory.Parameters.AddWithValue("City", city);
                cmdGetCurrentInventory.Parameters.AddWithValue("PostalCode", postalCode);

                clientDataTable.Load(await cmdGetCurrentInventory.ExecuteReaderAsync());
                cnTruckMate.Close();
            }

            return clientDataTable;
        }

        public async Task<(bool isSuccess, string message)> CreateNewClientChange(int dlid, string clientType,
                string name, string address1, string address2, string city, string prov, string postalCode, string country,
                string businessPhone, string businessPhoneExt, string businessCell, string faxPhone, string email, string contact, string shippingInstructions)
        {

            string errorMessage = "";
            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcTransaction tx = cnTruckMate.BeginTransaction();

                try
                {
                    OdbcCommand cmdSetClientID = new OdbcCommand($"CALL {Globals.schema}.MORNEAU_CLIENT_INSERT( ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", cnTruckMate, tx);
                    cmdSetClientID.Parameters.AddWithValue("iDLID", dlid);
                    cmdSetClientID.Parameters.AddWithValue("iTYPE", clientType);
                    cmdSetClientID.Parameters.AddWithValue("iNAME", name);
                    cmdSetClientID.Parameters.AddWithValue("iADDRESS_1", address1);
                    cmdSetClientID.Parameters.AddWithValue("iADDRESS_2", address2);
                    cmdSetClientID.Parameters.AddWithValue("iCITY", city);
                    cmdSetClientID.Parameters.AddWithValue("iFAX_PHONE", faxPhone);
                    cmdSetClientID.Parameters.AddWithValue("iEMAIL_ADDRESS", email);
                    cmdSetClientID.Parameters.AddWithValue("iBUSINESS_PHONE_EXT", businessPhoneExt);
                    cmdSetClientID.Parameters.AddWithValue("iBUSINESS_CELL", businessCell);
                    cmdSetClientID.Parameters.AddWithValue("iPROVINCE", prov);
                    cmdSetClientID.Parameters.AddWithValue("iPOSTAL_CODE", postalCode);
                    cmdSetClientID.Parameters.AddWithValue("iBUSINESS_PHONE", businessPhone);
                    cmdSetClientID.Parameters.AddWithValue("iCONTACT", contact);
                    cmdSetClientID.Parameters.AddWithValue("iZONE", postalCode);
                    cmdSetClientID.Parameters.AddWithValue("iCOUNTRY", country);
                    cmdSetClientID.Parameters.AddWithValue("iSHIPPING_INSTRUCTIONS", shippingInstructions);
                    cmdSetClientID.Parameters.AddWithValue("iTABLE", "TLORDER");
                    cmdSetClientID.Parameters.Add("oERROR_MESSAGE", OdbcType.VarChar, 100).Direction = ParameterDirection.Output;
                    await cmdSetClientID.ExecuteNonQueryAsync();
                    errorMessage = cmdSetClientID.Parameters["oERROR_MESSAGE"].Value.ToString();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return (false, ex.Message);
                }
                finally
                {
                    cnTruckMate.Close();
                }

                if (errorMessage == "")
                {
                    return (true, "");
                }
                else
                {
                    return (false, errorMessage);
                }
            }

        }
        public async Task<(bool isSuccess, string message)> MarkClientReview( string clientID)
        {

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcTransaction tx = cnTruckMate.BeginTransaction();

                try
                {
                    OdbcCommand cmdSetClientID = new OdbcCommand("INSERT INTO MORNEAU_CLIENT_PROFILE_REVIEW (CLIENT_ID) VALUES (?)", cnTruckMate, tx);
                    cmdSetClientID.Parameters.AddWithValue("iCLIENT_ID", clientID);
                    await cmdSetClientID.ExecuteNonQueryAsync();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return (false, ex.Message);
                }
                finally
                {
                    cnTruckMate.Close();
                }

                return (true, "");
            }

        }

        public async Task<(bool isSuccess, string message)> RemoveClientReview(string clientID)
        {

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcTransaction tx = cnTruckMate.BeginTransaction();

                try
                {
                    OdbcCommand cmdSetClientID = new OdbcCommand("DELETE FROM MORNEAU_CLIENT_PROFILE_REVIEW WHERE CLIENT_ID = (?)", cnTruckMate, tx);
                    cmdSetClientID.Parameters.AddWithValue("iCLIENT_ID", clientID);
                    await cmdSetClientID.ExecuteNonQueryAsync();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return (false, ex.Message);
                }
                finally
                {
                    cnTruckMate.Close();
                }

                return (true, "");
            }

        }

        public async Task<(bool isSuccess, string message)> UpdateClientProfile(string clientID, string clientName, string cAddr1, string cAddr2, string cCity, string cProvince, string cCountry)
        {

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcTransaction tx = cnTruckMate.BeginTransaction();

                try
                {
                    OdbcCommand cmdSetClientID = new OdbcCommand("UPDATE CLIENT SET NAME = (?), ADDRESS_1 = (?), ADDRESS_2 = (?), CITY = (?), PROVINCE = (?), COUNTRY = (?) WHERE CLIENT_ID = (?)", cnTruckMate, tx);
                    cmdSetClientID.Parameters.AddWithValue("iNAME", clientName);
                    cmdSetClientID.Parameters.AddWithValue("iADDRESS_1", cAddr1);
                    cmdSetClientID.Parameters.AddWithValue("iADDRESS_2", cAddr2);
                    cmdSetClientID.Parameters.AddWithValue("iCITY", cCity);
                    cmdSetClientID.Parameters.AddWithValue("iPROVINCE", cProvince);
                    cmdSetClientID.Parameters.AddWithValue("iCOUNTRY", cCountry);
                    cmdSetClientID.Parameters.AddWithValue("iCLIENT_ID", clientID);
                    await cmdSetClientID.ExecuteNonQueryAsync();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return (false, ex.Message);
                }
                finally
                {
                    cnTruckMate.Close();
                }

                return (true, "");
            }

        }

        public DataTable GetFilters()
        {
            DataTable filterDataTable = new DataTable();
            filterDataTable.Columns.Add("QRY_TITLE", typeof(string));
            filterDataTable.Columns.Add("STATEMENT", typeof(string));

            string filterSql = @"SELECT QRY_TITLE, STATEMENT
                                    FROM DATA_SHEET_VIEW
                                    WHERE STRPOS(QRY_TITLE, 'MISSING ACCOUNT') > 0
                                    ORDER BY QRY_TITLE";

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                cnTruckMate.OpenAsync();
                OdbcCommand cmdGetFilters = new OdbcCommand(filterSql, cnTruckMate);
                filterDataTable.Load(cmdGetFilters.ExecuteReader());
                cnTruckMate.Close();
            }

            return filterDataTable;
        }

        public bool IsValidZone(string postalCode)
        {
            DataTable zoneDataTable = new DataTable();

            string zoneSql = @"SELECT ZONE_ID FROM ZONE WHERE ZONE_ID = (?)";

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                cnTruckMate.OpenAsync();
                OdbcCommand cmdGetZoneCount = new OdbcCommand(zoneSql, cnTruckMate);
                cmdGetZoneCount.Parameters.AddWithValue("ZoneID", postalCode);

                zoneDataTable.Load(cmdGetZoneCount.ExecuteReader());
                cnTruckMate.Close();
            }

            if (zoneDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetShippingInstructions()
        {
            DataTable shippingDataTable = new DataTable();
            shippingDataTable.Columns.Add("INSTRUCTION", typeof(string));

            string shippingSql = @"SELECT INSTRUCTION 
                                    FROM SHIPINSTRUCT
                                    WHERE SHORT_DESC IN ('HOME','PCAMLIVR','PCAMCUEIL','TAILCUEIL','TAILLIVR')
                                    ORDER BY INSTRUCTION";

            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                cnTruckMate.OpenAsync();
                OdbcCommand cmdGetShipping = new OdbcCommand(shippingSql, cnTruckMate);
                shippingDataTable.Load(cmdGetShipping.ExecuteReader());
                cnTruckMate.Close();
            }

            return shippingDataTable;
        }
    }
}

