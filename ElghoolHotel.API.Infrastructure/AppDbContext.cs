using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElghoolHotel.API.Models;
using ElghoolHotel.API.Core.Contract.Repository;
using ElghoolHotel.API.Core.Repository.abstraction_layer;
using ElghoolHotel.API.Core.Models;

namespace ElghoolHotel.API.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Bag> Bags { get; set; }

    }
     
}
