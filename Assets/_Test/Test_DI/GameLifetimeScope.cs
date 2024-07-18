using VContainer;
using VContainer.Unity;

namespace Test_CSV
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UserData>(Lifetime.Singleton);
            builder.RegisterComponentOnNewGameObject<GameManager>(Lifetime.Singleton, "GameManager").DontDestroyOnLoad();
            // builder.RegisterComponentInHierarchy<ViewController>();
        }
    }
}
