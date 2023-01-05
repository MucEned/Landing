using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public enum GameMode
    {
        Undefine = 0,
        Playing = 1,
        Pausing = 2,
    }

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;

        [SerializeField] private SpawnLine spawnLine;
        private const float NORMAL_SPAWN_COOLDOWN = 2f;
        private float normalSpawnCountDown;


        private void Awake() 
        {
            if (Instance != null) 
            {
                Debug.LogError("We are have 2 GameplayerManager!!!");
                return;
            }
            Instance = this;
        }

        private void Start() 
        {
            Init();
        }
        private void Init()
        {
            normalSpawnCountDown = NORMAL_SPAWN_COOLDOWN;
        }
        private void Update()
        {
            NormalDevilSpawn();
        }
        private void NormalDevilSpawn()
        {
            if (normalSpawnCountDown >= 0)
            {
                normalSpawnCountDown -= Time.deltaTime;
                if (normalSpawnCountDown < 0)
                {
                    spawnLine.Spawn();
                    normalSpawnCountDown = NORMAL_SPAWN_COOLDOWN;
                }

            }
        }
    }
}
