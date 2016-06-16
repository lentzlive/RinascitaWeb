using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace remoteaccess
{
    public class RunSP
    {

        private string _connectionString = null;

        public RunSP()
        {
        }

        public RunSP(string conn)
        {
            this._connectionString = conn;
        }



        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Metodo di lancio SP
        /// </summary>
        /// <returns></returns>
        public bool launch_sp(string prw, string conn, Hashtable ht)
        {

            #region Lancio SP per inserimento
            SqlConnection _connDB = null;
            SqlDataReader _rdr = null;


            DataTable dt = new DataTable();
            try
            {
                _connDB = new SqlConnection(conn);
                _connDB.Open();

                SqlCommand _cmd = new SqlCommand(prw, _connDB);

                _cmd.Parameters.Add(new SqlParameter("@dt1", "1"));



                _cmd.CommandType = CommandType.StoredProcedure;
                _rdr = _cmd.ExecuteReader();

                dt = GetTable(_rdr);
            }
            catch (Exception excConn)
            {
                Console.WriteLine(excConn.Message.ToString());
            }
            finally
            {
                if (_connDB != null)
                {
                    _connDB.Close();
                }
                if (_rdr != null)
                {
                    _rdr.Close();
                }
            }
            #endregion

            return true;
        }

        public bool launch_sp(string prw, Hashtable ht)
        {

            #region Lancio SP per inserimento
            SqlConnection _connDB = null;
            SqlDataReader _rdr = null;

            DataTable dt = new DataTable();
            try
            {
                _connDB = new SqlConnection(this._connectionString);
                _connDB.Open();

                SqlCommand _cmd = new SqlCommand(prw, _connDB);
                if (ht != null && ht.Count > 0)
                {
                    foreach (string key in ht.Keys)
                    {
                        Console.WriteLine(key.ToString() + " - " + ht[key].ToString());

                        _cmd.Parameters.Add(new SqlParameter(key.ToString(), ht[key].ToString()));
                    }
                }

                _cmd.CommandType = CommandType.StoredProcedure;
                _rdr = _cmd.ExecuteReader();

                //dt = GetTable(_rdr);
            }
            catch (Exception excConn)
            {
                Console.WriteLine(excConn.Message.ToString());
            }
            finally
            {
                if (_connDB != null)
                {
                    _connDB.Close();
                }
                if (_rdr != null)
                {
                    _rdr.Close();
                }
            }
            #endregion

            return true;
        }

        public DataTable launch_sp_2(string prw, Hashtable ht)
        {

            #region Lancio SP per inserimento
            SqlConnection _connDB = null;
            SqlDataReader _rdr = null;

            DataTable dt = new DataTable();
            try
            {
                _connDB = new SqlConnection(this._connectionString);
                _connDB.Open();

                SqlCommand _cmd = new SqlCommand(prw, _connDB);
                if (ht != null && ht.Count > 0)
                {
                    foreach (string key in ht.Keys)
                    {
                       // Console.WriteLine(key.ToString() + " - " + ht[key].ToString());

                        _cmd.Parameters.Add(new SqlParameter(key.ToString(), ht[key].ToString()));
                    }
                }

                _cmd.CommandType = CommandType.StoredProcedure;
                _rdr = _cmd.ExecuteReader();

                dt = GetTable(_rdr);
            }
            catch (Exception excConn)
            {
                Console.WriteLine(excConn.Message.ToString());
                return null;
            }
            finally
            {
                if (_connDB != null)
                {
                    _connDB.Close();
                }
                if (_rdr != null)
                {
                    _rdr.Close();
                }
            }
            #endregion

            return dt;
        }

        public object launch_sp_scalar(string prw, Hashtable ht)
        {

            #region Lancio SP per inserimento
            SqlConnection _connDB = null;
            SqlDataReader _rdr = null;
            object obj = null;
            DataTable dt = new DataTable();
            try
            {
                _connDB = new SqlConnection(this._connectionString);
                _connDB.Open();

                SqlCommand _cmd = new SqlCommand(prw, _connDB);
                if (ht != null && ht.Count > 0)
                {
                    foreach (string key in ht.Keys)
                    {
                        Console.WriteLine(key.ToString() + " - " + ht[key].ToString());

                        _cmd.Parameters.Add(new SqlParameter(key.ToString(), ht[key].ToString()));
                    }
                }

                _cmd.CommandType = CommandType.StoredProcedure;
                obj = _cmd.ExecuteScalar();


            }
            catch (Exception excConn)
            {
                Console.WriteLine(excConn.Message.ToString());
                return null;
            }
            finally
            {
                if (_connDB != null)
                {
                    _connDB.Close();
                }
                if (_rdr != null)
                {
                    _rdr.Close();
                }
            }
            #endregion

            return obj;
        }
        public static DataTable GetTable(SqlDataReader sqlReader)
        {
            DataTable schemaTable = sqlReader.GetSchemaTable();
            DataTable outputTable = new DataTable();
            DataColumn dcColumn;
            DataRow drRow;

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                dcColumn = new DataColumn();
                if (!outputTable.Columns.Contains(schemaTable.Rows[i]["ColumnName"].ToString()))
                {
                    dcColumn.ColumnName = schemaTable.Rows[i]["ColumnName"].ToString();
                    dcColumn.Unique = Convert.ToBoolean(schemaTable.Rows[i]["IsUnique"]);
                    dcColumn.AllowDBNull = Convert.ToBoolean(schemaTable.Rows[i]["AllowDBNull"]);
                    dcColumn.ReadOnly = Convert.ToBoolean(schemaTable.Rows[i]["IsReadOnly"]);
                    outputTable.Columns.Add(dcColumn);
                }
            }
            while (sqlReader.Read())
            {
                drRow = outputTable.NewRow();
                for (int i = 0; i < sqlReader.FieldCount; i++)
                {
                    drRow[i] = sqlReader.GetValue(i);
                }
                outputTable.Rows.Add(drRow);
            }
            return outputTable;
        }
    }
}
