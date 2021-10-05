﻿using System.Collections.Generic;
using UnityEngine;

public class CollectableController : BaseController
{
    private Particles _particle;
    private CollectableItem _temp;
    private ObjectPool<CollectableItem> _pool  = new ObjectPool<CollectableItem>();
    private List<CollectableItem> _activeColl = new List<CollectableItem>();
    private ParticleSystem.Particle[] _coll;
    private int _num = 0;
    private int _index;

    public override void Initialize()
    {
        _coll = new ParticleSystem.Particle[_particle.System.main.maxParticles];
        PoolInit();
    }

    public override void Execute()
    {
        FindKilledParticle();
        for (int i = 0; i < _activeColl.Count; i++)
        {
            if (CheckActive(i))
            {
                MoveCollectable(_activeColl[i]);
            }
        }
    }

    private void PoolInit()
    {
        for (_index = 0; _index < _particle.System.main.maxParticles * 0.5f; _index++)
        {
            _pool.PutObjects(GetRandomPrefab(), 2);
        }
    }

    private CollectableItem GetRandomPrefab()
    {
        return _particle.Prefabs[Random.Range(0, _particle.Prefabs.Count)];
    }

    private void FindKilledParticle()
    {
        for (_index = 0; _index < _num; _index++)
        {
            if (_coll[_index].remainingLifetime == 0f)
            {;
                _temp = _pool.GetObject();
                _temp.transform.position = _coll[_index].position + Vector3.up;
                _temp.Target = _particle.Target;
                _activeColl.Add(_temp);
            }
        }
        _num = _particle.System.GetParticles(_coll);
    }

    private void MoveCollectable(CollectableItem c)
    {
        //c.transform.position = Vector3.MoveTowards(c.transform.position, c.Target.position, Time.deltaTime);
    }

    private bool CheckActive(int num)
    {
        if (_activeColl[num].enabled == false)
        {
            _activeColl.RemoveAt(num);
            return false;
        }
        return true;
    }

    public void SetParticles(Particles ps)
    {
        _particle = ps;
    }
}
