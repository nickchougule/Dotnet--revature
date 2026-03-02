using Microsoft.Data.SqlClient;
using System;
using System.Data;

class Program
{
    static void Main()
    {
        var connectionString =
        "Data Source=localhost,1433;Initial Catalog=CrmDb;User ID=sa;Password=Soham@2212;TrustServerCertificate=True";
        var Connection = new SqlConnection(connectionString);
        try
            {
                Connection.Open();
                Console.WriteLine("Connection Opened Successfully");
                //ExecuteNonQuery(Connection);
                //ExecuteScalar(Connection);
                ExecuteReader(Connection);
            //SqlDataAdapeterDemo(Connection);
            //InsertCustomerDemo(Connection);
            //// INSERT QUERY
            //var query = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";

            //var command = new SqlCommand(query, Connection);

            //// PARAMETERS (prevents SQL injection)
            //command.Parameters.AddWithValue("@Name", "Soham");
            //command.Parameters.AddWithValue("@Email", "Soham@gmail.com");

            //// Execute query
            //int rowsAffected = command.ExecuteNonQuery();

            //Console.WriteLine("Rows inserted: " + rowsAffected);
            //SqlCommand command=new SqlCommand("SELECT * FROM Customers", Connection);
            //SqlDataReader reader=command.ExecuteReader();
            //while(reader.Read())
            //{
            //    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Email: {reader["Email"]}");
            //}
            void ExecuteScalar(SqlConnection connection)
                {
                    var query = "SELECT COUNT(*) FROM Customers";
                    using var command = new SqlCommand(query, connection);
                    var count = (int)command.ExecuteScalar();
                    Console.WriteLine("Total Customers: " + count);
                }
                void ExecuteNonQuery(SqlConnection connection)
                {
                    var query = "Insert into Customers (Name,Email) values('bishal','vishal@gmail.com')";
                    using var command = new SqlCommand(query, connection);
                    var rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Rows Inserted: " + rowsAffected);
                }
                void ExecuteReader(SqlConnection connection)
                {
                    var query = "SELECT * FROM Customers";
                    using var command = new SqlCommand(query, connection);
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Email: {reader["Email"]}");
                    }
                }
                void SqlDataAdapeterDemo(SqlConnection connection)
                {
                    var query = "SELECT * FROM Customers";
                    SqlCommand sqlCommand = new(query, connection);
                    using var selectAllCustomersCommand = sqlCommand;
                    using var adapter = new SqlDataAdapter(selectAllCustomersCommand);
                    var customerDataTable = new DataTable();

                    adapter.Fill(customerDataTable);

                    foreach (DataRow row in customerDataTable.Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Email: {row["Email"]}");
                    }
                }
            void InsertCustomerDemo(SqlConnection connection)
            {
                var dataSet = new DataSet();
                var selectQuery = "SELECT * FROM Customers";
                using var selectCommand = new SqlCommand(selectQuery, connection);
                using var adapter = new SqlDataAdapter(selectCommand);
                adapter.Fill(dataSet, "Customers");

                var dataTable = dataSet.Tables["Customers"];

                var newRow = dataTable.NewRow();
             
                
                 newRow["Name"] = "New Customer";
                newRow["email"] = "new@email.com";

                dataTable.Rows.Add(newRow);

                adapter.InsertCommand = new SqlCommand("INSERT INTO Customers ( Name, Email) VALUES (@Name, @Email)", connection);

                //adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 6, "Id");
                adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 0, "Email");
                adapter.Update(dataSet, "Customers");
                dataSet.AcceptChanges();
            }

        }
        catch (Exception ex)
            {
                    Console.WriteLine("Error Occured: " + ex.Message);
            }
            finally
            {
                Connection.Close();
                Console.WriteLine("Connection Closed");
            }

        Console.ReadLine(); // prevents console from closing
    }
}
