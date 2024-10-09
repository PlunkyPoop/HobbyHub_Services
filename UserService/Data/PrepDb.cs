using UserService.Models;

namespace UserService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulations(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
              SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Users.Any())
            {
                Console.WriteLine("---> Seeding data ...");
                context.Users.AddRange(
                    new User(){Name="Bob", Created = DateTime.Now}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We have already data");
            }
        }
    }
}