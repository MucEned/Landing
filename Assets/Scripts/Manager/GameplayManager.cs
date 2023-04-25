using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using Player;
using UIManager;

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
        Ending = 2,
    }

    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;

        [SerializeField] private SpawnLine spawnLine;
        private const float NORMAL_SPAWN_COOLDOWN = 2f;
        private const float TRAP_SPAWN_REDUCE_COOLDOWN_TIME = 15;
        private float TRAP_SPAWN_COOLDOWN = 6;
        private float normalSpawnCountDown;
        private float trapSpawnCountdown = 30;
        private float trapReduceCooldownTimeCountdown = 50;
        [HideInInspector] public GamePhase GamePhase = GamePhase.Normal;

        public GameObject Boss;
        [SerializeField] private UIScalingPanel gameOverMenu;
        [SerializeField] private UIScalingPanel continueWithAdPanel;

        private bool hasRevived = false;
        private PlayerController cachePlayer;

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
            cachePlayer = GameInstanceHolder.Instance.Player;
            AllEvents.OnBossingPhase += OnBossingPhase;
            AllEvents.OnPlayerDead += OnPlayerDead;
            AllEvents.OnPlayerRevive += OnPlayerRevive;
        }
        private void OnDestroy()
        {
            AllEvents.OnBossingPhase -= OnBossingPhase;
            AllEvents.OnPlayerDead -= OnPlayerDead;
            AllEvents.OnPlayerRevive -= OnPlayerRevive;
        }
        private void Update()
        {
            NormalDevilSpawn();
            TrapSpawn();
        }
        private void NormalDevilSpawn()
        {
            if (GamePhase == GamePhase.Ending) return;
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
                GamePhase = GamePhase.Normal;
            }
            else
            {
                GamePhase = GamePhase.Bossing;
                Debug.Log("Spawn boss");
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
            GamePhase = GamePhase.Ending;
            AllEvents.OnTimeScale?.Invoke(0.1f, 1f, true);
            StartCoroutine(TriggerEndGamePanel());
        }
        private IEnumerator TriggerEndGamePanel()
        {
            yield return new WaitUntil(() => cachePlayer.IsAlreadyDead);
            if (hasRevived == false)
            {
                continueWithAdPanel.Active();
                hasRevived = true;
            }
            else
            {
                gameOverMenu.Active();
            }
        }
        private void TrapSpawn()
        {
            if (GamePhase == GamePhase.Ending) return;
            if (trapSpawnCountdown >= 0)
            {
                trapSpawnCountdown -= Time.deltaTime;
                if (trapSpawnCountdown < 0)
                {
                    AllEvents.OnTrapSpawn?.Invoke();
                    ResetTrapSpawnCount();
                }
            }
        }
        private void ResetTrapSpawnCount()
        {
            trapSpawnCountdown = TRAP_SPAWN_COOLDOWN;
        }
        private void TrapReduceTimeCooldown()
        {
            if (GamePhase == GamePhase.Ending || TRAP_SPAWN_COOLDOWN <= 2) return;
            if (trapReduceCooldownTimeCountdown >= 0)
            {
                trapReduceCooldownTimeCountdown -= Time.deltaTime;
                if (trapReduceCooldownTimeCountdown < 0)
                {
                    ReduceTrapCooldownTime();
                }
            }
        }
        private void ResetTrapReduceTimeCooldownCount()
        {
            trapReduceCooldownTimeCountdown = TRAP_SPAWN_REDUCE_COOLDOWN_TIME;
        }
        private void ReduceTrapCooldownTime()
        {
            if (TRAP_SPAWN_COOLDOWN <= 2)
            {
                return;
            }
            else
            {
                TRAP_SPAWN_COOLDOWN--;
                ResetTrapReduceTimeCooldownCount();
            }
        }
        private void OnPlayerRevive()
        {
            GamePhase = GamePhase.Normal;
        }
    }
}
