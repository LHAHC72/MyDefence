using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyDefence
{

    public class UIManager : MonoBehaviour
    {
        [System.Serializable]
        public struct InGameUI
        {
            public TMP_Text lifeText;
            public TMP_Text goldText;
        }

        [System.Serializable]
        public struct GameOverUI
        {
            public GameObject panel;
            public Text roundText;
            public Animator animator; // 애니메이션 제어용
        }

        [System.Serializable]
        public struct PauseUI
        {
            public GameObject panel;
        }

        [Header("UI Groups")]
        [SerializeField] private InGameUI inGameUI;
        [SerializeField] private GameOverUI gameOverUI;
        [SerializeField] private PauseUI pauseUI;

        private bool isPaused = false;
        private bool isGameOver = false;

        // 다른 스크립트(Enemy 등)에서 TriggerGameOver를 호출하기 위한 싱글톤 참조
        public static UIManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // 게임 시작 시 UI 초기화
            InitUI();
        }

        private void Update()
        {
            // 게임오버 상태가 아닐 때만 ESC 입력(일시정지) 가능
            if (!isGameOver)
            {
                CheckPauseInput();
            }

            // 3. 치트키 'O'를 누르면 게임오버 UI 활성화
            if (Input.GetKeyDown(KeyCode.O) && !isGameOver)
            {
                TriggerGameOver();
            }

            // 라이프/소지금 UI 갱신
            RefreshHUD();
        }

        /// <summary>
        /// 라이프, 소지금 UI 텍스트를 GameData 값으로 갱신
        /// </summary>
        private void RefreshHUD()
        {
            // GameData는 정적 프로퍼티로 값에 접근합니다.
            inGameUI.lifeText.text = $"{GameData.Lives}";
            inGameUI.goldText.text = $"{GameData.Gold}";
        }

        /// <summary>
        /// 초기 UI 텍스트 및 패널 상태 설정
        /// </summary>
        private void InitUI()
        {
            // 0. 플레이 씬 UI 초기화 (GameData에서 값 동기화)
            RefreshHUD();

            // 패널들은 처음엔 꺼둠
            gameOverUI.panel.SetActive(false);
            pauseUI.panel.SetActive(false);

            // 시간 정상 흐름
            Time.timeScale = 1f;
        }

        /// <summary>
        /// 6. ESC 키 입력을 확인하여 일시정지 토글
        /// </summary>
        private void CheckPauseInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;

                // 일시정지 UI 활성화/비활성화
                pauseUI.panel.SetActive(isPaused);

                // Time.timeScale = 0 이면 모든 물리, Update, 타이머가 멈춤
                Time.timeScale = isPaused ? 0f : 1f;
            }
        }

        /// <summary>
        /// 3. 게임 오버 발동 함수
        /// </summary>
        public void TriggerGameOver()
        {
            isGameOver = true;

            // 1. 게임오버 UI 활성화
            gameOverUI.panel.SetActive(true);

            // 1. GameData에서 라운드 수 가져와 UI 반영
            // GameData.Waves를 사용해서 생존 라운드를 표시
            gameOverUI.roundText.text = $"{GameData.Waves} ROUNDS SURVIVED";

            // 4. 게임오버 UI 애니메이션 재생 (트리거 파라미터 "Play" 가정)
            if (gameOverUI.animator != null)
            {
                gameOverUI.animator.SetTrigger("Play");
            }

            // 게임오버 시에도 게임 세상을 멈추고 싶다면 주석 해제
            // Time.timeScale = 0f; 
        }

        // ==========================================
        // 버튼 연결용 함수들 (Button Component - OnClick)
        // ==========================================

        /// <summary>
        /// 2. RESTART 버튼 기능
        /// </summary>
        public void OnClickRestart()
        {
            Debug.Log("Run RESTART");

            // 일시정지 상태에서 재시작할 수 있으므로 시간 축을 정상으로 돌려놓음
            Time.timeScale = 1f;

            // 현재 액티브 씬을 다시 로드 (SceneManager 활용)
            Scene currentScene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(currentScene.name);
            // SceneManager.LoadScene(SceneManager.GetActiveScene.buildIndex);

        }

        /// <summary>
        /// 2, 7. MAIN MENU 버튼 기능
        /// </summary>
        public void OnClickMainMenu()
        {
            Debug.Log("Goto Menu");

            // 메인 메뉴로 가더라도 시간은 흐르게 설정
            Time.timeScale = 1f;

            // 실제 메인메뉴 씬 이름이 "MainMenu" 라면 전환 (여기선 디버그 로그 확인용)
            // SceneManager.LoadScene("MainMenu");
        }
    }
}