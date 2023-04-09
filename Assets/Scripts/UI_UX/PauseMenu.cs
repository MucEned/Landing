using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace UIManager
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private UIScalingPanel menuPanel;
        [SerializeField] private UIScalingPanel blurPanel;
        bool isMenuActive = false;

        void Awake()
        {
            AllEvents.OnGamePause += MenuController;
        }
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                AllEvents.OnGamePause?.Invoke();
            }
        }
        void OnDisable()
        {
            AllEvents.OnGamePause -= MenuController;
        }

        void MenuController()
        {
            if (isMenuActive)
            {
                menuPanel.Deactive();
                blurPanel.Deactive();
            }
            else
            {
                menuPanel.Active();
                blurPanel.Active();
            }
            isMenuActive = !isMenuActive;
        }
    }
}