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
            UpdateGameOverScoreText();
        }
        private void UpdateGameOverScoreText()
        {
            gOverScoreText.text = "Score: " + GameInstanceHolder.Instance.GetScore().ToString();
        }
    }
}
