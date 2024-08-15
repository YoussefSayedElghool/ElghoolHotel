using ElghoolHotel.API.Core.Models;
using ElghoolHotel.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ElghoolHotel.API.Seeding
{
    public static class SeedData
    {
        public static void MigrateDatabaseAndSeed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                dbContext.Database.Migrate();



                if (!dbContext.Reviews.Any())
                    SeedReviews(dbContext);

                if (!dbContext.Sliders.Any())
                    SeedSliders(dbContext);

                if (!dbContext.RoomTypes.Any())
                    SeedRoomTypes(dbContext);


                //if (!dbContext.Cities.Any())
                //    SeedCities(dbContext);
                
                //if (!dbContext.Hotels.Any())
                //    SeedHotels(dbContext);

               

                dbContext.SaveChanges();
            }
        }

        private static void SeedReviews(AppDbContext dbContext)
        {
            var file = File.ReadAllText("DataSets\\Reviews.json");

            var data = JsonConvert.DeserializeObject<List<Review>>(file);

            dbContext.Reviews.AddRange(data);
        }
        private static void SeedSliders(AppDbContext dbContext)
        {
            var file = File.ReadAllText("DataSets\\Sliders.json");

            var data = JsonConvert.DeserializeObject<List<Slider>>(file);

            dbContext.Sliders.AddRange(data);
        }        
        
        private static void SeedRoomTypes(AppDbContext dbContext)
        {
            var file = File.ReadAllText("DataSets\\RoomTypes.json");

            var data = JsonConvert.DeserializeObject<List<RoomType>>(file);

            dbContext.RoomTypes.AddRange(data);
        }

        private static void SeedCities(AppDbContext dbContext)
        {
            var file = File.ReadAllText("DataSets\\Cities.json");

            var data = JsonConvert.DeserializeObject<List<City>>(file);

            dbContext.Cities.AddRange(data);
        }
        private static void SeedHotels(AppDbContext dbContext)
        {
            var file = File.ReadAllText("DataSets\\Hotels.json");

            var data = JsonConvert.DeserializeObject<List<Hotel>>(file);

            dbContext.Hotels.AddRange(data);
        }
    }
}