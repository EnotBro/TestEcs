using LeoEcsPhysics;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using UnityEngine;
using Voody.UniLeo;

namespace Client
{
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        void Start()
        {

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            EcsPhysicsEvents.ecsWorld = _world;

            _systems.ConvertScene();
            InitializeObserver();

            _systems
              .Add(new Create1System())
              .Add(new Create2System())
              .Add(new SetTimerBlockFor1System())
              .Add(new SetTimerBlockFor2System())
              .Add(new UpdateTimeBlockSystem())
              .Init();
        }

        private void InitializeObserver()
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                EcsPhysicsEvents.ecsWorld = null;
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}
