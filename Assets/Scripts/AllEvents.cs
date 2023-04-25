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
        public static Action OnPlayerStartLanding;
        public static Action OnPlayerLanding;
        public static Action OnPlayerTouchTheGround;
        public static Action OnLandOnBoss;
        public static Action OnPlayerRevive;

        [Header("Manager")]
        public static Action OnDevilDead;
        public static Action OnTouchDevil;
        public static Action<int> OnPlayerActionPointSet;
        public static Action OnGamePause; //call it to pause or resume the game
        public static Action<int> OnStreak;
        public static Action OnResetStreak;
        public static Action<int> OnWorldDeviated;
        public static Action<float, float, bool> OnTimeScale;
        public static Action OnTrapSpawn;

        [Header("Phases")]
        public static Action<bool> OnBossingPhase;

        [Header("EndConditions")]
        public static Action OnPlayerDead;
        public static Action OnPlayerAlreadyDead;
        public static Action OnDevilReachBarrier;
        public static Action OnPlayerDeadByCeiling;
        
        [Header("UI")]
        public static Action OnScoreUpdate; //call whenever player get score 
        public static Action OnTimerUpdate; //used to update the timer text UI
        public static Action OnMusicSettingChange;
        public static Action OnSFXSettingChange;
    }
}
