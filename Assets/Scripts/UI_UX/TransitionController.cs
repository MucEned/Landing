using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private GameObject transitionPanel;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartTransition()
    {
        anim.Play("TransitionIn");
    }
    public void EndTransition()
    {
        anim.Play("TransitionOut");
    }
}
