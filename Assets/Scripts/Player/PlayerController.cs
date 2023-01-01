using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEvents;
using UnityEngine.SocialPlatforms;

namespace Player
{ 
    public enum MoveState
    {
        Normal,
        Landing
    }
    public class PlayerController : MonoBehaviour
    {
        private const float PHYSIC_CONST = 100f;
        private const int MAX_ACTION_POINT = 4;
        private const int MIN_ACTION_POINT = 0;

        [SerializeField] private float speed = 2f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float landForce = 10f;

        private bool isRightButtonPress = false;
        private bool isLeftButtonPress = false;

        private Rigidbody2D rb;
        private Vector2 jumpVector;
        private Vector2 landVector;

        private int actionPoint;
        public int ActionPoint { get { return actionPoint; }}

        public bool IsGrounded = false;
        public MoveState MoveState = MoveState.Normal;
        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            jumpVector = new Vector2(0f, jumpForce);
            landVector = new Vector2(0f, -1f*landForce);

            SubscribeEvent();
        }
        private void OnDestroy()
        {
            UnsubscribeEvent();
        }
        private void SubscribeEvent()
        {
            AllEvents.OnDevilDead += OnKillDevil;
        }
        private void UnsubscribeEvent()
        {
            AllEvents.OnDevilDead -= OnKillDevil;
        }

        // Update is called once per frame
        private void Update()
        {
            WindowControl();
            Move();
        }
        private void WindowControl()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isLeftButtonPress = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                isLeftButtonPress = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isRightButtonPress = true;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                isRightButtonPress = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Land();
            }
        }
        private int GetMoveDir()
        {
            return (isLeftButtonPress? -1 : 0) + (isRightButtonPress? 1 : 0);
        }
        private void Move()
        {
            rb.velocity = new Vector2(speed * GetMoveDir(), rb.velocity.y);
        }
        private void Jump(bool isTakeActionPoint = true)
        {
            if (actionPoint <= 0) return;
            rb.velocity = Vector2.zero;
            SetState(MoveState.Normal);
            rb.AddForce(jumpVector * PHYSIC_CONST);
            if (isTakeActionPoint) AddActionPoints(-1);
        }
        private void Land()
        {
            //if (actionPoint <= 0) return;
            rb.velocity = Vector2.zero;
            SetState(MoveState.Landing);
            rb.AddForce(landVector * PHYSIC_CONST);
        }
        private void AddActionPoints(int value)
        {
            actionPoint = Mathf.Clamp(actionPoint + value, MIN_ACTION_POINT, MAX_ACTION_POINT);
            AllEvents.OnPlayerActionPointSet?.Invoke(actionPoint);
        }
        private void SetActionPoints(int value)
        {
            actionPoint = Mathf.Clamp(value, MIN_ACTION_POINT, MAX_ACTION_POINT);
            AllEvents.OnPlayerActionPointSet?.Invoke(actionPoint);
        }
        public void RegenActionPoint()
        {
            SetActionPoints(MAX_ACTION_POINT);
        }
        public void SetState(MoveState value)
        {
            MoveState = value;
        }
        private void OnKillDevil()
        {
            AddActionPoints(1);
            Jump(false);
        }
    }
}
