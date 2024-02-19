using BlogApplication.Models;
using Microsoft.Data.SqlClient;

namespace BlogApplication.Repositories;

public interface ITagRepository
{
    IEnumerable<Tag> GetAll();
}