using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Entity : MonoBehaviour
    {
        public GameObject entity;
        
        private LayerMask _deathMask;

        public Entity() {}

        public Entity(GameObject gameObj)
        {
            entity = gameObj;
        }
        
        private void Start()
        {
            _deathMask = LayerMask.GetMask("Death");
        }

        private void FixedUpdate()
        {
            //If Entity reaches void, Destroy it
            if (Physics.Raycast(transform.position, -Vector3.up, 1f, _deathMask))
            {
                Debug.Log(name + " Death layer hit from 1f");
                Destroy(this);
            }
        }

        private void Awake()
        {
            if (!entity)
            {
                Debug.LogWarning("No GameObject for entity");
            }
        }
    }
}