using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenKiller : MonoBehaviour
{
    private void OnDestroy()
    {
        DOTween.Clear();
    }
}
