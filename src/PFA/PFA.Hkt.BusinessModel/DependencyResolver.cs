using System.ComponentModel.Composition;
using DataModel;
using Resolver;

namespace BusinessModel
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IEmployeeService, EmployeeService>();

        }
    }
}
