using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{

    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        public string loadToScene = "PlayScene";

        public void Play()
        {
            // 게임 씬으로 이동
            SceneManager.LoadScene(loadToScene);
        }

        public void Quit()
        {
            // 게임 종료
            // 에디터에서는 명령 무시, 빌드된 게임에서는 애플리케이션을 종료합니다.
            Application.Quit();
        }
        
    }
}