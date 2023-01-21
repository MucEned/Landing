using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class SettingMenu : MonoBehaviour
    {
        [SerializeField] private GameObject settingPanel;
        private bool isMenuActive = false;

        private void Awake()
        {
            settingPanel = this.gameObject.transform.GetChild(0).gameObject;
        }
        public void MenuController()
        {
            settingPanel.gameObject.SetActive(!isMenuActive);
            isMenuActive = !isMenuActive;
        }        
    }
}