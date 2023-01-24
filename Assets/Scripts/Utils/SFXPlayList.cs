using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using GameEvents;

public class SFXPlayList : MonoBehaviour
{
    [Header("Player SFX")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip hitEnemySFX;
    [SerializeField] private AudioClip playerDeadSFX;
    [SerializeField] private AudioClip touchGroundSFX;

    [Header("UI SFX")]
    [SerializeField] private AudioClip scoreUpdateSFX;
    [SerializeField] private AudioClip timerUpdateSFX;

    private void Awake()
    {
        //Player Event Register
        AllEvents.OnPlayerJump += PlayJumpSFX;
        AllEvents.OnPlayerTouchTheGround += PlayTouchGroundSFX;

        //UI Event Register
        AllEvents.OnScoreUpdate += PlayScoreUpdateSFX;
        AllEvents.OnTimerUpdate += PlayTimerUpdateSFX;
    }
    private void OnDisable()
    {
        //Player Event Deregister
        AllEvents.OnPlayerJump -= PlayJumpSFX;
        AllEvents.OnPlayerTouchTheGround -= PlayTouchGroundSFX;

        //UI Event Deregister
        AllEvents.OnScoreUpdate -= PlayScoreUpdateSFX;
        AllEvents.OnTimerUpdate -= PlayTimerUpdateSFX;
    }
    private void PlaySFX(AudioClip clip)
    {
        if(clip != null)
        {
            Managers.SFXManager.Instance.PlaySound(clip);
        }
    }
    #region PLAYER SFX REGION
    private void PlayJumpSFX()
    {
        PlaySFX(jumpSFX);
    }
    private void PlayPlayerDeadSFX()
    {
        PlaySFX(playerDeadSFX);
    }
    private void PlayHitEnemySFX()
    {
        PlaySFX(hitEnemySFX);
    }
    private void PlayTouchGroundSFX()
    {
        PlaySFX(touchGroundSFX);
    }
    #endregion

    #region UI SFX REGION
    private void PlayScoreUpdateSFX()
    {
        PlaySFX(scoreUpdateSFX);
    }
    private void PlayTimerUpdateSFX()
    {
        PlaySFX(timerUpdateSFX);
    }
    #endregion
}
