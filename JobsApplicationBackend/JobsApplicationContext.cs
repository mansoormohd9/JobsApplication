using JobsApplicationBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApplicationBackend;

public class JobsApplicationContext : DbContext
{
    public JobsApplicationContext(DbContextOptions<JobsApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<JobApplication> JobApplications { get; set; } = null!;
}