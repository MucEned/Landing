using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using UnityEngine.UI;
using Managers;

namespace UIManager
{
public class UIScoreText : MonoBehaviour
{
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

    void UpdateUIScoreText()
    {
        scoreText.text = GameInstanceHolder.Instance.score.ToString();
    }
}
}