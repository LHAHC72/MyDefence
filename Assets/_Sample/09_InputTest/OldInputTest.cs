using System.Runtime.CompilerServices;
using UnityEngine;

public class OldInputTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey("w"))
        {
            Debug.Log("w키를 누르고 있습니다.");
        }

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("w키에서 눌렀습니다.");
        }

        if (Input.GetKeyUp("w"))
        {
            Debug.Log("w키를 눌렀다가 떼었습니다.");
        }*/
/*
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("w키를 누르고 있습니다.");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w키에서 눌렀습니다.");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("w키를 눌렀다가 떼었습니다.");
        }

        // GetButton - InputManager(AXes)에 정의되어있는 Buttons 의 이름을 가져와서 사용한다.
        // 버튼의 이름은 문자열로 가져온다.
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump 버튼(스페이스바)를 누르고 있습니다.");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump 버튼(스페이스바)를 눌렀습니다.");
        }
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Jump 버튼(스페이스바)를 눌렀다 떼었습니다.");
        }

        // GetAxes - InputManager에 정의되어 있는 Axes(Buttons) 의 이름을 가져와서 사용한다
        // a, left : -1 ~ 0
        // d, right : 0 ~ 1
        float hValue = Input.GetAxis("Horizontal");
        Debug.Log($"Horizontal GetAxis value:{hValue}");

        float vValue = Input.GetAxis("Vertical");
        Debug.Log($"Vertical GetAxis value:{vValue}");
*/
        
        // 스크린상의 마우스 위치값 가져오기
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        Debug.Log($"{mouseX}:{mouseY}");
    }
}
