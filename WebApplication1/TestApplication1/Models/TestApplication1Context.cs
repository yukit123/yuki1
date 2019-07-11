using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestApplication1.Models
{
    public class TestApplication1Context: DbContext
    {
        public DbSet<Charter> Charters { get; set; }

        public DbSet<CountrySize> CountrySizes { get; set; }
        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<author2> author2s { get; set; }
        public DbSet<book2> book2s { get; set; }

        public DbSet<SampleViewModel> SampleViewModels { get; set; }
        public DbSet<OpsModel> OpsModels { get; set; }
        public DbSet<RMA_History> RMA_Histories { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupProperty> GroupProperties { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<expert> experts { get; set; }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<StudentAccount> StudentAccounts { get; set; }

        
        public DbSet<Student121> Student121s { get; set; }
        public DbSet<StudentAddress121> StudentAddress121s { get; set; }

        public DbSet<Type_Service> Type_Services { get; set; }
        public DbSet<Pation> Pations { get; set; }

        //public DbSet<ViewModelAttendanceClients2> ViewModelAttendanceClients2s { get; set; }
        //public DbSet<TimeManagerSetsMdl2> TimeManagerSetsMdl2s { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<ViewModelAttendanceClients2>()
        //    //    .HasKey(c => new { c.Id });

        //    //modelBuilder.Entity<ViewModelAttendanceClients2>()
        //    //    //.HasMany(c => c.ShowTimeManagerSet)
        //    //    //.WithRequired()
        //    //    //.HasForeignKey(c => c.Id);
        //    //    .HasRequired(x => x.TmeMngrSetsMdlObj)
        //    //    .WithMany(x => x.ShowTimeManagerSet)
        //    //    .HasForeignKey(x => x.Id);



        //    //modelBuilder.Entity<TimeManagerSetsMdl2>()
        //    //    .HasMany(c => c.ShowCategory)
        //    //    .WithRequired()
        //    //    .HasForeignKey(c => c.Id);

        //    modelBuilder.Entity<ViewModelAttendanceClients2>()
        //          .HasRequired(i => i.TmeMngrSetsMdlObj)
        //          .WithRequiredDependent()
        //          .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<ViewModelAttendanceClients2>()
        //          .HasRequired<TimeManagerSetsMdl2>(i => i.TmeMngrSetsMdlObj)
        //          .WithMany(e => e.ShowTimeManagerSet)
        //          .HasForeignKey(i => i.TmeMngrSetsMdlObj);
        //}

        #region  Fluent API WillCascadeOnDelete OnDelete（看note）
        //https://forums.asp.net/t/2147990.aspx
        //https://stackoverflow.com/questions/34768976/specifying-on-delete-no-action-in-entity-framework-7
        // https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths
        //https://forums.asp.net/t/2148073.aspx
        //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<book2>().HasRequired(c => c.Id.ToString())
        //.WithMany()
        //.WillCascadeOnDelete(false);
        //    }
        #endregion

        public System.Data.Entity.DbSet<TestApplication1.Models.Person> People { get; set; }
    }

    public class sql_textConnectionString : DbContext
    {

        //public SchoolContext() : base("SchoolContext")
        //{
        //}

        public System.Data.Entity.DbSet<TestApplication1.Models.SampleTable02> SampleTable02 { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    }