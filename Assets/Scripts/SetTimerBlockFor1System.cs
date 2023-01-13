using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimerBlockFor1System : IEcsRunSystem
{
    private EcsFilter<A, B>.Exclude<E> _filter = null;
    public void Run()
    {
        for (int index = 0, indexMax = _filter.GetEntitiesCount(); index < indexMax; index++)
        {
            ref var entity = ref _filter.GetEntity(index);

            Debug.Log($"Has A {entity.Has<A>()}, Has B {entity.Has<B>()}, Has C {entity.Has<C>()}, Has D {entity.Has<D>()}, Has E {entity.Has<E>()}");

            ref var e = ref entity.Get<E>();
            e.timeForBlock = 5;
         
        }
    }
}