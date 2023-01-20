using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameEvents;

namespace UIManager
{
    public class UIGameOverMenu : MonoBehaviour
    {
        [SerializeField] private float scaleSize = 1;
        [SerializeField] private float scaleDuration = 1;

        private void Awake()
        {
            AllEvents.OnPlayerDead += ScaleMenu;
        }
        private void OnDisable()
        {
            AllEvents.OnPlayerDead -= ScaleMenu;
        }
        private void ScaleMenu()
        {
            transform.DOScale(scaleSize, scaleDuration);
        }
    }
}