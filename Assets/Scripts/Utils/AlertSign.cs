using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSign : MonoBehaviour
{
    [SerializeField] private const float TRIGGER_TIME = 3;
    private float triggerTimeCountdown;
    
    [SerializeField] GameObject objectToTrigger;

    private void OnEnable()
    {
        triggerTimeCountdown = TRIGGER_TIME;
    } 
    private void Update()
    {
        CheckToActiveObject();
    }
    private void CheckToActiveObject()
    {
        if(triggerTimeCountdown >= 0)
        {
            triggerTimeCountdown -= Time.deltaTime;
            if(triggerTimeCountdown < 0)
            {
                objectToTrigger.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
    private void PlayAnim()
    {

    }
}
