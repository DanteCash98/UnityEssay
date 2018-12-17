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

        public Entity() {}

        public Entity(GameObject gameObj)
        {
            entity = gameObj;
        }
        
        private void Start()
        {
            if (entity)
            {
                //Instantiate(entity);
            }
        }

        private void Awake()
        {
            if (!entity)
                Debug.LogWarning("No GameObject for entity");
        }
    }
}