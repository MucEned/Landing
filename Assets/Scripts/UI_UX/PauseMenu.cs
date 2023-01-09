using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace UIManager
{
    public class PauseMenu : MonoBehaviour
    {   
        GameObject menuPanel;
        bool isMenuActive = false;

        void Awake()
        {
            menuPanel = this.gameObject.transform.GetChild(0).gameObject;
            AllEvents.OnGamePause += MenuController;
        }

        void OnDisable()
        {
            AllEvents.OnGamePause -= MenuController;
        }

        void MenuController()
        {
            menuPanel.gameObject.SetActive(!isMenuActive);
            isMenuActive = !isMenuActive;
        }
    }
}