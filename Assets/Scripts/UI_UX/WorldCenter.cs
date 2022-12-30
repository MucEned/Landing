using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using DG.Tweening;

namespace GameUX
{
    public class WorldCenter : MonoBehaviour
    {
        private Sequence actionQueue;
        private void Start()
        {
            AllEvents.OnPlayerLanding += OnPlayerLanding;
        }
        private void OnDestroy()
        {
            AllEvents.OnPlayerLanding -= OnPlayerLanding;
        }

        private void OnPlayerLanding()
        {
            if (actionQueue != null)
                actionQueue.Kill();
            actionQueue = DOTween.Sequence().Append(transform.DOMoveY(0.5f, 0.1f)).Append(transform.DOMoveY(0f, 0.1f));
            actionQueue.Play();
        }
    }
}
