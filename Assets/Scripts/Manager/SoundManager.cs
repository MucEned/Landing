using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        private AudioSource source;
        [SerializeField] private Sprite soundMuteSprite;
        [SerializeField] private Sprite soundSprite;
        private bool isMute = false;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            if(Instance != null)
            {
                Debug.LogWarning("More than 1 SoundManager in the scene");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            source = GetComponent<AudioSource>();
        }
        public void PlayMusic(AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}