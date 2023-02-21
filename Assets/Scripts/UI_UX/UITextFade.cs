using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace UIManager
{
    public class UITextFade : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 1;
        private Text currentText;

        private void Start()
        {
            currentText = GetComponent<Text>();
            FadeAnim();
        }
        private void FadeAnim()
        {
            Sequence sequence = 
            DOTween.Sequence().Append(currentText.DOFade(0, fadeDuration)).Append(currentText.DOFade(1, fadeDuration));
            sequence.SetLoops(-1, LoopType.Restart);
        }
    }
}