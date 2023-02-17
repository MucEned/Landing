using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Traps
{
    public class AlertSign : MonoBehaviour
    {
        [SerializeField] private float shakeScaleDuration = 0.25f;
        [SerializeField] private float shakeScaleStrength = 0.25f;
        [SerializeField] private const float TRIGGER_TIME = 3;
        private const float ANIM_TIME = 0.3f;
        private float triggerTimeCountdown;
        private float animCountdown;

        [SerializeField] GameObject objectToTrigger;

        private bool isScaleUp = false;

        private Vector3 trapToggleAnimVec = new Vector3(0.1f, 0.1f, 0.1f);

        private void OnEnable()
        {
            triggerTimeCountdown = TRIGGER_TIME;
        }
        private void Update()
        {
            CheckToActiveObject();
            CheckToPlayAnim();
        }
        private void CheckToActiveObject()
        {
            if (triggerTimeCountdown >= 0)
            {
                triggerTimeCountdown -= Time.deltaTime;
                if (triggerTimeCountdown < 0)
                {
                    ToggleObject(true);
                }
            }
        }
        private void CheckToPlayAnim()
        {
            if (animCountdown >= 0)
            {
                animCountdown -= Time.deltaTime;
                if (animCountdown < 0)
                {
                    PlayAnim();
                }
            }
        }

        private void PlayAnim()
        {
            transform.DOShakeScale(shakeScaleDuration, shakeScaleStrength);
            animCountdown = ANIM_TIME;
        }

        private void ToggleObject(bool isActive)
        {
            objectToTrigger.SetActive(isActive);
            objectToTrigger.transform.DOPunchScale(trapToggleAnimVec, 0.2f, 2);
            this.gameObject.SetActive(!isActive);
        }
    }
}
