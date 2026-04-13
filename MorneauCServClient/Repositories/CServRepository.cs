using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorneauCServClient.Repositories
{
    internal class CServRepository
    {
        private readonly string _connectionString;

        public CServRepository()
        {
            //_connectionString = Properties.Settings.Default["TruckMateDatabaseConnectionString"].ToString();
            _connectionString = Globals.connectionString;
        }

        public async Task<DataTable> GetFreightBills(string whereClause)
        {
            DataTable freightDataTable = new DataTable();

            string freightSql = @"SELECT DETAIL_LINE_ID, BILL_NUMBER,
                    CUSTOMER, CALLNAME, CALLADDR1, CALLADDR2, CALLCITY, CALLPROV, CALLPC, CALLPHONE, CALLPHONEEXT, CALLFAX, CALLCELL, CALLCONTACT, CALLEMAIL, CALLCOUNTRY,
                    ORIGIN, ORIGNAME, ORIGADDR1, ORIGADDR2, ORIGCITY, ORIGPROV, ORIGPC, ORIGPHONE, ORIGPHONEEXT, ORIGFAX, ORIGCELL, ORIGCONTACT, ORIGEMAIL, ORIGCOUNTRY, START_ZONE,
                    DESTINATION, DESTNAME, DESTADDR1, DESTADDR2, DESTCITY, DESTPROV, DESTPC, DESTPHONE, DESTPHONEEXT, DESTFAX, DESTCELL, DESTCONTACT, DESTEMAIL, DESTCOUNTRY, END_ZONE
                    FROM TLORDER 
                    WHERE INTERFACE_STATUS_F IS NULL 
                    AND ((CUSTOMER = '') OR (CUSTOMER IS NULL) OR (ORIGIN = '') OR (ORIGIN IS NULL) OR (DESTINATION = '') OR (DESTINATION IS NULL)) "
                        +  whereClause +
                    " ORDER BY DETAIL_LINE_ID";


            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
                await cnTruckMate.OpenAsync();
                OdbcCommand cmdGetFreight = new OdbcCommand(freightSql, cnTruckMate);

                freightDataTable.Load(await cmdGetFreight.ExecuteReaderAsync());
                cnTruckMate.Close();
            }

            return freightDataTable;
        }

        public async Task<(bool isSuccess, string message)> ProcessClientChange(int dlid, string clientType, string clientID)
        {

            string errorMessage = "";
            using (OdbcConnection cnTruckMate = new OdbcConnection(_connectionString))
            {
            await cnTruckMate.OpenAsync();
              OdbcTransaction tx = cnTruckMate.BeginTransaction();

                try
                {
                    OdbcCommand cmdSetClientID = new OdbcCommand($"CALL {Globals.schema}.MORNEAU_CLIENT_UPDATE (?, ?, ?, ?, ?) ", cnTruckMate,tx);
                    cmdSetClientID.CommandType = CommandType.StoredProcedure;
                    cmdSetClientID.Parameters.AddWithValue("iDLID", dlid);
                    cmdSetClientID.Parameters.AddWithValue("iTYPE", clientType);
                    cmdSetClientID.Parameters.AddWithValue("iCLIENT_ID", clientID);
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
    }
}
