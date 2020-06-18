using System.Collections.Generic;
using Lab051.Models.Entities;

namespace Lab051.Models.Repositories
{
    public interface IPostsRepository
    {
        IEnumerable<Post> AllPostsWithComments();
    }
}