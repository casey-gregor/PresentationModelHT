﻿using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSHomework
{
    public sealed class ApplyWeaponSound : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<IsAttacking>> _filter = EcsWorlds.EVENTS_WORLD;

        private readonly EcsPoolInject<AudioSourceComponent> _audioPool;
        private readonly EcsPoolInject<WeaponSFX> _weaponSFXPool;
        
        public void Run(EcsSystems systems)
        {
            EcsPool<IsAttacking> isAttackingPool = _filter.Pools.Inc1;

            foreach (var entity in _filter.Value)
            {
                int attackingEntity = isAttackingPool.Get(entity).Entity;
                
                AudioClip audio = _weaponSFXPool.Value.Get(attackingEntity).Value;
                _audioPool.Value.Get(attackingEntity).Value.PlayOneShot(audio);
            }
        }
    }
}