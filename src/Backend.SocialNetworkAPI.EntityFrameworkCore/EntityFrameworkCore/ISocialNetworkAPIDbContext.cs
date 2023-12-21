using Backend.SocialNetworkAPI.Model;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public interface ISocialNetworkAPIDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Photo> Photo { get; set; }
    DbSet<Post> Post { get; set; }
    DbSet<Comment> Comment { get; set; }
    DbSet<Like> Like { get; set; }
    DbSet<User> User { get; set; }
}