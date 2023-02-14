using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class AlterControl : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform debugDetectPos;
        [SerializeField] private float MIN_HOR_DIS;
        [SerializeField] private float MIN_JUMP_DIS;
        [SerializeField] private float MIN_LAND_DIS;
        [SerializeField] private float RECOVER_ACTION;
        private Vector3 currentDetectPosition;
        private bool isJump = false;
        private float jumpCooldown;
        private bool isLand = false;
        private float landCooldown;
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentDetectPosition = Input.mousePosition;
                debugDetectPos.position = currentDetectPosition;
            }
            if (Input.GetMouseButton(0))
            {
                currentDetectPosition = Vector3.Lerp(currentDetectPosition, Input.mousePosition, Time.deltaTime * 5f);

                if (currentDetectPosition.x - Input.mousePosition.x > MIN_HOR_DIS)
                {
                    //Move left
                    Debug.Log("Moveleft");
                    AlterControlEvents.OnToggleControlMoveLeft?.Invoke(true);
                }
                else
                {
                    //Stop move left
                    AlterControlEvents.OnToggleControlMoveLeft?.Invoke(false);
                }
                if (Input.mousePosition.x - currentDetectPosition.x > MIN_HOR_DIS)
                {
                    //Move right
                    Debug.Log("Moveright");
                    AlterControlEvents.OnToggleControlMoveRight?.Invoke(true);
                }
                else
                {
                    //Stop move right
                    AlterControlEvents.OnToggleControlMoveRight?.Invoke(false);
                }
                if (currentDetectPosition.y - Input.mousePosition.y > MIN_LAND_DIS && !isLand)
                {
                    //Land
                    isLand = true;
                    landCooldown = RECOVER_ACTION;
                    AlterControlEvents.OnControlLand?.Invoke();
                    currentDetectPosition.y = Input.mousePosition.y;
                }
                if (Input.mousePosition.y - currentDetectPosition.y > MIN_JUMP_DIS && !isJump)
                {
                    //Jump
                    isJump = true;
                    jumpCooldown = RECOVER_ACTION;
                    AlterControlEvents.OnControlJump?.Invoke(true);
                    currentDetectPosition.y = Input.mousePosition.y;
                }
                debugDetectPos.position = currentDetectPosition;
                Debug.Log(currentDetectPosition.x + ", " + Input.mousePosition.x + "____HOR");
                Debug.Log(currentDetectPosition.y + ", " + Input.mousePosition.y + "____VER");
            }
            if (Input.GetMouseButtonUp(0))
            {
                isJump = false;
                isLand = false;
                AlterControlEvents.OnToggleControlMoveLeft?.Invoke(false);
                AlterControlEvents.OnToggleControlMoveRight?.Invoke(false);
            }

            if (isJump)
            {
                jumpCooldown -= Time.deltaTime;
                if (jumpCooldown <= 0) isJump = false;
            }
            if (isLand)
            {
                landCooldown -= Time.deltaTime;
                if (landCooldown <= 0) isLand = false;
            }
        }
        // public void OnPointerDown(PointerEventData pointerEventData)
        // {
        //     //Output the name of the GameObject that is being clicked
        //     Debug.Log(name + "Game Object Click in Progress");
        // }
        // public void OnPointerUp(PointerEventData pointerEventData)
        // {
        //     Debug.Log(name + "No longer being clicked");
        // }
    }
}
;