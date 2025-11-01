using Blog.Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Data.Seed
{
    public static class DataSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
 // Seed de BlogPosts
     modelBuilder.Entity<BlogPostEntity>().HasData(
        new BlogPostEntity
    {
   Id = 1,
               Title = "Primeiro Post do Blog",
          Content = "Este é o conteúdo do primeiro post do blog. Aqui podemos escrever sobre diversos assuntos relacionados à tecnologia e desenvolvimento."
           },
           new BlogPostEntity
                {
     Id = 2,
 Title = "Entity Framework Core: Dicas e Truques",
      Content = "O Entity Framework Core é uma ferramenta poderosa para trabalhar com dados em aplicações .NET. Neste post, vamos explorar algumas dicas úteis para maximizar sua produtividade."
 },
             new BlogPostEntity
        {
  Id = 3,
        Title = "Clean Architecture em .NET",
      Content = "A Clean Architecture é um padrão arquitetural que promove a separação de responsabilidades e facilita a manutenção do código. Vamos ver como implementá-la em projetos .NET."
           },
    new BlogPostEntity
     {
         Id = 4,
   Title = "Testes Unitários: Por que são importantes?",
 Content = "Os testes unitários são fundamentais para garantir a qualidade do software. Eles nos ajudam a detectar bugs precocemente e facilitam refatorações futuras."
                },
           new BlogPostEntity
      {
           Id = 5,
        Title = "APIs RESTful com ASP.NET Core",
     Content = "Criar APIs RESTful robustas e escaláveis é uma habilidade essencial para desenvolvedores .NET. Vamos explorar as melhores práticas e padrões."
  }
        );

 // Seed de Comments
 modelBuilder.Entity<CommentEntity>().HasData(
    // Comentários para o Post 1
      new CommentEntity
      {
     Id = 1,
              BlogPostId = 1,
         Content = "Excelente primeiro post! Estou ansioso para ler mais conteúdo do blog."
       },
       new CommentEntity
     {
          Id = 2,
             BlogPostId = 1,
       Content = "Muito bom! A explicação ficou clara e objetiva."
    },

  // Comentários para o Post 2
           new CommentEntity
{
                Id = 3,
    BlogPostId = 2,
        Content = "Entity Framework Core realmente facilita muito o trabalho com banco de dados."
      },
     new CommentEntity
     {
 Id = 4,
    BlogPostId = 2,
         Content = "Poderia fazer um post sobre performance com EF Core?"
       },
       new CommentEntity
 {
           Id = 5,
        BlogPostId = 2,
           Content = "Ótimas dicas! Já estava precisando dessas informações."
     },

           // Comentários para o Post 3
        new CommentEntity
       {
   Id = 6,
                BlogPostId = 3,
            Content = "Clean Architecture mudou completamente como eu estruturo meus projetos."
    },
          new CommentEntity
  {
         Id = 7,
              BlogPostId = 3,
             Content = "Muito didático! Consegui entender os conceitos facilmente."
      },

 // Comentários para o Post 4
             new CommentEntity
           {
 Id = 8,
         BlogPostId = 4,
      Content = "Concordo 100%! Testes são fundamentais para um código de qualidade."
                },
      new CommentEntity
           {
     Id = 9,
            BlogPostId = 4,
                Content = "Vocês usam alguma ferramenta específica para cobertura de testes?"
     },

       // Comentários para o Post 5
       new CommentEntity
         {
       Id = 10,
       BlogPostId = 5,
           Content = "APIs RESTful bem estruturadas fazem toda a diferença no projeto."
      }
    );
      }
    }
}