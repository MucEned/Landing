using GameEvents;
using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtBox : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feet") && GameInstanceHolder.Instance.Player.MoveState == MoveState.Landing)
        {
            AllEvents.OnLandOnBoss?.Invoke();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}
