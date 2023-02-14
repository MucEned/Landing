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
        [SerializeField] private float MIN_VER_DIS;
        private Vector3 currentDetectPosition;
        private bool isJumpOrLand = false;
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
                currentDetectPosition = Vector3.Lerp(currentDetectPosition, Input.mousePosition, Time.deltaTime);

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
                if (currentDetectPosition.y - Input.mousePosition.y > MIN_VER_DIS && !isJumpOrLand)
                {
                    //Land
                    isJumpOrLand = true;
                    AlterControlEvents.OnControlLand?.Invoke();
                    currentDetectPosition = Input.mousePosition;
                }
                if (Input.mousePosition.y - currentDetectPosition.y > MIN_VER_DIS && !isJumpOrLand)
                {
                    //Jump
                    isJumpOrLand = true;
                    AlterControlEvents.OnControlJump?.Invoke(true);
                    currentDetectPosition = Input.mousePosition;
                }
                debugDetectPos.position = currentDetectPosition;
                Debug.Log(currentDetectPosition.x + ", " + Input.mousePosition.x + "____HOR");
                Debug.Log(currentDetectPosition.y + ", " + Input.mousePosition.y + "____VER");
            }
            if (Input.GetMouseButtonUp(0))
            {
                isJumpOrLand = false;
                AlterControlEvents.OnToggleControlMoveLeft?.Invoke(false);
                AlterControlEvents.OnToggleControlMoveRight?.Invoke(false);
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