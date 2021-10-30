using Microsoft.EntityFrameworkCore;
using PointsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsMicroservice.DBContext
{
    public class PointsContext : DbContext
    {
        public PointsContext(DbContextOptions<PointsContext> options) : base(options)
        {
        }
        public DbSet<Like> Likes { get; set; }
    }
}
