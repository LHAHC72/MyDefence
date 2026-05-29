using UnityEngine;



public class BulletMove : MonoBehaviour
{
    // 최적화 타이머
    float CurrentTime = 0;
    float CreateTime = 0.2f;


    // 총알 속도
    public float speed = 1.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime >= CreateTime)
        {
            
            
        }
        // 앞으로 이동
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
    }
}
