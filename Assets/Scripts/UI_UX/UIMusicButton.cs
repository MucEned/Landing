using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.UI;
using GameEvents;

namespace UIManager
{
    public class UIMusicButton : UISoundButton
    {
        protected void OnEnable()
        {
            UpdateButtonSprite();
            AllEvents.OnMusicSettingChange += UpdateButtonSprite;
        }
        protected void OnDisable()
        {
            AllEvents.OnMusicSettingChange -= UpdateButtonSprite;
        }
        protected override void UpdateMuteState()
        {
            if(MusicManager.Instance == null)
            {
                Debug.LogWarning("No MusicManager in the scene");
                return;
            }
            isMute = MusicManager.Instance.GetMuteState();
        }
    }
}