using MitraNepAdven.Models;
using MitraNepAdven.Services;

namespace MitraNepAdven.Interfaces
{
    public interface IBlogService
    {
        //Task<List<Blog>> GetAllBlogAsync();
        public Blog AddBlog(Blog blg);
        Task<List<Blog>> GetAllBlogAsync();

        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> AddBlogAsync(Blog blog);
        Task<bool> UpdateBlogAsync(int id, Blog blog);
        Task<bool> DeleteBlogAsync(int id);
    }
}
