using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using frutosecoapp.Models;

namespace frutosecoapp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<frutosecoapp.Models.Contact> DataContactos { get; set; }

        public DbSet<frutosecoapp.Models.Product> DataProducts { get; set; }

        public DbSet<frutosecoapp.Models.Proforma> DataProforma { get; set; }

        public DbSet<frutosecoapp.Models.Pago> DataPago { get; set; }

        public DbSet<frutosecoapp.Models.Pedido> DataPedido { get; set; }

        public DbSet<frutosecoapp.Models.DetallePedido> DataDetallePedido { get; set; }

    }
}
