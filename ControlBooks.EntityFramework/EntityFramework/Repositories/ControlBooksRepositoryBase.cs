using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ControlBooks.EntityFramework.Repositories
{
    public abstract class ControlBooksRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ControlBooksDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ControlBooksRepositoryBase(IDbContextProvider<ControlBooksDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ControlBooksRepositoryBase<TEntity> : ControlBooksRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ControlBooksRepositoryBase(IDbContextProvider<ControlBooksDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
