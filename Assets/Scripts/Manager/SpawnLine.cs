using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{ 
    public class SpawnLine : MonoBehaviour
    {
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private GameObject devilCube;
        public void Spawn()
        {
            float spawnX = UnityEngine.Random.Range(pointA.position.x, pointB.position.x);
            float spawnY = UnityEngine.Random.Range(pointA.position.y, pointB.position.y);

            Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0f);
            Instantiate(devilCube, spawnPoint, Quaternion.identity);
        }
    }
}

