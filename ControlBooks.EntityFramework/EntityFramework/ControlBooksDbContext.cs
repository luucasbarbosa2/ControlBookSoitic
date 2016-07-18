using System.Data.Common;
using Abp.Zero.EntityFramework;
using ControlBooks.Authorization.Roles;
using ControlBooks.MultiTenancy;
using ControlBooks.Users;
using ControlBooks.Authors;
using System.Data.Entity;
using ControlBooks.Books;
using ControlBooks.Publishers;

namespace ControlBooks.EntityFramework
{
    public class ControlBooksDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<Autor> Autor { get; set; }
        public virtual IDbSet<Publisher> Publisher { get; set; }
        public virtual IDbSet<Book> Book { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ControlBooksDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ControlBooksDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ControlBooksDbContext since ABP automatically handles it.
         */
        public ControlBooksDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ControlBooksDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
