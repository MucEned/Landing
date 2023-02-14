using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player
{
    public class AlterControlEvents : MonoBehaviour
    {
        public static Action<bool> OnToggleControlMoveLeft;
        public static Action<bool> OnToggleControlMoveRight;
        public static Action<bool /* is take action point */> OnControlJump;
        public static Action OnControlLand;
    }
}
