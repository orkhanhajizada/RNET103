using BlogApplication.Models;
using BlogApplication.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;

namespace BlogApplication.Services;

public class TagService : ITagRepository
{
    private readonly IConfiguration _configuration;
    private readonly IHubContext<SignalRServer> _hubContext;
    public TagService(IConfiguration configuration, IHubContext<SignalRServer> hubContext)
    {
        _configuration = configuration;
        _hubContext = hubContext;
    }

    public IEnumerable<Tag> GetAll()
    {
        string? connectionString = _configuration
            .GetConnectionString("default");
        var tags = new List<Tag>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            connection.Open();
            SqlDependency.Start(connectionString);

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;  // default olarak seçilidir, yazmasanızda olur
            command.Connection = connection;
            command.CommandText = "SELECT [Id], [Name] FROM Tags";

            SqlDependency dependency = new(command);
            dependency.OnChange += Dependency_OnChange;

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var tag = new Tag
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };

                tags.Add(tag);
            }
        }

        return tags;
    }

    private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
    {
        _hubContext.Clients.All.SendAsync("refreshTags");
    }
}
