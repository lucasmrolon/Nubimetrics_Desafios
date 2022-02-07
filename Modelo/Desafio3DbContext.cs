using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Desafio3DbContext : DbContext
    {
        public Desafio3DbContext(DbContextOptions<Desafio3DbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
