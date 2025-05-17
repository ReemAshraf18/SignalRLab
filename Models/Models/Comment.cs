using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired().HasMaxLength(500);
            builder.Property(c => c.UserName).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);
        }
    }
}

