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

        private void Awake()
        {
            currentText = GetComponent<Text>();
            FadeOutAnim();
        }
        private void FadeInAnim()
        {
            currentText.DOFade(1, fadeDuration).OnComplete(() =>
            {
                FadeOutAnim();
            });
        }
        private void FadeOutAnim()
        {
            currentText.DOFade(0, fadeDuration).OnComplete(() =>
            {
                FadeInAnim();
            });
        }
    }
}