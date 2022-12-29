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

        private const float SPAWN_COOLDOWN = 2f;
        private float spawnCountDown;

        // Start is called before the first frame update
        void Start()
        {
            spawnCountDown = SPAWN_COOLDOWN;
        }

        // Update is called once per frame
        private void Update()
        {
            if (spawnCountDown >= 0)
            {
                spawnCountDown -= Time.deltaTime;
                if (spawnCountDown < 0)
                {
                    Spawn();
                    spawnCountDown = SPAWN_COOLDOWN;
                }

            }
        }
        private void Spawn()
        {
            float spawnX = UnityEngine.Random.Range(pointA.position.x, pointB.position.x);
            float spawnY = UnityEngine.Random.Range(pointA.position.y, pointB.position.y);

            Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0f);
            Instantiate(devilCube, spawnPoint, Quaternion.identity);
        }
    }
}

