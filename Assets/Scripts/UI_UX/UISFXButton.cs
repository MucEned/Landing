using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using Managers;

namespace UIManager
{
    public class UISFXButton : UISoundButton
    {
        protected void OnEnable()
        {
            UpdateButtonSprite();
            AllEvents.OnSFXSettingChange += UpdateButtonSprite;
        }
        protected void OnDisable()
        {
            AllEvents.OnSFXSettingChange -= UpdateButtonSprite;
        }
        protected override void UpdateMuteState()
        {
            if (SFXManager.Instance == null)
            {
                Debug.LogWarning("No MusicManager in the scene");
                return;
            }
            isMute = SFXManager.Instance.GetMuteState();
        }
    }
}