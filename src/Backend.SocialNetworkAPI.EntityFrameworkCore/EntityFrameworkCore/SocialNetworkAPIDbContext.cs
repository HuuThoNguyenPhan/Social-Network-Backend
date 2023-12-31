﻿using Backend.SocialNetworkAPI.Model;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Backend.SocialNetworkAPI.EntityFrameworkCore;

[ConnectionStringName(SocialNetworkAPIDbProperties.ConnectionStringName)]
public class SocialNetworkAPIDbContext : AbpDbContext<SocialNetworkAPIDbContext>, ISocialNetworkAPIDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public SocialNetworkAPIDbContext(DbContextOptions<SocialNetworkAPIDbContext> options)
        : base(options)
    {
    }

    public DbSet<Photo> Photo { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<Like> Like { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSocialNetworkAPI();
    }
}