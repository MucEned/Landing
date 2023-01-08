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
        }

        void OnDisable()
        {
            AllEvents.OnGamePause -= UpdateMenuButtonUI;
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
    }
}