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
            ScaleUp(scaleSize, scaleDuration);
        }
        public void Active()
        {
            this.gameObject.SetActive(true);
        }
        public void Deactive()
        {
            ScaleDown(0, scaleDuration);
        }
        private void ScaleUp(float _scaleSize, float _scaleDuration)
        {
            transform.DOScale(_scaleSize, _scaleDuration).SetUpdate(true);
        }
        private void ScaleDown(float _scaleSize, float _scaleDuration)
        {
            transform.DOScale(_scaleSize, _scaleDuration).SetUpdate(true).OnComplete(() =>
            {
                this.gameObject.SetActive(false);
            });
        }
    }
}