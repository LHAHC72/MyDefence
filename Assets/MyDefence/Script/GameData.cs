using UnityEngine;

public class GameData : MonoBehaviour
{
    // static 변수는 Scene이 바뀌어도 데이터가 유지되며, 어디서나 접근 가능합니다.
    // 초기 소지금은 400 Gold로 설정합니다.
    public static int money = 1000;

    private void Start()
    {
        Debug.Log($"[게임 시작] 현재 소지금: {money} Gold");
    }
}