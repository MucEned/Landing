using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Player
{
    public class PlayerHitBox : MonoBehaviour
    {
        private BoxCollider2D col;

        private void Start()
        {
            col = GetComponent<BoxCollider2D>();
        }
        private void OnEnable()
        {
            AllEvents.OnPlayerDead += DeactiveHitBox;
            AllEvents.OnPlayerDeadByCeiling += DeactiveHitBox;
            AllEvents.OnPlayerRevive += ActiveHitBox;
        }
        private void OnDisable()
        {
            AllEvents.OnPlayerDead -= DeactiveHitBox;
            AllEvents.OnPlayerDeadByCeiling -= DeactiveHitBox;
            AllEvents.OnPlayerRevive -= ActiveHitBox;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeadTouch"))
            {
                AllEvents.OnPlayerDead?.Invoke();
            }
            if (other.CompareTag("Ceiling"))
            {
                AllEvents.OnPlayerDeadByCeiling?.Invoke();
            }
        }
        private void DeactiveHitBox()
        {
            col.enabled = false;
        }
        private void ActiveHitBox()
        {
            col.enabled = true;
        }
    }
}
