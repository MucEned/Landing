using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public PlayerController Player;
        private void Awake()
        {
            Instance = this;
            Player = FindObjectOfType<PlayerController>();
        }
    }
}
