using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurneroMVC.Models;

namespace TurneroMVC.Context
{
    public class TurneroDatabaseContext : DbContext
    {
        public TurneroDatabaseContext(DbContextOptions<TurneroDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Turno> Turnos { get; set; }
    }
}
