using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        







    }
}