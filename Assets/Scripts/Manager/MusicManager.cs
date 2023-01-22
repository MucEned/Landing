using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;

namespace Managers
{
    public class MusicManager : SoundManager
    {
        protected override void Awake()
        {
            base.Awake();
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