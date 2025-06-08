using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    private string _connectionString = "Server=localhost;Database=TaskManager;User=root;Password=1234;";

    public List<Task> GetTasks()
    {
        var tasks = new List<Task>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Tasks", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                tasks.Add(new Task
                {
                    Id = reader.GetInt32("Id"),
                    Title = reader.GetString("Title"),
                    Description = reader.GetString("Descripti   on")
                });
            }
        }
        return tasks;
    }
}