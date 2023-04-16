using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Player
{
    public class PlayerHitBox : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("DeadTouch"))    
            {
                AllEvents.OnPlayerDead?.Invoke();
                DeactiveHitBox();
            }
            if (other.CompareTag("Ceiling"))    
            {
                AllEvents.OnPlayerDeadByCeiling?.Invoke();
                DeactiveHitBox();
            }
        }
        private void DeactiveHitBox()
        {
            this.gameObject.SetActive(false);
        }
    }
}
