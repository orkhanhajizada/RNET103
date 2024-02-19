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
        var connection = _configuration.GetConnectionString("DefaultConnection");

        var tags = new List<Tag>();
        using (SqlConnection sqlConnection = new SqlConnection(connection))
        {
            sqlConnection.Open();
            SqlDependency.Start(connection);

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = sqlConnection;
            command.CommandText = "SELECT [Id], [Name] FROM Tags";

            SqlDependency dependency = new SqlDependency(command);
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
        _hubContext.Clients.All.SendAsync("refrshTags");
    }
}