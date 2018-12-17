using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entity;
    public int spawnLimit;
    private List<GameObject> _entities = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnEntity", 10f, 15f);
    }

    public void SpawnEntity()
    {
        if (_entities.Count < spawnLimit)
        {
            Instantiate(entity);
            _entities.Add(entity);
        }
        else
        {
            Debug.Log("Spawn limit reached for " + entity.name);
        }
    }
}
