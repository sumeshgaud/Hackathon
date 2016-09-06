using System;
using System.Configuration;
using System.Reflection;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using DataModel;

namespace DataModel
{
    public class EntityDataContext : DbContext
    {

        public EntityDataContext()
            : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder); 
        }

      

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuthInfo> AuthInfos { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetDetail> BudgetDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<RecurTransaction> RecurTransactions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
       







    }
}
