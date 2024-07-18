using VContainer;
using VContainer.Unity;

namespace Test_CSV
{
    public class SceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<ViewController>();

        }
    }
}
