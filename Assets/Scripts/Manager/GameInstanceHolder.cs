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
        private ScoreManager scoreManager;
        public PlayerController Player;
        private void OnEnable()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            Player = FindObjectOfType<PlayerController>();
            scoreManager = FindObjectOfType<ScoreManager>();
        }
        
        public int GetScore()
        {
            return scoreManager.GetScore();
        }
    }
}
