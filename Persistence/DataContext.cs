﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    
    public DbSet<Project> Projects { get; set; }

    public DbSet<Settings> Settings { get; set; }

    public object Get<T>()
    {
        return this.GetType().GetProperty(nameof(T)).Module;
    }    
}