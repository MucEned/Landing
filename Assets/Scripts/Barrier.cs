using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Objects
{
    public class Barrier : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Devil"))
            {
                Destroy(col.gameObject);
                AllEvents.OnDevilReachBarrier?.Invoke();
            }
        }
    }
}