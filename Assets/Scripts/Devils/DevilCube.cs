using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using Managers;
using Player;

namespace Devil
{
    public class DevilCube : MonoBehaviour
    {
        [SerializeField] private GameObject deadEffect;
        private const float MIN_SPEED = 0.25f;
        private const float MAX_SPEED = 1f;

        private float speed;
        void Start()
        {
            speed = UnityEngine.Random.Range(MIN_SPEED, MAX_SPEED);
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
        private void Deactive()
        {
            this.gameObject.SetActive(false);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Feet") && GameInstanceHolder.Instance.Player.MoveState == MoveState.Landing)
            {
                AllEvents.OnDevilDead?.Invoke();
                Instantiate(deadEffect, transform.position, Quaternion.identity);
                Deactive();
            }
        }
    }
}

