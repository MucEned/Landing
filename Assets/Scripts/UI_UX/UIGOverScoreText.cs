using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;
using Managers;

namespace UIManager
{
    public class UIGOverScoreText : MonoBehaviour
    {
        [SerializeField] Text gOverScoreText;
        
        private void OnEnable()
        {
            AllEvents.OnPlayerDead += UpdateGameOverScoreText;
        }
        private void OnDisable()
        {
            AllEvents.OnPlayerDead -= UpdateGameOverScoreText;
        }
        private void UpdateGameOverScoreText()
        {
            gOverScoreText.text = "Score: " + GameInstanceHolder.Instance.GetScore().ToString();
        }
    }
}
