using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace ButtonEvent
{
    public class ButtonOnClick : MonoBehaviour
    {
        public void PauseButton() //this button is used to pause and resume the game
        {
            AllEvents.OnGamePause?.Invoke();
        }
    }
}
