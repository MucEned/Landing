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
    [SerializeField] private AudioClip clickSFX;

    [Header("GAMEPLAY SFX")]
    [SerializeField] private AudioClip loseSFX;
    [SerializeField] private AudioClip enemyDeadSFX;
    [SerializeField] private AudioClip spawnSFX;

    private void Awake()
    {
        //Player Event Register
        AllEvents.OnPlayerJump += PlayJumpSFX;
        AllEvents.OnPlayerTouchTheGround += PlayTouchGroundSFX;
        AllEvents.OnPlayerDead += PlayPlayerDeadSFX;
        AllEvents.OnPlayerDeadByCeiling += PlayPlayerDeadSFX;
        
        //UI Event Register
        AllEvents.OnScoreUpdate += PlayScoreUpdateSFX;
        AllEvents.OnTimerUpdate += PlayTimerUpdateSFX;

        //Gameplay Event Register
        AllEvents.OnDevilDead += PlayEnemyDeadSFX;
        AllEvents.OnPlayerAlreadyDead += PlayLoseSFX;
    }
    private void OnDisable()
    {
        //Player Event Deregister
        AllEvents.OnPlayerJump -= PlayJumpSFX;
        AllEvents.OnPlayerTouchTheGround -= PlayTouchGroundSFX;
        AllEvents.OnPlayerDead -= PlayPlayerDeadSFX;
        AllEvents.OnPlayerDeadByCeiling -= PlayPlayerDeadSFX;
        
        //UI Event Deregister
        AllEvents.OnScoreUpdate -= PlayScoreUpdateSFX;
        AllEvents.OnTimerUpdate -= PlayTimerUpdateSFX;

        //Gameplay Event Deregister
        AllEvents.OnDevilDead -= PlayEnemyDeadSFX;
        AllEvents.OnPlayerAlreadyDead -= PlayLoseSFX;
    }
    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
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
    private void PlayClickSFX()
    {
        PlaySFX(clickSFX);
    }
    #endregion

    #region GAMEPLAY SFX
    private void PlayLoseSFX()
    {
        PlaySFX(loseSFX);
    }
    private void PlayEnemyDeadSFX()
    {
        PlaySFX(enemyDeadSFX);
    }
    private void PlaySpawnSFX()
    {
        PlaySFX(spawnSFX);
    }
    #endregion
}
