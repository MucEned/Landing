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
        [SerializeField] RewardedAdsButton rewardedAdsButton;

        private float defaultTimeCountdown = 10;
        private float currentTimeCountdown = 10;
        private int currentTime = 10;

        private bool isWatchingAds = false;

        private void Awake()
        {
            rewardedAdsButton.LoadAd();
        }
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
            if(isWatchingAds)
            {
                return;
            }
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
            isWatchingAds = false;
        }
        public void TriggerGameOverPanel()
        {
            continueWithAdPanel.Deactive();
            gameOverMenu.Active();
        }
        public void PlayerRevive()
        {
            continueWithAdPanel.Deactive();
            StartCoroutine(OnPlayerReviveInvoke());
        }
        private IEnumerator OnPlayerReviveInvoke()
        {
            yield return new WaitUntil(() => continueWithAdPanel.transform.localScale.x <= 0.2f);
            AllEvents.OnPlayerRevive?.Invoke();
        }
        public void IsWatchingAdsBoolSet()
        {
            isWatchingAds = true;
        }
    }
}

