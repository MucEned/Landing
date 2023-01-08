using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEvents
{
    public class AllEvents
    {
        public static Action OnPlayerLanding;
        public static Action OnPlayerTouchTheGround;
        public static Action OnBossingPhase;
        public static Action OnDevilDead;
        public static Action<int> OnPlayerActionPointSet;
        public static Action OnGamePause; //call it to pause or resume the game

        public static Action OnScoreUpdate;
        public static Action<int> OnStreak;
        public static Action OnResetStreak;
        public static Action<int> OnWorldDeviated;
        public static Action OnPlayerDead;
        public static Action<float, float> OnTimeScale;

    }
}
