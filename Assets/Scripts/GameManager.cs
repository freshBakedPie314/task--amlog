using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isMenu = false;
    public float score = 0;
    public int coins = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreTextGO;
    [SerializeField] private TextMeshProUGUI coinTextGO;
    [SerializeField] private AudioSource rocketAudioSource;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
        if (isMenu) return;
        scoreText.text = score.ToString();
        coinText.text = coins.ToString();
    }

    void Update()
    {
        if (isMenu) return;
        if (isGameOver) return;

        score += Time.deltaTime * 10f;
        scoreText.text = ((int)score).ToString();
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        scoreTextGO.text = "Score: " + scoreText.text;
        coinTextGO.text = "Coins: " + coinText.text;
        rocketAudioSource.enabled = false;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}