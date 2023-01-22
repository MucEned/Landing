using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class MusicCarrier : MonoBehaviour
{
    [SerializeField] AudioClip musicClip;

    private void Start()
    {
        if(musicClip != null)
        {
            Managers.MusicManager.Instance.PlaySound(musicClip);

        }
    }
}
