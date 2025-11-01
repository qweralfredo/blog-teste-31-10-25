using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Mapper;
using Blog.Application.Mapper.Interface;
using Blog.Infra.Data;
using Blog.Repository;
using Blog.Repository.Interface;
using Blog.Service;
using Blog.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        { 
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
             
            services.AddScoped<IBlogPostService, BlogPostService>();

            services.AddScoped<IBlogPostMapper, BlogPostMapper>();
            services.AddScoped<ICommentMapper, CommentMapper>();

            services.AddDbContextFactory<Context>(options => options.UseInMemoryDatabase("BlogDatabase"));

            return services;
        }
    }
}
