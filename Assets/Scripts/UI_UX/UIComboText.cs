using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using DG.Tweening;
using UnityEngine.UI;

namespace UIManager
{
    public class UIComboText : MonoBehaviour
    {
        [SerializeField] private Vector3 punchScaleAmount = new Vector3(0.2f, 0.2f, 0f);
        [SerializeField] private Vector3 shakePositionAmount = new Vector3(10f, 10f, 0f);

        private int currentStreak;
        private const string COMBO_STR = "Combo x ";
        private Text content;

        void Start()
        {
            AllEvents.OnStreak += OnStreak;
            AllEvents.OnResetStreak += OnResetStreak;

            content = GetComponent<Text>();
        }
        void OnDestroy()
        {
            AllEvents.OnStreak -= OnStreak;
            AllEvents.OnResetStreak -= OnResetStreak;
        }
        void OnStreak(int streak)
        {
            transform.localScale = Vector3.one;
            transform.DOPunchScale(punchScaleAmount, 0.1f);

            content.text = COMBO_STR + streak.ToString();
        }
        void OnResetStreak()
        {
            transform.localScale = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
