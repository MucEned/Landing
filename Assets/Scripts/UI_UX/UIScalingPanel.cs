using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using DG.Tweening;

namespace UIManager 
{
    public class UIScalingPanel : MonoBehaviour
    {
        [SerializeField] private float scaleSize = 1;
        [SerializeField] private float scaleDuration = 1;

        private void OnEnable()
        {
            ScaleMenu(scaleSize, scaleDuration);
        }
        private void OnDisable()
        {
            ScaleMenu(0, scaleDuration);
        }
        private void ScaleMenu(float _scaleSize, float _scaleDuration)
        {
            transform.DOScale(_scaleSize, _scaleDuration);
        }
    }
}