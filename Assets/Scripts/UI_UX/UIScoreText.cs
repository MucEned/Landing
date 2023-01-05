using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using UnityEngine.UI;
using Managers;
using DG.Tweening;

namespace UIManager
{
    public class UIScoreText : MonoBehaviour
    {
        [SerializeField] private Vector3 punchScaleAmount = new Vector3(0.1f, 0.1f, 0f);
        [SerializeField] private Vector3 shakeRotateAmount = new Vector3(0f, 0f, 15f);
        private Text scoreText; 
        // Start is called before the first frame update
        void Start()
        {
            scoreText = GetComponent<Text>();
            UpdateUIScoreText();
            AllEvents.OnScoreUpdate += UpdateUIScoreText;
        }

        void OnDisable()
        {
            AllEvents.OnScoreUpdate -= UpdateUIScoreText;
        }

        private void UpdateUIScoreText()
        {
            scoreText.text = GameInstanceHolder.Instance.GetScore().ToString();
            PlayScoreAnim();
        }
        private void PlayScoreAnim()
        {
            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.identity;

            transform.DOPunchScale(punchScaleAmount, 0.1f);
            transform.DOShakeRotation(0.1f, shakeRotateAmount);
        }
    }
}