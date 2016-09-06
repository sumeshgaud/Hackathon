using System.ComponentModel.Composition;
using Resolver;

namespace DataModel
{
    [Export(typeof(IComponent))]
   public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}
