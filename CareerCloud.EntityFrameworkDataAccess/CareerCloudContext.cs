using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {        
        public CareerCloudContext() : base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString) { }
        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>()
                .HasKey(ae => ae.Id);
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .HasKey(aja => aja.Id);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasKey(ap => ap.Id);
            modelBuilder.Entity<ApplicantSkillPoco>()
                .HasKey(aps => aps.Id);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .HasKey(aw => aw.Id);
            modelBuilder.Entity<CompanyDescriptionPoco>()
                .HasKey(cd => cd.Id);
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .HasKey(cjd => cjd.Id);
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .HasKey(cje => cje.Id);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasKey(cj => cj.Id);
            modelBuilder.Entity<CompanyJobSkillPoco>()
                .HasKey(cjs => cjs.Id);
            modelBuilder.Entity<CompanyLocationPoco>()
                .HasKey(cl => cl.Id);
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasKey(cp => cp.Id);
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasKey(sl => sl.Id);
            modelBuilder.Entity<SecurityLoginsLogPoco>()
                .HasKey(sll => sll.Id);
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .HasKey(slr => slr.Id);
            modelBuilder.Entity<SecurityRolePoco>()
                .HasKey(sr => sr.Id);
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasKey(scc => scc.Code);
            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasKey(slc => slc.LanguageID);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantEducations)
                .WithRequired(ap => ap.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantJobApplications)
                .WithRequired(ap => ap.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantResumes)
                .WithRequired(ap => ap.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantSkills)
                .WithRequired(ap => ap.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantWorkHistories)
                .WithRequired(ap => ap.ApplicantProfile)
                .HasForeignKey(ap => ap.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.ApplicantJobApplications)
                .WithRequired(cj => cj.CompanyJob)
                .HasForeignKey(cj => cj.Job)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobDescriptions)
                .WithRequired(cj => cj.CompanyJob)
                .HasForeignKey(cj => cj.Job)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobEducations)
                .WithRequired(cj => cj.CompanyJob)
                .HasForeignKey(cj => cj.Job)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobSkills)
                .WithRequired(cj => cj.CompanyJob)
                .HasForeignKey(cj => cj.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cj => cj.CompanyDescriptions)
                .WithRequired(cj => cj.CompanyProfile)
                .HasForeignKey(cj => cj.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cj => cj.CompanyLocations)
                .WithRequired(cj => cj.CompanyProfile)
                .HasForeignKey(cj => cj.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(cj => cj.ApplicantProfiles)
                .WithRequired(cj => cj.SecurityLogin)
                .HasForeignKey(cj => cj.Login)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(cj => cj.SecurityLoginsLogs)
                .WithRequired(cj => cj.SecurityLogin)
                .HasForeignKey(cj => cj.Login)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(cj => cj.SecurityLoginsRoles)
                .WithRequired(cj => cj.SecurityLogin)
                .HasForeignKey(cj => cj.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(cj => cj.SecurityLoginsRoles)
                .WithRequired(cj => cj.SecurityRole)
                .HasForeignKey(cj => cj.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(cj => cj.ApplicantProfiles)
                .WithRequired(cj => cj.SystemCountryCode)
                .HasForeignKey(cj => cj.Country)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(cj => cj.ApplicantWorkHistories)
                .WithRequired(cj => cj.SystemCountryCode)
                .HasForeignKey(cj => cj.CountryCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(cj => cj.CompanyDescriptions)
                .WithRequired(cj => cj.SystemLanguageCode)
                .HasForeignKey(cj => cj.LanguageId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
