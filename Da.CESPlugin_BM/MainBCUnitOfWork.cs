using Da.CESPlugin_BM;
using Da.CESPlugin_BM.Mapping;
using Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace Da.Plugin_BM
{
    public  class MainBCUnitOfWork:QueryableUnitOfWork,IMainBCUnitOfWork
    {
      public MainBCUnitOfWork():base(ConnectionStringConfig.getConnStr()){ }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
          modelBuilder.Configurations.Add(new P_BM_DocImageDetailEntityConfiguration());
          modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//EF默认表名加S,该句为去掉S
          modelBuilder.Types().Where(p => p.GetProperty("ID") != null).Configure(p => p.Property("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
          Database.SetInitializer<MainBCUnitOfWork>(null);
          base.OnModelCreating(modelBuilder);
      }

      public DbSet<P_BM_DocImageDetail> p_bm_docimagedetail { get; set; }  
    }
}
