using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;
using DG.Tweening;

namespace UIManager
{
    public class UITimerText : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        private int currentTime = 3;


        [SerializeField] private float shakeScaleDuration = 0.25f;
        [SerializeField] private float shakeScaleStrength = 1;

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


            transform.DOShakeScale(shakeScaleDuration, shakeScaleStrength);

        }
    }
}