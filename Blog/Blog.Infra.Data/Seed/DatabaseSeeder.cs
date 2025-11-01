using Blog.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Blog.Infra.Data.Seed
{
    public class DatabaseSeeder
    {
   private readonly Context _context;
        private readonly ILogger<DatabaseSeeder> _logger;

        public DatabaseSeeder(Context context, ILogger<DatabaseSeeder> logger)
        {
     _context = context;
   _logger = logger;
   }

     public async Task SeedAsync()
        {
            try
 {
    // Garantir que o banco existe
        await _context.Database.EnsureCreatedAsync();

 // Verificar se já existem dados
          if (await _context.BlogPosts.AnyAsync())
       {
  _logger.LogInformation("Database already contains data. Skipping seed.");
      return;
  }

    _logger.LogInformation("Seeding database with initial data...");

        // Criar blog posts
         var blogPosts = new List<BlogPostEntity>
     {
     new BlogPostEntity
     {
                  Title = "Primeiro Post do Blog",
              Content = "Este é o conteúdo do primeiro post do blog. Aqui podemos escrever sobre diversos assuntos relacionados à tecnologia e desenvolvimento."
            },
  new BlogPostEntity
        {
      Title = "Entity Framework Core: Dicas e Truques",
      Content = "O Entity Framework Core é uma ferramenta poderosa para trabalhar com dados em aplicações .NET. Neste post, vamos explorar algumas dicas úteis para maximizar sua produtividade."
       },
        new BlogPostEntity
   {
 Title = "Clean Architecture em .NET",
           Content = "A Clean Architecture é um padrão arquitetural que promove a separação de responsabilidades e facilita a manutenção do código. Vamos ver como implementá-la em projetos .NET."
                },
             new BlogPostEntity
  {
         Title = "Testes Unitários: Por que são importantes?",
    Content = "Os testes unitários são fundamentais para garantir a qualidade do software. Eles nos ajudam a detectar bugs precocemente e facilitam refatorações futuras."
        },
        new BlogPostEntity
  {
    Title = "APIs RESTful com ASP.NET Core",
       Content = "Criar APIs RESTful robustas e escaláveis é uma habilidade essencial para desenvolvedores .NET. Vamos explorar as melhores práticas e padrões."
         }
      };

 _context.BlogPosts.AddRange(blogPosts);
       await _context.SaveChangesAsync();

         // Buscar os posts criados para obter os IDs gerados
        var createdPosts = await _context.BlogPosts.ToListAsync();

         // Criar comentários
    var comments = new List<CommentEntity>
         {
            // Comentários para o primeiro post
                new CommentEntity
             {
      BlogPostId = createdPosts[0].Id,
       Content = "Excelente primeiro post! Estou ansioso para ler mais conteúdo do blog."
            },
     new CommentEntity
       {
    BlogPostId = createdPosts[0].Id,
 Content = "Muito bom! A explicação ficou clara e objetiva."
   },

         // Comentários para o segundo post
    new CommentEntity
             {
         BlogPostId = createdPosts[1].Id,
  Content = "Entity Framework Core realmente facilita muito o trabalho com banco de dados."
    },
     new CommentEntity
        {
    BlogPostId = createdPosts[1].Id,
        Content = "Poderia fazer um post sobre performance com EF Core?"
    },
         new CommentEntity
         {
       BlogPostId = createdPosts[1].Id,
       Content = "Ótimas dicas! Já estava precisando dessas informações."
          },

                    // Comentários para o terceiro post
    new CommentEntity
        {
      BlogPostId = createdPosts[2].Id,
             Content = "Clean Architecture mudou completamente como eu estruturo meus projetos."
    },
     new CommentEntity
        {
       BlogPostId = createdPosts[2].Id,
   Content = "Muito didático! Consegui entender os conceitos facilmente."
  },

          // Comentários para o quarto post
  new CommentEntity
           {
                   BlogPostId = createdPosts[3].Id,
         Content = "Concordo 100%! Testes são fundamentais para um código de qualidade."
            },
              new CommentEntity
      {
 BlogPostId = createdPosts[3].Id,
  Content = "Vocês usam alguma ferramenta específica para cobertura de testes?"
   },

              // Comentários para o quinto post
      new CommentEntity
         {
  BlogPostId = createdPosts[4].Id,
               Content = "APIs RESTful bem estruturadas fazem toda a diferença no projeto."
  }
     };

     _context.Comments.AddRange(comments);
   await _context.SaveChangesAsync();

        _logger.LogInformation("Database seeded successfully with {PostCount} posts and {CommentCount} comments.", 
   blogPosts.Count, comments.Count);
        }
  catch (Exception ex)
   {
    _logger.LogError(ex, "An error occurred while seeding the database.");
     throw;
     }
        }
  }
}