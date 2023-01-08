using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Player
{
    public class PlayerFeet : MonoBehaviour
    {
        private PlayerController player;
        private void Start()
        {
            player = GetComponentInParent<PlayerController>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Land"))
            {
                if (!player.IsGrounded)
                {
                    player.IsGrounded = true;
                    player.RegenActionPoint();

                    if (player.MoveState == MoveState.Landing)
                    {
                        AllEvents.OnPlayerLanding?.Invoke();
                    }

                    player.SetState(MoveState.Normal);
                    AllEvents.OnPlayerTouchTheGround?.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Land"))
            {
                if (player.IsGrounded)
                {
                    player.IsGrounded = false;
                }
            }
        }
    }
}

