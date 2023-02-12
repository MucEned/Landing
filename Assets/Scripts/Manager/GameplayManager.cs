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

        public GameObject Boss;
        [SerializeField] private GameObject gameOverMenu;

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
        private void OnBossingPhase(bool bossing)
        {
            if (!bossing)
            {
                gamePhase = GamePhase.Normal;
            }
            else
            {
                gamePhase = GamePhase.Bossing;
                SpawnBoss();
                ResetNormalSpawnCount();
            }
        }
        private void SpawnBoss()
        {
            Instantiate(Boss, Vector3.zero, Quaternion.identity);
        }
        private void OnPlayerDead()
        {
            //gameOverMenu.SetActive(true);
            AllEvents.OnTimeScale?.Invoke(0.1f, 1f);
<<<<<<< HEAD
            StartCoroutine(TriggerEndGameScene());

        }
        private IEnumerator TriggerEndGameScene()
        {
            yield return new WaitUntil(()=>cachePlayer.IsAlreadyDead);
            gameOverMenu.SetActive(true);
=======
>>>>>>> parent of a20b6dc (Merge branch Trap and master (#13))
        }
        private IEnumerator TriggerEndGameScene()
        {
            yield return new WaitUntil(()=>cachePlayer.IsAlreadyDead);
            gameOverMenu.SetActive(true);
        }
    }
}
