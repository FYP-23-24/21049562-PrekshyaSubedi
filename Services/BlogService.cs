using MitraNepAdven.Context;
using MitraNepAdven.Interfaces;
using MitraNepAdven.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MitraNepAdven.Services
{
    public class BlogService : IBlogService
    {
        private readonly JwtContext _context;

        public BlogService(JwtContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _context.Blog.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _context.Blog.FindAsync(id);
        }

        public async Task<Blog> AddBlogAsync(Blog post)
        {
            var addedPost = _context.Blog.Add(post);
            await _context.SaveChangesAsync();
            return addedPost.Entity;
        }

        public async Task<bool> UpdateBlogAsync(int id, Blog post)
        {
            var existingPost = await _context.Blog.FindAsync(id);
            if (existingPost == null)
                return false;

            existingPost.Title = post.Title;
            existingPost.Description = post.Description;
            // Update other properties as needed

            _context.Blog.Update(existingPost);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var post = await _context.Blog.FindAsync(id);
            if (post == null)
                return false;

            _context.Blog.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public Blog AddBlog(Blog blg)
        {
            throw new NotImplementedException();
        }
    }
}

