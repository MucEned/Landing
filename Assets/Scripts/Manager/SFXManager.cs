using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class SFXManager : SoundManager
    {
        protected override void Awake()
        {
            base.Awake();
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