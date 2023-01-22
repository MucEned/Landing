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
        protected Image buttonImg;
        [SerializeField] protected Sprite soundMuteSprite;
        [SerializeField] protected Sprite soundSprite;
        protected bool isMute = false;

        protected void Awake()
        {
            buttonImg = GetComponent<Image>();
        }

        protected void UpdateButtonSprite()

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
        protected virtual void UpdateMuteState()
        {
            return;

        }
    }
}