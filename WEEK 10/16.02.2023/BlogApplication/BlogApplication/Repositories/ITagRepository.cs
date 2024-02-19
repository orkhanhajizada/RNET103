using BlogApplication.Models;

namespace BlogApplication.Repositories;

public interface ITagRepository
{
    IEnumerable<Tag> GetAll();
}
