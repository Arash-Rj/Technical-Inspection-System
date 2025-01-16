using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.ManageRequest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Confinguration
{
    public class RequestConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasOne(r => r.User).WithMany(u => u.Requests).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Car).WithMany(u => u.Requests).HasForeignKey(r => r.CarId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
