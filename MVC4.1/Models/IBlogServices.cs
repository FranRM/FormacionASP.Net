using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC4._1.Models
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostsByDate(int year, int month);
        Post GetPost(string slug);
    }
}
