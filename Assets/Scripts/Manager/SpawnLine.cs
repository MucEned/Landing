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
        [SerializeField] private string enemyName = "DevilCubes";

        public void Spawn()
        {
            float spawnX = UnityEngine.Random.Range(pointA.position.x, pointB.position.x);
            float spawnY = UnityEngine.Random.Range(pointA.position.y, pointB.position.y);

            Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0f);
            GameObject enemyToSpawn = FindDevilCubeToSpawn();
            if (enemyToSpawn == null)
            {
                Instantiate(devilCube, spawnPoint, Quaternion.identity, GameObject.Find(enemyName).gameObject.transform);
            }
            else
            { 
                SetSpawnLocation(enemyToSpawn, spawnPoint); 
            }
        }

        private GameObject FindDevilCubeToSpawn()
        {
            GameObject enemies = GameObject.Find(enemyName);
            for (int i = 0; i < enemies.transform.childCount - 1; i++)
            {
                if (enemies.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    GameObject currentEnemy = enemies.transform.GetChild(i).gameObject;
                    return currentEnemy;
                }
            }
            return null;
        }
        private void SetSpawnLocation(GameObject enemy, Vector3 position)
        {
            enemy.transform.position = position;
            enemy.gameObject.SetActive(true);
        }
    }
}

