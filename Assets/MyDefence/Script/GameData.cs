using UnityEngine;

public class GameData : MonoBehaviour
{
  

    public static GameData Instance { get; private set; }

    public int playerLife = 10;
    // 초기 소지금은 400 Gold로 설정합니다.
    public static int money = 1000;
    public int survivedRounds = 0;
    public GameObject gameover;


    public static int Gold => money;

    public static bool HasGold(int amount)
    {
        return money >= amount;
    }

    public static void AddGold(int amount)
    {
        money += amount;
    }

    public static bool UseGold(int amount)
    {
        if (!HasGold(amount))
            return false;

        money -= amount;
        return true;
    }

    // 적이 목적지에 도착했을 때 호출, 라이프가 0 이하가 되면 true(게임오버) 반환
    public bool LoseLife(int amount = 1)
    {
        playerLife -= amount;
        if(playerLife <=0)
        {
            playerLife = 0;
            GameOver(); 
            return false; // 게임오버
        }
        return true;
    }

    // 한 웨이브를 클리어했을 때 호출
    public void AddSurvivedRound()
    {
        survivedRounds++;
    }

    public void GameOver()
    {
        // 게임오버 처리 (예: 게임오버 UI 활성화)
        if (gameover != null)
        {
            gameover.SetActive(true);
        }
    }




    private void Awake()
    {
        // 싱글톤 인스턴스 세팅
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }

}