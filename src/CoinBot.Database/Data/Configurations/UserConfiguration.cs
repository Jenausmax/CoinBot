using CoinBot.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinBot.Database.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName);

        builder.Property(x => x.LastName);

        builder.Property(x => x.TelegramId);

        builder.Property(x => x.ChatId);

        // Select only non-deleted items filter
        builder.Property(b => b.IsDeleted);
        builder.HasQueryFilter(m => EF.Property<bool>(m, nameof(m.IsDeleted)) == false);
    }
}

