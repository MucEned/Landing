using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameEvents
{
    public class AllEvents
    {
        public static Action OnPlayerLanding;
        public static Action OnDevilDead;
        public static Action<int> OnPlayerActionPointSet;
        public static Action OnScoreUpdate; //call it whenever player's score change
        public static Action OnGamePause; //call it to pause or resume the game
    }
}
