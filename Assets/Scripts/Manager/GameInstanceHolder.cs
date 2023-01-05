using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameEvents;

namespace Managers
{
    public class GameInstanceHolder : MonoBehaviour
    {
        public static GameInstanceHolder Instance;
        public PlayerController Player;
        public int score = 0;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            if(score != 0)
            {
                score = 0;
            }
            Player = FindObjectOfType<PlayerController>();
            AllEvents.OnDevilDead += AddScore;
        }

        private void OnDisable()
        {
            AllEvents.OnDevilDead -= AddScore;
        }
        
        private void AddScore()
        {
            score++;
            AllEvents.OnScoreUpdate?.Invoke();
        }
    }
}
