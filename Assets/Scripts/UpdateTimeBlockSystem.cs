using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTimeBlockSystem : IEcsRunSystem
{
    private EcsFilter<E> _filter = null;
    public void Run()
    {
        for (int index = 0, indexMax = _filter.GetEntitiesCount(); index < indexMax; index++)
        {
            ref var entity = ref _filter.GetEntity(index);
            ref var e = ref _filter.Get1(index);

            e.timeForBlock -= Time.deltaTime;

            if (e.timeForBlock <= 0)
            {
                entity.Del<E>();
            }
        }
    }
}