using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class UIExitMenu : MonoBehaviour
    {
        [SerializeField] private UIScalingPanel exitPanel;

        private bool isEscaping = false;
        
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && isEscaping == false)
            {
                exitPanel.Active();
                isEscaping = true;
            }
            else if(Input.GetKeyUp(KeyCode.Escape) && isEscaping == true)
            {
                TurnOffExitMenu();
            }
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        public void TurnOffExitMenu()
        {
            exitPanel.Deactive();
            isEscaping = false;
        }
    }
}