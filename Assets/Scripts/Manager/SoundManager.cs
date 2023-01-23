using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        protected AudioSource source;
        protected bool isMute = false;

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