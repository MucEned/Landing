using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEvents
{
    public class AllEvents
    {
        [Header("Player")]
        public static Action OnPlayerJump;
        public static Action OnPlayerLanding;
        public static Action OnPlayerTouchTheGround;
        public static Action OnPlayerDead;
        public static Action OnLandOnBoss;

        [Header("Manager")]
        public static Action<bool> OnBossingPhase;
        public static Action OnDevilDead;
        public static Action<int> OnPlayerActionPointSet;
        public static Action OnGamePause; //call it to pause or resume the game
        public static Action<int> OnStreak;
        public static Action OnResetStreak;
        public static Action<int> OnWorldDeviated;
        public static Action<float, float> OnTimeScale;
        public static Action OnTrapSpawn;
        
        [Header("UI")]
        public static Action OnScoreUpdate; //call whenever player get score 
        public static Action OnTimerUpdate; //used to update the timer text UI
        public static Action OnMusicSettingChange;
        public static Action OnSFXSettingChange;

    }
}
