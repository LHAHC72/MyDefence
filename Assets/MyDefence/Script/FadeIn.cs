using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    [Tooltip("페이드 인에 걸리는 시간(초)")]
    public float duration = 1.0f;

    [Tooltip("시작 전 대기 시간(초)")]
    public float delay = 0f;

    [Tooltip("씬 시작 시 자동으로 페이드 인을 실행할지 여부")]
    public bool startOnAwake = true;

    [Tooltip("사용할 Image (없으면 자동 생성)")]
    public Image fadeImage;

    void Awake()
    {
        if (fadeImage == null)
            CreateFadeObjects();

        // 처음에는 완전 검게 설정
        SetAlpha(1f);
    }

    void Start()
    {
        if (startOnAwake)
            StartCoroutine(FadeInRoutine());
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        if (delay > 0f)
            yield return new WaitForSeconds(delay);

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(1f, 0f, Mathf.Clamp01(t / duration));
            SetAlpha(a);
            yield return null;
        }

        SetAlpha(0f);

        // 페이드가 완료되면 오버레이를 제거
        if (fadeImage != null)
            Destroy(fadeImage.gameObject.transform.parent.gameObject);
    }

    void SetAlpha(float a)
    {
        if (fadeImage == null) return;
        Color c = fadeImage.color;
        c.a = a;
        fadeImage.color = c;
    }

    void CreateFadeObjects()
    {
        // Canvas 생성
        GameObject canvasGO = new GameObject("FadeCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 9999;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Image 생성
        GameObject imageGO = new GameObject("FadeImage");
        imageGO.transform.SetParent(canvasGO.transform, false);
        Image img = imageGO.AddComponent<Image>();
        img.color = Color.black;

        RectTransform rt = img.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        fadeImage = img;
    }
}
