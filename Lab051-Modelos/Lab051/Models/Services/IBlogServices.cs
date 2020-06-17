using System.Collections.Generic;
using Lab051.Models.Entities;

namespace Lab051.Models.Services
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostsByDate(int year, int month);
        Post GetPost(string slug);
        IEnumerable<ArchiveEntry> GetArchiveIndex();
    }
}