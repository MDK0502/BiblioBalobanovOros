using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiblioBalobanovOros.ClassFolder
{
    class DGClass
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionBD());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        DataGrid grd;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        public DGClass (DataGrid grid)
        {
            grd = grid;
        }
        public void LoadDG(string command)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(command, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                grd.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
                
            }
        }
        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (grd != null)
                {
                    DataRowView dataRow = grd.SelectedItem as DataRowView;
                    if (dataRow !=null)
                    {
                        DataRow row = dataRow.Row;
                        mass = row.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            return id;
        }
    }
}
