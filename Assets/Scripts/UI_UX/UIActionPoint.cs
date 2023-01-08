using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEvents;
using System.Diagnostics.Contracts;
using Managers;
using DG.Tweening;

namespace UIManager
{
    public class UIActionPoint : MonoBehaviour
    {
        [SerializeField] private Color ACTIVE_COLOR;
        [SerializeField] private Color DEACTIVE_COLOR;

        private List<Image> actionIcon = new List<Image>();
        private int currentActionPointRef;
        // Start is called before the first frame update
        void Start()
        {
            foreach (Transform icon in transform)
            {
                actionIcon.Add(icon.GetComponent<Image>());
            }
            currentActionPointRef = GameInstanceHolder.Instance.Player.ActionPoint;
            AllEvents.OnPlayerActionPointSet += OnPlayerActionPointSet;
        }
        private void OnDestroy()
        {
            AllEvents.OnPlayerActionPointSet -= OnPlayerActionPointSet;
        }
        private void OnPlayerActionPointSet(int actionPoint)
        {
            if (actionPoint > 0)
            {
                actionIcon[actionPoint - 1].transform.localScale = Vector2.one;
                actionIcon[actionPoint - 1].transform.DOShakeScale(0.1f);
            }


            currentActionPointRef = actionPoint;
            for (int i = 0; i < actionIcon.Count; i++)
            {
                if (i <= (currentActionPointRef - 1) && currentActionPointRef != 0)
                    actionIcon[i].color = ACTIVE_COLOR;
                else
                    actionIcon[i].color = DEACTIVE_COLOR;
            }
        }
    }
}


