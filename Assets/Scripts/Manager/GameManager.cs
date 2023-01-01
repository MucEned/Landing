using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using GameEvents;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public PlayerController Player;
        private int score = 0;

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
            Debug.Log(score);
        }

    }
}
