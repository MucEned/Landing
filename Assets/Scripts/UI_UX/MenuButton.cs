using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;

namespace UIManager
{
public class MenuButton : MonoBehaviour
{
    [SerializeField] Sprite pauseImg;
    [SerializeField] Sprite resumeImg;
    Button menuButton;
    bool isPause = false;
    void Awake()
    {
        menuButton = GetComponent<Button>();
        AllEvents.OnGamePause += UpdateMenuButtonUI;
        AllEvents.OnGamePause += SetTimeScale;
    }

    void OnDisable()
    {
        AllEvents.OnGamePause -= UpdateMenuButtonUI;
        AllEvents.OnGamePause -= SetTimeScale;
    }

    public void ButtonClick()
    {
        AllEvents.OnGamePause?.Invoke();
    }
    void UpdateMenuButtonUI()
    {
        if(isPause == false)
        {
            isPause = true;
            menuButton.image.sprite = resumeImg;
        }
        else
        {
            isPause = false;
            menuButton.image.sprite = pauseImg;
        }
    }
    
    void SetTimeScale()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
}