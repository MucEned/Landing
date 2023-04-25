using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;

namespace UIManager
{
    public class UIContinueWithAd : MonoBehaviour
    {
        [SerializeField] private UIScalingPanel gameOverMenu;
        [SerializeField] private UIScalingPanel continueWithAdPanel;
        [SerializeField] private Text timerText;

        private float defaultTimeCountdown = 10;
        private float currentTimeCountdown = 10;
        private int currentTime = 10;

        private void OnEnable()
        {
            ResetTimer();
        }
        private void Update()
        {
            TimerCountdown();
        }
        private void TimerCountdown()
        {
            currentTimeCountdown -= Time.deltaTime;
            if (currentTime - currentTimeCountdown >= 1)
            {
                if (currentTime == 0)
                {
                    return;
                }
                currentTime--;
                DisplayTimerText();
            }
            if (currentTimeCountdown < 0)
            {
                TriggerGameOverPanel();
            }
        }
        private void DisplayTimerText()
        {
            timerText.text = currentTime.ToString();
        }
        private void ResetTimer()
        {
            currentTimeCountdown = defaultTimeCountdown;
            currentTime = (int)defaultTimeCountdown;
            DisplayTimerText();
        }
        public void TriggerGameOverPanel()
        {
            continueWithAdPanel.Deactive();
            gameOverMenu.Active();
        }
        public void PlayerRevive()
        {
            AllEvents.OnPlayerRevive?.Invoke();
            continueWithAdPanel.Deactive();
        }
    }
}