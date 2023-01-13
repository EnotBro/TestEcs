using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create1System : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    public void Init()
    {
        for (int index = 0, indexMax = 5; index < indexMax; index++)
        {
            EcsEntity entity = ecsWorld.NewEntity();

            entity.Get<A>();
            entity.Get<B>();
        }
    }
}