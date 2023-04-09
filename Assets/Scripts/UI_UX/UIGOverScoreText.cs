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
            int currentScore = GameInstanceHolder.Instance.GetScore();
            gOverScoreText.text = "Score: " + currentScore.ToString();
            SaveBestScore(currentScore);
        }
        private void SaveBestScore(int currentScore)
        {
            int tempScore = PlayerPrefs.GetInt("BestScore", 0);
            if(tempScore < currentScore)
            {
                PlayerPrefs.SetInt("BestScore", currentScore);
            }
        }
    }
}
