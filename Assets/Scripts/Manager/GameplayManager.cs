using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
namespace Managers
{
    public enum GameMode
    {
        Undefine = 0,
        Playing = 1,
        Pausing = 2,
    }
    public enum GamePhase
    {
        Normal = 0,
        Bossing = 1,
    }

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;

        [SerializeField] private SpawnLine spawnLine;
        private const float NORMAL_SPAWN_COOLDOWN = 2f;
        private float normalSpawnCountDown;
        private GamePhase gamePhase = GamePhase.Normal;

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
            AllEvents.OnBossingPhase += OnBossingPhase;
            AllEvents.OnPlayerDead += OnPlayerDead;
        }
        private void OnDestroy() 
        {
            AllEvents.OnBossingPhase -= OnBossingPhase;
            AllEvents.OnPlayerDead -= OnPlayerDead;
        }
        private void Update()
        {
            NormalDevilSpawn();
        }
        private void NormalDevilSpawn()
        {
            if (gamePhase != GamePhase.Normal) return;
            if (normalSpawnCountDown >= 0)
            {
                normalSpawnCountDown -= Time.deltaTime;
                if (normalSpawnCountDown < 0)
                {
                    spawnLine.Spawn();
                    ResetNormalSpawnCount();
                }
            }
        }
        private void ResetNormalSpawnCount()
        {
            normalSpawnCountDown = NORMAL_SPAWN_COOLDOWN;
        }
        private void OnBossingPhase()
        {
            gamePhase = GamePhase.Bossing;
            SpawnBoss();
            ResetNormalSpawnCount();
        }
        private void SpawnBoss()
        {

        }
        private void OnPlayerDead()
        {
            AllEvents.OnTimeScale?.Invoke(0.1f, 1f);
        }
    }
}
