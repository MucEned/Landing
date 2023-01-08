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
        private bool isPause = false;

        private void Start() 
        {
            AllEvents.OnTimeScale += OnTimeScale;
            AllEvents.OnGamePause += OnGamePause;
        }
        private void Update()
        {
            if (timeScaleCountdown >= 0 && (isPause == false))
            {
                timeScaleCountdown -= Time.unscaledDeltaTime;
                if (timeScaleCountdown <= 0)
                    Time.timeScale = 1;
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
        }
        private void OnGamePause()
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                isPause = false;
            }
            else
            {
                Time.timeScale = 0;
                isPause = true;
            }
        }
    }
}
