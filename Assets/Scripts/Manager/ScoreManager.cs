using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int score;
        private int streak;
        private void Start()
        {
            AllEvents.OnPlayerTouchTheGround += OnPlayerTouchTheGround;

            if(score != 0)
            {
                score = 0;
            }
            AllEvents.OnDevilDead += AddScore;
        }
        private void OnDestroy()
        {
            AllEvents.OnPlayerTouchTheGround -= OnPlayerTouchTheGround;
            AllEvents.OnDevilDead -= AddScore;
        }
        private void AddScore()
        {
            score += (streak + 1);
            streak++;
            AllEvents.OnScoreUpdate?.Invoke();
        }
        private void OnPlayerTouchTheGround()
        {
            ResetKillStreak();
        }
        private void ResetKillStreak()
        {
            streak = 0;
        }
        public int GetScore()
        {
            return score;
        }   
    }
}
