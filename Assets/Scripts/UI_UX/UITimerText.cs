using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;
using DG.Tweening;

namespace Managers
{
    public class UITimerText : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        private int currentTime = 3;

        [SerializeField] private Vector3 punchScaleAmount = new Vector3(0.1f, 0.1f, 0f);
        [SerializeField] private Vector3 shakeRotateAmount = new Vector3(0f, 0f, 15f);

        private void Awake()
        {
            AllEvents.OnTimerUpdate += UpdateTimer;
        }
        private void OnDisable()
        {
            AllEvents.OnTimerUpdate -= UpdateTimer;
        }
        private void DisplayTime()
        {
            timerText.text = currentTime.ToString();
            PlayAnim();
        }
        private void UpdateTimer()
        {
            if(currentTime > 0)
            {
                currentTime--;
            }
            DisplayTime();
        }
        private void PlayAnim()
        {
            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.identity;

            transform.DOPunchScale(punchScaleAmount, 0.1f);
            transform.DOShakeRotation(0.1f, shakeRotateAmount);
        }
    }
}