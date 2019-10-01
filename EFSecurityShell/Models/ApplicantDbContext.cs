using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFSecurityShell.Models
{
    public class ApplicantDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}