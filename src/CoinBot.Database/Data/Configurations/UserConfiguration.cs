using CoinBot.Database.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinBot.Database.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);

        builder.Property(x => x.ChatId);

        // Select only non-deleted items filter
        builder.Property(b => b.IsDeleted);
        builder.HasQueryFilter(m => EF.Property<bool>(m, nameof(m.IsDeleted)) == false);
    }
}

