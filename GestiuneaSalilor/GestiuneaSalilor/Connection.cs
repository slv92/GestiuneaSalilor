using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestiuneaSalilor
{
    class Connection
    {
            string connectionString = "Data Source=(local) ;Initial Catalog=Sali ;Integrated Security=SSPI";
        

        

         // Select Query
      public DataTable Select(string sql, bool isProcedure, Dictionary<string, string> parameters = null)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        if (isProcedure) sqlCommand.CommandType = CommandType.StoredProcedure;
                        else sqlCommand.CommandType = CommandType.Text;
                        if (parameters != null)
                            foreach (KeyValuePair<string, string> parameter in parameters)
                                sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sqlDataAdapter.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }

            catch (SqlException e)
            {
                MessageBox.Show("Error - Connection.executeSelectQuery ");
                return null;
            }


        }

       
        // Insert/Update/Delete Query
      
        public bool InsertUpdateDelete(string sql, Dictionary<string, string> parameters, bool isProcedure)
        {
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        if (isProcedure)
                            sqlCommand.CommandType =
                               System.Data.CommandType.StoredProcedure;
                        else sqlCommand.CommandType = System.Data.CommandType.Text;

                        // Adding parameters using Dictionary...
                        foreach (KeyValuePair<string, string> parameter in parameters)
                            sqlCommand.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                        if (sqlCommand.ExecuteNonQuery() > 0) return true;
                        else return false;
                    }
                }

            }



            catch (SqlException e)
            {
                MessageBox.Show("Error - Connection.executeInsertUpdateDeleteQuery ");
                return false;
            }






        }
    
    
    
    
    
    }




}
