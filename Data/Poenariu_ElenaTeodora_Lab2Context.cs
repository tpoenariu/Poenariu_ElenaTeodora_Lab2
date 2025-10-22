using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poenariu_ElenaTeodora_Lab2.Models;

namespace Poenariu_ElenaTeodora_Lab2.Data
{
    public class Poenariu_ElenaTeodora_Lab2Context : DbContext
    {
        public Poenariu_ElenaTeodora_Lab2Context (DbContextOptions<Poenariu_ElenaTeodora_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Poenariu_ElenaTeodora_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Poenariu_ElenaTeodora_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Poenariu_ElenaTeodora_Lab2.Models.Author> Authors { get; set; } = default!;
        public DbSet<Poenariu_ElenaTeodora_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
