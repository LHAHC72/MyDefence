using UnityEngine;

public class AnimatorTest 
{
    private Animator animator;
    
    public float anitimer;
    public float countdown = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();

        countdown = 0;

        InvokeRepeating("RandomFlameAnimation", 0f, 1f);
    }

    private T GetComponent<T>()
    {
        throw new System.NotImplementedException();
    }

    private void InvokeRepeating(string v1, float v2, float v3)
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        countdown += Time.deltaTime;
        if (countdown >= anitimer)
        {

            RandomFlameAnimation();
            countdown = 0f;
            
        }
    }

    void RandomFlameAnimation()
    {
        int lightMode = Random.Range(1, 4);
        animator.SetInteger("lightMode", lightMode);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 라이트 애니메이션 3개중에 하나를 랜덤으로 재생하는 코드
}
