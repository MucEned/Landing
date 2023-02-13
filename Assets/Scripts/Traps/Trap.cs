using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traps
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] protected const float ACTIVE_TIME = 3;
        protected float activeTimeCountdown = 3;
        protected TrapHolder trapHolder;

        protected void Awake()
        {
            trapHolder = GetComponentInParent<TrapHolder>();
        }
        protected virtual void Update()
        {
            Countdown();
        }
        protected virtual void Deactive()
        {
            trapHolder.ResetTrap();
            activeTimeCountdown = ACTIVE_TIME;
            this.gameObject.SetActive(false);
        }
        protected virtual void Countdown()
        {
            if (activeTimeCountdown >= 0)
            {
                activeTimeCountdown -= Time.deltaTime;
                if (activeTimeCountdown < 0)
                {
                    Deactive();
                }
            }
        }
    }
}