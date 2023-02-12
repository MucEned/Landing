using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traps;
using GameEvents;

namespace Managers
{
    public class TrapController : MonoBehaviour
    {
        public static TrapController Instance;
        private List<TrapHolder> unspawnedTrap = new List<TrapHolder>(); //traps are ready to be spawned
        private List<TrapHolder> hasSpawnedTrap = new List<TrapHolder>(); //traps were spawned

        private int listLength;

        private void Awake()
        {
            if(Instance != null)
            {
                Debug.LogWarning("More than 1 TrapController in the scene");
                return;
            }
            Instance = this;
            AddTrapInSceneToList();
            AllEvents.OnTrapSpawn += SpawnTrap;
        }
        private void OnDisable()
        {
            AllEvents.OnTrapSpawn -= SpawnTrap;
        }
        private void AddTrapInSceneToList()
        {
            TrapHolder[] tempTrapHolder = FindObjectsOfType<TrapHolder>();
            foreach (TrapHolder trap in tempTrapHolder)
            {
                unspawnedTrap.Add(trap);
            }
            listLength = unspawnedTrap.Count - 1;
        }
        private int RandomTrapToSpawn()
        {
            listLength = unspawnedTrap.Count - 1;
            int ranNumber = Random.Range(0, listLength);
            return ranNumber;
        }
        private void SpawnTrap()
        {
            bool isSpawning = true;
            while (isSpawning)
            {
                if (unspawnedTrap.TrueForAll(x => x.isActive == true) == true)
                {
                    Debug.Log("no more trap to spawn");
                    isSpawning = false;
                    break;
                }
                int trapIndex = RandomTrapToSpawn();
                if (unspawnedTrap[trapIndex].isActive == false)
                {
                    unspawnedTrap[trapIndex].ActiveSignal();
                    AddToSpawnedTrap(unspawnedTrap[trapIndex]);
                    isSpawning = false;
                }
            }
        }
        private void AddToSpawnedTrap(TrapHolder _trap)
        {
            hasSpawnedTrap.Add(_trap);
            unspawnedTrap.Remove(_trap);
        }
        public void BackToUnspawnedList(TrapHolder _trap)
        {
            unspawnedTrap.Add(_trap);
            hasSpawnedTrap.Remove(_trap);
        }
    }
}