using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using Managers;
using UnityEngine.SceneManagement;

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
            Time.timeScale = 1;
            LoadManager.Instance.LoadScene("MenuScene");
        }
        public void ReloadCurrentScene() //use when player want to retry the game
        {
            LoadManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
