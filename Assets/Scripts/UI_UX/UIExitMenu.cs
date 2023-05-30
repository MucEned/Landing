using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManager
{
    public class UIExitMenu : MonoBehaviour
    {
        [SerializeField] private UIScalingPanel exitPanel;
        private float scaleDuration; 

        private bool isEscaping = false;
        private bool isScaling = false;
        
        private void Start()
        {
            scaleDuration = exitPanel.ScaleDuration + 0.2f;
        }
        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && isEscaping == false && isScaling == false)
            {
                exitPanel.Active();
                isEscaping = true;
                isScaling = true;
                StartCoroutine(ResetScalingBool());
            }
            else if(Input.GetKeyUp(KeyCode.Escape) && isEscaping == true && isScaling == false)
            {
                TurnOffExitMenu();
                isScaling = true;
                StartCoroutine(ResetScalingBool());
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
        private IEnumerator ResetScalingBool()
        {
            yield return new WaitForSeconds(scaleDuration);
            isScaling = false;
        }
    }
}