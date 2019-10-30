using JPProject.Domain.Core.Interfaces;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Context;
using JPProject.EntityFrameworkCore.Context;

namespace JPProject.Admin.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JPProjectAdminUIContext _adminUiContext;

        public UnitOfWork(JPProjectAdminUIContext adminUiContext)
        {
            _adminUiContext = adminUiContext;
        }

        public bool Commit()
        {
            return _adminUiContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _adminUiContext.Dispose();
        }
    }
}
