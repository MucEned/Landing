using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        private AudioSource source;
        private bool isMute = false;

        private void Awake()
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
            AllEvents.OnSoundSettingChange += ChangeMuteState;

        }
        private void OnDisable()
        {
            AllEvents.OnSoundSettingChange -= ChangeMuteState;

        }
        public void PlayMusic(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
        public bool GetMuteState()
        {
            return isMute;
        }
        private void ChangeMuteState()
        {
            source.mute = !isMute;
            isMute = !isMute;
        }
    }
}