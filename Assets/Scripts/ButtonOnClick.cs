using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.SceneManagement;

namespace GameEvents
{
    public class ButtonOnClick : MonoBehaviour //some special or complicating button events will be written here
    {
        public void PauseButton() //this button is used to pause and resume the game (using for pause button in main scene)
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
        public void MusicButton()
        {
            AllEvents.OnMusicSettingChange?.Invoke();

        }
    }
}
