using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class SettingMenu : MonoBehaviour
    {
        [SerializeField] private GameObject settingPanel;
        private bool isMenuActive = false;

        public void MenuController()
        {
            settingPanel.gameObject.SetActive(!isMenuActive);
            isMenuActive = !isMenuActive;
        }        
    }
}