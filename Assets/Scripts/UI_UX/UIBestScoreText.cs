using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManager
{
    public class UIBestScoreText : MonoBehaviour
    {
        [SerializeField] private Text bestScoreText;

        private void Start()
        {
            UpdateBestScoreText();
        }

        private void UpdateBestScoreText()
        {
            bestScoreText.text = "Best: " + PlayerPrefs.GetInt("BestScore", 0).ToString();

        }
    }
}
