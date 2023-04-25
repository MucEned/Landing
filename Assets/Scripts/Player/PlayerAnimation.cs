using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameEvents;

namespace Player
{

    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Transform display;
        [SerializeField] private Vector3 punchScaleAmount = new Vector3(0.1f, 0.3f, 0f);
        [SerializeField] private Vector3 punchScaleLandAmount = new Vector3(0.05f, 0.5f, 0f);
        [SerializeField] private Vector3 shakeRotateAmount = new Vector3(0f, 0f, 15f);
        [SerializeField] private GameObject deadVFX;
        [SerializeField] private ParticleSystem burningJump;
        [SerializeField] private ParticleSystem burstLanding;
        private Vector3 defaultScale;

        void Start()
        {
            AllEvents.OnPlayerRevive += OnPlayerRevive;
            defaultScale = display.localScale;
        }
        private void OnDestroy()
        {
            AllEvents.OnPlayerRevive -= OnPlayerRevive;
        }
        public void PlayJumpAnim()
        {
            display.localScale = defaultScale;
            display.rotation = Quaternion.identity;
            display.DOPunchScale(punchScaleAmount, 0.1f);
            display.DOShakeRotation(0.1f, shakeRotateAmount);
            burningJump.Play();
        }
        public void PlayLandAnim()
        {
            display.localScale = defaultScale;
            display.rotation = Quaternion.identity;
            display.DOPunchScale(punchScaleAmount, 0.1f);
        }
        public void PlayLandEffect()
        {
            burstLanding.Play();
        }
        public void PlayDeadAnim()
        {
            display.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1f).OnComplete(() =>
            { //temp
                Debug.Log("hah");
                Instantiate(deadVFX, transform.position, Quaternion.identity);
                display.gameObject.SetActive(false);
                AllEvents.OnPlayerAlreadyDead?.Invoke();
            });
        }
        private void OnPlayerRevive()
        {
            display.gameObject.SetActive(true);
        }
    }
}
