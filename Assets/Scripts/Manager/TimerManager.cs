using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TimerManager : MonoBehaviour
    {
        //private float defaultTime = 3;
        private float currentTime = 3;
        [SerializeField] Text timerText;
        [SerializeField] GameObject[] deactiveGOs;
        
        private void Update()
        {
            if(Time.timeSinceLevelLoad >= 2)
            {
                if(timerText.gameObject.activeSelf != true)
                {
                    timerText.gameObject.SetActive(true);
                }
                TimerCountdown();
            }
        }
        private void TimerCountdown()
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                currentTime = 0;
                SetActiveGOs();
                DestroyTimer();
            }
            timerText.text = currentTime.ToString("0");
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
