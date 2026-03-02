using Microsoft.Data.SqlClient;
using System.Data;

var ConnectionString = "Data Source=localhost,1433;Initial Catalog=CrmDB;User Id=sa;Password=Nikhil@1234;TrustServerCertificate=True;";

 using var Connection = new SqlConnection(ConnectionString);



try
{
    Connection.Open();
    Console.WriteLine("Connection Opened Successfully");

    // INSERT QUERY
    //var query = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";

    //var command = new SqlCommand(query, Connection);

    //// PARAMETERS (prevents SQL injection)
    //command.Parameters.AddWithValue("@Name", "Nikhil");
    //command.Parameters.AddWithValue("@Email", "nikhil@gmail.com");

    //// Execute query
    //int rowsAffected = command.ExecuteNonQuery();

    //Console.WriteLine("Rows inserted: " + rowsAffected);

    //SqlCommand command= new SqlCommand("SELECT * FROM Customers", Connection);

    //SqlDataReader reader = command.ExecuteReader();

    //while (reader.Read())
    //{
    //    Console.WriteLine($"{reader["Id"]}  {reader["Name"]}  {reader["Email"]} ");
    //}

    void ExecuteReader()
    {
        var query= "Select * from Customers";
        using var Command = new SqlCommand(query, Connection);
        using var Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            Console.WriteLine($"{Reader["Id"]}  {Reader["Name"]}  {Reader["Email"]} ");
        }

    }

    void ExecuteScalar()
    {
        var query = "SELECT COUNT(*) FROM Customers";
        using var Command = new SqlCommand(query, Connection);
        int count = (int)Command.ExecuteScalar();
        Console.WriteLine("Total Customers: " + count);
    }
    void ExecuteNonQuery()
    {
        var query = "INSERT INTO Customers (Name, Email) VALUES ('Soham', 'Soham@gmail.com')";
        using var Command = new SqlCommand(query, Connection);
        var rowsAffected = Command.ExecuteNonQuery();
        Console.WriteLine("Rows Inserted: " + rowsAffected);
    }

    void SqlDataAdapeterDemo()
    {
        var query = "SELECT * FROM Customers";
        SqlCommand sqlCommand = new(query, Connection);
        using var selectAllCustomersCommand = sqlCommand;
        using var adapter = new SqlDataAdapter(selectAllCustomersCommand);
        var customerDataTable = new DataTable();

        adapter.Fill(customerDataTable);

        foreach (DataRow row in customerDataTable.Rows)
        {
            Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Email: {row["Email"]}");
        }
    }


    void InsertCustomerDemo()
    {
        var dataSet = new DataSet();
        var selectQuery = "SELECT * FROM Customers";
        using var selectCommand = new SqlCommand(selectQuery, Connection);
        using var adapter = new SqlDataAdapter(selectCommand);
        adapter.Fill(dataSet, "Customers");

        var dataTable = dataSet.Tables["Customers"];

        var newRow = dataTable.NewRow();
        newRow["Name"] = "New Customer";
        newRow["Email"] = "Vishal@gmail.com";

        dataTable.Rows.Add(newRow);


        adapter.InsertCommand = new SqlCommand("INSERT INTO Customers ( Name, Email) VALUES ( @Name, @Email)", Connection);

        adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
        adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");


        adapter.Update(dataTable);
        dataSet.AcceptChanges();

    }




    //InsertCustomerDemo();


    ExecuteReader();
    //ExecuteScalar();
    //ExecuteNonQuery();

    //SqlDataAdapeterDemo();





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




