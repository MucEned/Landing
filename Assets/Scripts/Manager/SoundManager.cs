using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        protected AudioSource source;
        protected bool isMute = false;

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
            if (Instance != null)
            {
                Debug.LogWarning("More than 1 SoundManager in the scene");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            source = GetComponent<AudioSource>();
        }
        public virtual void PlaySound(AudioClip clip)
        {
            return;
        }
        public bool GetMuteState()
        {
            return isMute;
        }
        protected void ChangeMuteState()
        {
            source.mute = !isMute;
            isMute = !isMute;
        }
    }
}