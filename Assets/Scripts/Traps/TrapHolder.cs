using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Traps
{
    public class TrapHolder : MonoBehaviour
    {
        [SerializeField] private GameObject alertSign;
        public bool isActive = false;

        public void ActiveSignal()
        {
            alertSign.SetActive(true);
            isActive = true;
        }
        public void ResetTrap()
        {
            isActive = false;
            Managers.TrapController.Instance.BackToUnspawnedList(this);
        }
    }
}
