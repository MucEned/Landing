using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Traps
{
    public class AlertSign : MonoBehaviour
    {
        [SerializeField] private const float TRIGGER_TIME = 3;
        private float triggerTimeCountdown;

        [SerializeField] GameObject objectToTrigger;

        private bool isScaleUp = false;

        private Vector3 trapToggleAnimVec = new Vector3(0.2f, 0.2f, 0.2f);

        private void OnEnable()
        {
            triggerTimeCountdown = TRIGGER_TIME;
        }
        private void Update()
        {
            CheckToActiveObject();
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
        private void ToggleObject(bool isActive)
        {
            objectToTrigger.SetActive(isActive);
            objectToTrigger.transform.DOPunchScale(trapToggleAnimVec, 0.2f, 2);
            this.gameObject.SetActive(!isActive);
        }
    }
}
