using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEngine.UI;
using GameEvents;

namespace UIManager
{
    public class UISoundButton : MonoBehaviour
    {
        private Image buttonImg;
        [SerializeField] private Sprite soundMuteSprite;
        [SerializeField] private Sprite soundSprite;
        private bool isMute = false;

        private void Awake()
        {
            buttonImg = GetComponent<Image>();
        }
        private void OnEnable()
        {
            UpdateButtonSprite();
            AllEvents.OnSoundSettingChange += UpdateButtonSprite;

        }
        private void OnDisable()
        {
            AllEvents.OnSoundSettingChange -= UpdateButtonSprite;
        }
        private void UpdateButtonSprite()
        {
            UpdateMuteState();
            if (isMute)
            {
                buttonImg.sprite = soundMuteSprite;
            }
            else
            {
                buttonImg.sprite = soundSprite;
            }
        }
        private void UpdateMuteState()
        {
            isMute = SoundManager.Instance.GetMuteState();
        }
    }
}