using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager Instance;
        private AudioSource source;
        [SerializeField] private Sprite sfxMuteSprite;
        [SerializeField] private Sprite sfxSprite;
        private bool isMute = false;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            if(Instance != null)
            {
                Debug.LogWarning("More than 1 SFXManager in the scene");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            source = GetComponent<AudioSource>();
        }

    }
}