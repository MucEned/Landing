using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class SFXManager : SoundManager
    {
        public static SFXManager Instance;

        protected void Awake()
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
            AllEvents.OnSFXSettingChange += ChangeMuteState;
        }
        protected virtual void OnDisable()
        {
            AllEvents.OnSFXSettingChange -= ChangeMuteState;
        }
        public override void PlaySound(AudioClip clip)
        {
            if(!isMute)
            {
                source.PlayOneShot(clip);
            }
        }
    }
}