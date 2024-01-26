using System.Data;
using System.Data.SqlClient;
using AdoNet.Models;

namespace AdoNet;

abstract class Program
{
    #region MyRegion

    public static bool CheckConnection()
    {
        // const string connectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=Password123!;";

        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    public static bool AddCategory(Category category)
    {
        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");


                // string commandText = $"INSERT INTO Categories (CategoryName, Description) " +
                //                      $"VALUES ('{category.CategoryName}', '{category.CategoryName}')";
                using (SqlCommand command =
                       new SqlCommand(
                           "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)",
                           connection))
                {
                    //  command.CommandText =
                    // "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";
                    // command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    // command.Parameters.AddWithValue("Description", category.Description);

                    command.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 15).Value = category.CategoryName;
                    command.Parameters.Add("@Description", SqlDbType.NText).Value = category.Description;

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted");
                }

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    public static bool UpdateCategory(Category category)
    {
        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText =
                        "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryId = @CategoryId";
                    // command.Parameters.AddWithValue("@CategoryName", "Test2");
                    // command.Parameters.AddWithValue("@Description", "Test desc2");
                    // command.Parameters.AddWithValue("@CategoryId", 9);

                    command.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 15).Value = category.CategoryName;
                    command.Parameters.Add("@Description", SqlDbType.NText).Value = category.Description;
                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = category.CategoryId;

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated");
                }

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    public static bool DeleteCategory(int categoryId)
    {
        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
                    // command.Parameters.AddWithValue("@CategoryId", 9);

                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) deleted");
                }

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    public static bool GetCategoryById(int categoryId)
    {
        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
                    // command.Parameters.AddWithValue("@CategoryId", 9);

                    command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Category Id: {reader["CategoryId"]}");
                            Console.WriteLine($"Category Name: {reader["CategoryName"]}");
                            Console.WriteLine($"Description: {reader["Description"]}");
                        }
                    }
                }

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    public static bool GetCategories()
    {
        using (var connection = new SqlConnection())
        {
            connection.ConnectionString = "Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123";

            try
            {
                connection.Open();
                Console.WriteLine("Connection is successful");

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Categories";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Category Id: {reader["CategoryId"]}");
                            Console.WriteLine($"Category Name: {reader["CategoryName"]}");
                            Console.WriteLine($"Description: {reader["Description"]}");
                        }
                    }
                }

                connection.Close();
                Console.WriteLine("Connection is closed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return true;
    }

    #endregion


    public static void InsertData(Category catregory)
    {
        SqlConnection connection =
            new SqlConnection("Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.InsertCommand =
            new SqlCommand("INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)",
                connection);
        adapter.InsertCommand.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 15).Value = catregory.CategoryName;
        adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.NText).Value = catregory.Description;

        connection.Open();


        int effectedRows = adapter.InsertCommand.ExecuteNonQuery();
        Console.WriteLine($"{effectedRows} row(s) inserted");

        connection.Close();
    }

    public static void DeleteData(int id)
    {
        SqlConnection connection =
            new SqlConnection("Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.DeleteCommand =
            new SqlCommand("DELETE FROM Categories WHERE CategoryId = @CategoryId", connection);
        adapter.DeleteCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = id;


        connection.Open();

        int effectedRows = adapter.DeleteCommand.ExecuteNonQuery();
        Console.WriteLine($"{effectedRows} row(s) inserted");

        connection.Close();
    }

    public static void UpdateData(Category category)
    {
        SqlConnection connection =
            new SqlConnection("Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123");
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.UpdateCommand =
            new SqlCommand(
                "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryId = @CategoryId",
                connection);
        
        adapter.UpdateCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = category.CategoryId;
        adapter.UpdateCommand.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 15).Value = category.CategoryName;
        adapter.UpdateCommand.Parameters.Add("@Description", SqlDbType.NText).Value = category.Description;

        connection.Open();

        int effectedRows = adapter.UpdateCommand.ExecuteNonQuery();
        Console.WriteLine($"{effectedRows} row(s) inserted");

        connection.Close();
    }


    static void Main(string[] args)
    {
        // CheckConnection();
        //
        // AddCategory(new Category()
        // {
        //     CategoryName = "Test1",
        //     Description = "Test desc1"
        // });

        // UpdateCategory(new Category
        // {
        //     CategoryId = 13,
        //     CategoryName = "Test2",
        //     Description = "Test desc2"
        //
        // });

        // DeleteCategory(13);

        // GetCategoryById(7);

        // GetCategories();


        SqlConnection connectionString =
            new SqlConnection("Server=localhost;Database=Northwind;User Id=sa;Password=reallyStrongPwd123");


        // DATA ADAPTER

        // SqlDataAdapter adapter = new SqlDataAdapter();
        //
        // SqlCommand deleteCommand = new SqlCommand("DELETE FROM Categories WHERE CategoryId = @CategoryId", connectionString);
        // SqlCommand updateCommand = new SqlCommand("UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryId = @CategoryId", connectionString);
        // SqlCommand insertCommand = new SqlCommand("INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)", connectionString);
        // SqlCommand selectByIdCommand = new SqlCommand("SELECT * FROM Categories WHERE CategoryId = @CategoryId", connectionString);
        // SqlCommand selectAllCommand = new SqlCommand("SELECT * FROM Categories", connectionString);
        //
        // adapter.DeleteCommand = deleteCommand;
        // adapter.UpdateCommand = updateCommand;
        // adapter.InsertCommand = insertCommand;
        // adapter.SelectCommand = selectByIdCommand;
        // adapter.SelectCommand = selectAllCommand;
        //
        // adapter.SelectCommand.CommandText = "SELECT CategoryID,Categoryname FROM Categories";
        //
        // adapter.SelectCommand.Connection = connectionString;

        // SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryID,Categoryname FROM Categories", connectionString);

        // SqlDataAdapter adapter = new SqlDataAdapter();
        // adapter.SelectCommand = new SqlCommand("SELECT CategoryID,Categoryname,Description FROM Categories", connectionString);
        //
        // DataTable dt = new DataTable();
        // adapter.Fill(dt);
        //
        // foreach (DataRow row in dt.Rows)
        // {
        //     Console.WriteLine(dt.Rows[0].ItemArray[2]);
        //     Console.WriteLine($"CategoryID: {row["CategoryID"]}");
        //     Console.WriteLine($"Categoryname: {row["Categoryname"]}");
        //     Console.WriteLine($"Description: {row["Description"]}");
        //     Console.WriteLine("---------------------------------------------------");
        //
        // }
        //
        // DataSet ds = new DataSet();
        // adapter.Fill(ds);
        //
        // foreach(DataRow row in ds.Tables[0].Rows)
        // {
        //     Console.WriteLine($"CategoryID: {row["CategoryID"]}");
        //     Console.WriteLine($"Categoryname: {row["Categoryname"]}");
        //     Console.WriteLine($"Description: {row["Description"]}");
        //     Console.WriteLine("---------------------------------------------------");
        // }

        // InsertData(new Category()
        // {
        //     CategoryName = "Test123",
        //     Description = "Test desc123"
        // });

        // DeleteData(15);
        
        
        UpdateData(new Category()
        {
            CategoryId = 14,
            CategoryName = "Test123",
            Description = "Test desc123"
        });
    }
}