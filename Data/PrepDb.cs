using PlatformService.Model;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //get db context service
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        public static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine(" --> Seeding Data...");
                context.Platforms.AddRange(
                        new Platform()
                        {
                            Name = "Dot Net",
                            Publisher = "Microsoft",
                            Cost = "Free"
                        },
                        new Platform()
                        {
                            Name = "Python",
                            Publisher = "Facebook",
                            Cost = "Free"
                        },
                        new Platform()
                        {
                            Name = "JAVA",
                            Publisher = "Oracle",
                            Cost = "Free"
                        }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine(" --> We already have data");
            }
        }
    }
}
