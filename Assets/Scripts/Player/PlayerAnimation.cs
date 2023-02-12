using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GameEvents;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Transform display;
    [SerializeField] private Vector3 punchScaleAmount = new Vector3(0.1f, 0.3f, 0f);
    [SerializeField] private Vector3 punchScaleLandAmount = new Vector3(0.05f, 0.5f, 0f);
    [SerializeField] private Vector3 shakeRotateAmount = new Vector3(0f, 0f, 15f);
    [SerializeField] private GameObject deadVFX;
    private Vector3 defaultScale;

    void Start()
    {
        defaultScale = display.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayJumpAnim()
    {
        display.localScale = defaultScale;
        display.rotation = Quaternion.identity;
        display.DOPunchScale(punchScaleAmount, 0.1f);
        display.DOShakeRotation(0.1f, shakeRotateAmount);
    }
    public void PlayLandAnim()
    {
        display.localScale = defaultScale;
        display.rotation = Quaternion.identity;
        display.DOPunchScale(punchScaleAmount, 0.1f);
    }
    public void PlayDeadAnim()
    {
        display.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 1f).OnComplete(()=>{ //temp
            Instantiate(deadVFX, transform.position, Quaternion.identity);
            display.gameObject.SetActive(false);
            AllEvents.OnPlayerAlreadyDead?.Invoke();
        });
    }
}
