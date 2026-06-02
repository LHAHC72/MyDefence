using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateCannon : MonoBehaviour
{

    private Renderer tileRenderer;  // 색 컴포넌트 가져올 변수
    private Color originalColor;    // 원래 색 기억할 변수
    public Color hoverColor;        // 지정할 색

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 타일 색 컴포넌트 가져오기
        tileRenderer = GetComponent<Renderer>();

        // 원래 색 기억하기
        originalColor = tileRenderer.material.color;
    }

    // 마우스 올라갔을 때
    void OnMouseEnter()
    {
        // 지정한 색으로 변경
        tileRenderer.material.color = hoverColor;
    }
    // 마우스 나갔을 때
    void OnMouseExit()
    {
        tileRenderer.material.color = originalColor;
    }

    // 마우스를 클릭했을 때
    private void OnMouseDown()
    {
        // 문구 출력
        Debug.Log("마우스 클릭 - 여기에 터렛 설치");

        // 터렛 설치
        BuildManager.instance.BuildTurretOn(this.gameObject);

    }
}
