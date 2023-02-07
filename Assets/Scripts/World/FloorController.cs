using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Objects
{
    public class FloorController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Ceiling"))    
            {
                // AllEvents.OnPlayerDeadByCeiling?.Invoke();
            }
        }
    }
}
