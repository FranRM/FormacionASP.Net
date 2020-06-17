using System.Collections.Generic;
using System.Linq;
using Lab051.Models.Entities;

namespace Lab051.Models.Repositories.InMemory
{
    public class InMemoryPostsRepository: IPostsRepository
    {
        private static List<Post> Posts { get; set; }
        static InMemoryPostsRepository()
        {
            Posts = DataInitializer.CreateFakePostsWithComments("memory");
        }

        public IEnumerable<Post> AllPostsWithComments()
        {
            return Posts.AsQueryable();
        }
    }
}
