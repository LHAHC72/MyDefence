using Unity.Hierarchy;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 적의 이동 속도
    public float speed = 1.0f;

    // 적의 도착지를 설정하는 변수
    private float destroyZPosition = -17f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 앞으로 이동
        transform.Translate(Vector3.forward *  speed * Time.deltaTime);

        // 만약 좌표가 도착지보다 작아지면
        if(transform.position.z <= destroyZPosition)
        {
            Destroy(gameObject);
            Debug.Log("종점 도착!!!");
        }



    }
}
