using MongoExample.Entities;

namespace MongoExample.Repositories;

public class CategoryRepository(IConfiguration configuration) : MongoRepository<Category>(configuration)
{
}