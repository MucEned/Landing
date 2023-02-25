using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace UIManager
{
    public class PauseMenu : MonoBehaviour
    {
        UIScalingPanel menuPanel;
        bool isMenuActive = false;

        void Awake()
        {
            menuPanel = this.gameObject.transform.GetChild(0).GetComponent<UIScalingPanel>();
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
            }
            else
            {
                menuPanel.Active();
            }
            isMenuActive = !isMenuActive;
        }
    }
}