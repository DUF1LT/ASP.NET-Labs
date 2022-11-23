using DbDataProvider;
using Models.Models;
using Models.Repository;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Lab3.Ninject
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Record>>().To<RecordDbRepository>();

            // Bind<IRepository<Record>>().To<RecordDbRepository>().InThreadScope();
            //
            // Bind<IRepository<Record>>().To<RecordDbRepository>().InRequestScope();
        }

    }
}