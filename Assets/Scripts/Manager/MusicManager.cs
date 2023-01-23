using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class MusicManager : SoundManager
    {
        public static MusicManager Instance;
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
            AllEvents.OnMusicSettingChange += ChangeMuteState;
        }
        protected virtual void OnDisable()
        {
            AllEvents.OnMusicSettingChange -= ChangeMuteState;
        }
        public override void PlaySound(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}