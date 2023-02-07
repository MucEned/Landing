using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private const int BOSS_SCORE = 10;
        private int score;
        private int streak;
        private int bossCount;
        
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
            AllEvents.OnStreak?.Invoke(streak);
            AllEvents.OnScoreUpdate?.Invoke();
            if ((score/BOSS_SCORE) > bossCount && score > 0)
            {
                Debug.Log("Trigger event");
                AllEvents.OnBossingPhase?.Invoke(true);
                bossCount++;
            }
        }
        private void OnPlayerTouchTheGround()
        {
            ResetKillStreak();
        }
        private void ResetKillStreak()
        {
            streak = 0;
            AllEvents.OnResetStreak?.Invoke();
        }
        public int GetScore()
        {
            return score;
        }   
    }
}
