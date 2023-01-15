using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class TimeController : MonoBehaviour
    {
        private float timeScaleCountdown = 0;
        private float lastTimeScale = 1;
        private bool isScaleEffect = false;

        private void Start() 
        {
            AllEvents.OnTimeScale += OnTimeScale;
            AllEvents.OnGamePause += OnGamePause;
        }
        private void Update()
        {
            if (timeScaleCountdown >= 0 && (isScaleEffect == true))
            {
                timeScaleCountdown -= Time.unscaledDeltaTime;
                if (timeScaleCountdown <= 0)
                    {
                        Time.timeScale = 1;
                        isScaleEffect = false;
                    }
                    
            }
        }
        private void OnDestroy()
        {
            AllEvents.OnTimeScale -= OnTimeScale;
            AllEvents.OnGamePause -= OnGamePause;
        }
        private void OnTimeScale(float timeScale, float duration)
        {
            Time.timeScale = timeScale;
            lastTimeScale = timeScale;
            timeScaleCountdown = duration;
            isScaleEffect = true;
        }
        private void OnGamePause()
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}
