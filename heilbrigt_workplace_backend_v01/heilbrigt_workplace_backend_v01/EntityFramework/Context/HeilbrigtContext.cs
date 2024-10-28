using heilbrigt_workplace_backend_v01.EntityFramework.Models.User;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace heilbrigt_workplace_backend_v01.EntityFramework.Context
{
    public class HeilbrigtContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=heilbrigt;Uid=DevConnection;Pwd=rH75207314AtF;Sslmode=none",
                 new MySqlServerVersion(new Version(10, 5)));
        }

        // Editor
        public DbSet<User> User { get; set; }

    }
}
