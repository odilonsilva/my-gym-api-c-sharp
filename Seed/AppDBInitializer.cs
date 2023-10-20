using api.Models;
using api.Repositories;

namespace api.Seed
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApiContext>();

                if (!context.Categories.Any())
                {
                    context.AddRange(
                        new Category()
                        {
                            Id = 1,
                            Name = "Peito"
                        },
                        new Category()
                        {
                            Id = 2,
                            Name = "Ombro",
                        },
                        new Category()
                        {
                            Id = 3,
                            Name = "Biceps",
                        },
                        new Category()
                        {
                            Id = 4,
                            Name = "Triceps",
                        },
                        new Category()
                        {
                            Id = 5,
                            Name = "Pernas anterior",
                        },
                        new Category()
                        {
                            Id = 6,
                            Name = "Pernas Posterior",
                        },
                        new Category()
                        {
                            Id = 7,
                            Name = "Gluteos",
                        },
                        new Category()
                        {
                            Id = 8,
                            Name = "Costas",
                        },
                        new Category()
                        {
                            Id = 9,
                            Name = "Pernas",
                        },
                        new Category()
                        {
                            Id = 10,
                            Name = "Braços",
                        }
                    );
                    context.SaveChanges();
                }
                
                if (!context.Exercises.Any())
                {
                    context.AddRange(
                        new Exercise()
                        {
                            Description = "Flexão",
                            CategoryId = 1,
                            Image = "/img/treino_A-flexao.png"
                        },
                        new Exercise()
                        {
                            Description = "Supino reto com barra",
                            CategoryId = 1,
                            Image = "/img/treino_A-supino-reto-barra.png"
                        },
                        new Exercise()
                        {
                            Description = "Crixifico inclinado com halter",
                            CategoryId = 1,
                            Image = "/img/treino_A-cruxifico-inclinado.png"
                        },
                         new Exercise()
                         {
                             Description = "Peck Deck",
                             CategoryId = 1,
                             Image = "/img/treino_A-peck-deck.png"
                         },
                         new Exercise()
                         {
                             Description = "Triceps polia barra reta",
                             CategoryId = 4,
                             Image = "/img/treino_A-triceps-barra-reta.png"
                         },
                         new Exercise()
                         {
                             Description = "Triceps polia inverso",
                             CategoryId = 4,
                             Image = "/img/treino_A-tricep-polia-invertido.png"
                         },
                         new Exercise()
                         {
                             Description = "Desenvolvimento aberto maquina",
                             CategoryId = 2,
                             Image = "/img/treino_A-desenvolvimento-aberto.png"
                         },
                         new Exercise()
                         {
                             Description = "Elevação multipla",
                             CategoryId = 2,
                             Image = "/img/treino_A-elevacao-multipla.png"
                         }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
