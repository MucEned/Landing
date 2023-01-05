using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using DG.Tweening;

namespace GameUX
{
    public class WorldCenter : MonoBehaviour
    {
        private Vector3 worldDeviatedVector3 = new Vector3();
        private Vector3[] allWorldDeviated = {Vector3.right, Vector3.up, Vector3.left, Vector3.down};
        private Sequence actionQueue;
        private void Start()
        {
            AllEvents.OnPlayerLanding += OnPlayerLanding;
            AllEvents.OnWorldDeviated += OnWorldDeviated;
        }
        private void OnDestroy()
        {
            AllEvents.OnPlayerLanding -= OnPlayerLanding;
            AllEvents.OnWorldDeviated -= OnWorldDeviated;
        }

        private void OnPlayerLanding()
        {
            if (actionQueue != null)
                actionQueue.Kill();
            actionQueue = DOTween.Sequence().Append(transform.DOMoveY(0.5f, 0.1f)).Append(transform.DOMoveY(0f, 0.1f));
            actionQueue.Play();
        }
        private void OnWorldDeviated(int dir)
        {
            if (actionQueue != null)
                actionQueue.Kill();

            actionQueue = DOTween.Sequence().Append(transform.DOMove(allWorldDeviated[dir] * -0.5f, 0.1f)).Append(transform.DOMove(Vector3.zero, 0.1f));
            actionQueue.Play();
        }
    }
}
