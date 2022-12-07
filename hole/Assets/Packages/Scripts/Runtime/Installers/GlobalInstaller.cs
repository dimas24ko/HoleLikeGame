using Hole.Runtime.Features.Game;
using Hole.Runtime.Features.Score;
using Hole.Runtime.Services.TimeFormatter;
using Hole.Runtime.Services.Timer;
using Zenject;

namespace Hole.Runtime.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public GameData GameData;
        
        public override void InstallBindings()
        {
            Container.Bind<GameData>().FromScriptableObject(GameData).AsSingle();

            Container.BindInterfacesAndSelfTo<LifeTimer>().AsSingle();
            Container.Bind<ScoreContainer>().AsSingle();
            Container.Bind<TimeFormatter>().AsSingle();
        }
    }
}