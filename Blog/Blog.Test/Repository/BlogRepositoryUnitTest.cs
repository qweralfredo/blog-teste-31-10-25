using Blog.Repository;
using Blog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Test.Repository
{
    public class BlogRepositoryUnitTest
    {
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogRepositoryUnitTest(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [Fact]
        public void GetBlogPostMustBeEmpty()
        {
           

        }
    }
}
