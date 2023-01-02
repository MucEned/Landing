using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIManager
{
public class MenuButton : MonoBehaviour
{
    [SerializeField] Sprite pauseImg;
    [SerializeField] Sprite playImg;
    Button menuButton;
    bool isPause = false;
    void Awake()
    {
        menuButton = GetComponent<Button>();
    }

    public void ButtonClick()
    {
        if(isPause == false)
        {
            isPause = true;
            menuButton.image.sprite = playImg;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            menuButton.image.sprite = pauseImg;
            Time.timeScale = 1;
        }
    }
}
}