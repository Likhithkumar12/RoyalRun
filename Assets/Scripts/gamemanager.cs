using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    scoremanager scoremanager;
    private bool gameStarted = false;
    float lefttime;
    [SerializeField] float starttime = 30f;
    public bool isGameOver;
    [SerializeField] PlayerMovement Player;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] TextMeshProUGUI gametime;

    void Awake()
    {
        game.SetActive(false);
        Time.timeScale = 1f;
        scoremanager = FindFirstObjectByType<scoremanager>();
    }

    void Update()
    {
        HandleGameTimer();
    }

    public void addtimevalue(float amount)
    {
        lefttime += amount;
    }

    void GameOverText()
    {
        isGameOver = true;
        Player.enabled = false;
        Time.timeScale = 0.1f;
    }

     public void StartGame()
    {
        game.SetActive(true);
        Debug.Log("StartGame() called");
        gameStarted = true;
        isGameOver = false;
        lefttime = starttime;
        Time.timeScale = 1f;

        scoremanager?.resetscore();
        //bgMusic?.Play();
    }

    public void HandleGameTimer()
    {
        if (isGameOver) return;

        lefttime -= Time.deltaTime;
        gametime.text = lefttime.ToString("F2");

        if (lefttime <= 0f)
        {
            GameOverText();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
