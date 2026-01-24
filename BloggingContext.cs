using Microsoft.EntityFrameworkCore;
using System;
using ProjectManager;
using System.Collections.Generic;
using ProjectManager.Models;

public class BloggingContext : DbContext
{
	public DbSet<Blog> Blogs { get; set; }
	public DbSet<Post> Posts { get; set; }
	public DbSet<Worker> Workers { get; set; }
	public DbSet<Team> Teams { get; set; }
	public DbSet<TeamWorker> TeamWorkers { get; set; }


	public DbSet<Customer> Customers { get; set; }
	public DbSet<Employee> Employees { get; set; }
	public DbSet<Todo> Todos { get; set; }
	public DbSet<ProjectManager.Task> Tasks { get; set; }
	public string DbPath { get; }

	public BloggingContext()
	{
		var folder = Environment.SpecialFolder.LocalApplicationData;
		var path = Environment.GetFolderPath(folder);
		DbPath = System.IO.Path.Join(path, "blogging.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Person>().UseTptMappingStrategy();
		modelBuilder.Entity<TeamWorker>()
			.HasKey(p => new { p.TeamId, p.WorkerId });
		modelBuilder.Entity<ProjectManager.Task>()
			.HasKey(task => task.TaskId);
		modelBuilder.Entity<Todo>()
			.HasKey(todo => todo.TodoId);

		base.OnModelCreating(modelBuilder);
	}
	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");
}

public class Blog
{
	public int BlogId { get; set; }
	public string Url { get; set; }

	public List<Post> Posts { get; } = new();
}

public class Post
{
	public int PostId { get; set; }
	public string Title { get; set; }
	public string Content { get; set; }

	public int BlogId { get; set; }
	public Blog Blog { get; set; }
}
