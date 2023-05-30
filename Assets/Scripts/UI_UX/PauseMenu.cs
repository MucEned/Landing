using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace UIManager
{
    public enum GamePhase
    {
        Normal = 0,
        Ending = 1,
    }
    public class PauseMenu : MonoBehaviour
    {
        private GamePhase gamePhase = GamePhase.Normal;

        [SerializeField] private UIScalingPanel menuPanel;
        [SerializeField] private UIScalingPanel blurPanel;
        bool isMenuActive = false;
        bool isScaling = false;

        private float scaleDuration;

        private void Awake()
        {
            AllEvents.OnGamePause += MenuController;
            AllEvents.OnGameEnd += OnGameEnd;
            AllEvents.OnPlayerRevive += OnPlayerRevive;
            scaleDuration = menuPanel.ScaleDuration + 0.1f;
        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && (isScaling != true) && (gamePhase != GamePhase.Ending))
            {
                AllEvents.OnGamePause?.Invoke();
            }
        }
        public void PauseButton()
        {
            if((isScaling != true) && (gamePhase != GamePhase.Ending))
            {
                AllEvents.OnGamePause?.Invoke();
                StartCoroutine(ResetScalingBool());
            }
        }
        private void OnDisable()
        {
            AllEvents.OnGamePause -= MenuController;
            AllEvents.OnGameEnd -= OnGameEnd;
            AllEvents.OnPlayerRevive -= OnPlayerRevive;
        }
        private void MenuController()
        {
            if (isMenuActive)
            {
                menuPanel.Deactive();
                blurPanel.Deactive();
                isScaling = true; 
            }
            else
            {
                menuPanel.Active();
                blurPanel.Active();
                isScaling = true;
            }
            StartCoroutine(ResetScalingBool());
            isMenuActive = !isMenuActive;
        }
        private IEnumerator ResetScalingBool()
        {
            yield return new WaitForSecondsRealtime(scaleDuration);
            isScaling = false;
        }
        private void OnGameEnd()
        {
            gamePhase = GamePhase.Ending;
        }
        private void OnPlayerRevive()
        {
            gamePhase = GamePhase.Normal;
        }
    }
}