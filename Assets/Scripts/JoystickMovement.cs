using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image imgJoystickBg, imgJoystick;
    private Vector2 posInput;
    public bool walkingMode = false;

    void Start(){
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData){
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posInput)){
                
                posInput.x = posInput.x / (imgJoystickBg.rectTransform.sizeDelta.x);
                posInput.y = posInput.y / (imgJoystickBg.rectTransform.sizeDelta.y);

                if(posInput.magnitude > 1.0f){
                    posInput = posInput.normalized;
                }

                //Joystick Movement System
                imgJoystick.rectTransform.anchoredPosition = new Vector2(
                    posInput.x * (imgJoystickBg.rectTransform.sizeDelta.x / 2),
                    posInput.y * (imgJoystickBg.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        walkingMode = true;
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData){
        walkingMode = false;
        posInput = Vector2.zero;
        imgJoystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal(){
        if(posInput.x != 0)
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical(){
        if(posInput.y != 0)
            return posInput.y;
        else
            return Input.GetAxis("Vertical");
    }


}
