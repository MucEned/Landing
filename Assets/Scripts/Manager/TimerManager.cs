using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;

namespace Managers
{
    public class TimerManager : MonoBehaviour
    {
        //private float defaultTime = 3;
        private float currentTime = 3;
        private float timeCountdown = 3;
        [SerializeField] Text timerText;
        [SerializeField] GameObject[] deactiveGOs;
        
        private void Update()
        {
            if(Time.timeSinceLevelLoad >= 4)
            {
                if(timerText.gameObject.activeSelf != true)
                {
                    timerText.gameObject.SetActive(true);
                    AllEvents.OnTimerUpdate?.Invoke();
                }
                TimerCountdown();
            }
        }
        private void TimerCountdown()
        {
            currentTime -= Time.deltaTime;
            if(timeCountdown - currentTime >= 1)
            {
                timeCountdown--;
                AllEvents.OnTimerUpdate?.Invoke();
            }
            if(timeCountdown <= 0)
            {
                AllEvents.OnTimerUpdate?.Invoke();
                SetActiveGOs();
                DestroyTimer();
            }
        }
        private void SetActiveGOs()
        {
            foreach (GameObject item in deactiveGOs)
            {
                item.SetActive(true);
            }
        }
        private void DestroyTimer()
        {
            Destroy(timerText);
            Destroy(this.gameObject);
        }
    }
}
