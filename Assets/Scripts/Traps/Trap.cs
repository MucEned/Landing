using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Traps
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] protected const float ACTIVE_TIME = 3;
        protected float activeTimeCountdown = 3;
        protected TrapHolder trapHolder;

        private Vector3 punchAnimVec = new Vector3(0.2f,0.2f,0.2f);

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
            this.transform.DOPunchScale(punchAnimVec, 0.2f, 2).OnComplete(()=>{this.gameObject.SetActive(false);});
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