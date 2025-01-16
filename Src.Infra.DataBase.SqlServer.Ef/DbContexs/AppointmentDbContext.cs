using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageUser.Entities;
using Src.Infra.DataBase.SqlServer.Ef.Confinguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.DbContexs
{
    public class AppointmentDbContext: DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RequestConfig());
        }
        public DbSet<Domain.Core.ManageRequest.Entities.Request> Requests { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OldCarRequest> OldCarRequests { get; set; }
    }
}
