using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimerBlockFor2System : IEcsRunSystem
{
    private EcsFilter<C, D>.Exclude<E> _filter = null;
    public void Run()
    {
        for (int index = 0, indexMax = _filter.GetEntitiesCount(); index < indexMax; index++)
        {
            ref var entity = ref _filter.GetEntity(index);

            ref var e = ref entity.Get<E>();
            e.timeForBlock = 10;
        }
    }
}