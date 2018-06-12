using ConstructionFinancial.Domain.Account;
using ConstructionFinancial.Domain.Employees;
using ConstructionFinancial.Domain.GeneralLedger;
using ConstructionFinancial.Domain.Project;
using ConstructionFinancial.Domain.TaskModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionFinancial.DataEntity.Context
{
    public class CFDBContext : DbContext
    {
        public CFDBContext()
            : base("CFDBContext")
        {
            Database.SetInitializer<CFDBContext>(new MigrateDatabaseToLatestVersion<CFDBContext, ConstructionFinancial.DataEntity.Migrations.Configuration>());

            //Database.SetInitializer<CFDBContext>(new DropCreateDatabaseAlways<CFDBContext>());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<GeneralJournal> GeneralJournals { get; set; }
        public DbSet<GeneralLedger> GeneralLedgers { get; set; }
        public DbSet<TrialBalance> TrialBalances { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Equity> Equitys { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Liabilities> Liabilities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ConstructionFinancial.Domain.TaskModel.TaskStatus> TaskStatus { get; set; }

    }
}
