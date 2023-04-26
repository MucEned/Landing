using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Objects
{
    public class CeilingController : MonoBehaviour
    {
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            AllEvents.OnDevilReachBarrier += Falldown;

        }
        void OnDestroy()
        {
            AllEvents.OnDevilReachBarrier -= Falldown;
        }
        void Falldown()
        {
            anim.Play("CeilingFall");
        }
    }
}
