using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using Managers;

namespace ButtonEvent
{
    public class ButtonOnClick : MonoBehaviour
    {
        public void PauseButton() //this button is used to pause and resume the game
        {
            AllEvents.OnGamePause?.Invoke();
        }
        public void LoadMainSceneButton()
        {
            LoadManager.Instance.LoadScene("MainScene");
        }
        public void LoadMenuSceneButton()
        {
            LoadManager.Instance.LoadScene("MenuScene");
        }
    }
}
