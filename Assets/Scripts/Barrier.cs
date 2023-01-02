using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
}