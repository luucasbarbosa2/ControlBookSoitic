using ControlBooks.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ControlBooks.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ControlBooksDbContext _context;

        public InitialHostDbBuilder(ControlBooksDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
