using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] float starttime = 5f;

    [Header("UI Elements")]
    [SerializeField] TMP_Text gametime;
    [SerializeField] GameObject gametext;
    [SerializeField] GameObject tapToPlay;
    [SerializeField] GameObject taptoplayagain;

    [Header("Game Components")]
    [SerializeField] PlayerMovement Player;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] GameObject Image;
    [SerializeField] GameObject gametitle;

    float lefttime = 0f;
    bool isGameOver = false;
    bool gameStarted = false;

    public bool gameoverr => isGameOver;

    BlinkText blinktext;
    scoremanager scoremanager;

    void Awake()
    {
        blinktext = FindFirstObjectByType<BlinkText>();
        scoremanager = FindFirstObjectByType<scoremanager>();
        ResetGameToDefault();
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
            return;
        }


        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGameagain();
            }
            return;
        }

        gameover();
    }

    public void addtimevalue(float amount)
    {
        lefttime += amount;
    }

    void gameover()
    {
        if (isGameOver) return;

        lefttime -= Time.deltaTime;
        gametime.text = lefttime.ToString("F2");

        if (lefttime <= 0f)
        {
            GameOverText();
            taptoplayagain.SetActive(true);
        }
    }

    void GameOverText()
    {
        isGameOver = true;
        Player.enabled = false;
        gametext.SetActive(true);
        Time.timeScale = 0.1f;
    }

    void StartGameagain()
    {
        ResetGameToDefault(); 
        StartGame();          
    }

    void StartGame()
    {
        Image.SetActive(false); 
        gametitle.SetActive(false);
        gameStarted = true;
        isGameOver = false;
        Time.timeScale = 1f;
        Player.enabled = true;
        scoremanager.resetscore();
        taptoplayagain.SetActive(false);
        gametext.SetActive(false);
        tapToPlay.SetActive(false);
        bgMusic?.Play();
    }

    void ResetGameToDefault()
    {
        lefttime = starttime;
        gameStarted = false;
        isGameOver = false;
        Time.timeScale = 0f;
        Player.enabled = false;
        gametext.SetActive(false);
        tapToPlay.SetActive(true);
        taptoplayagain.SetActive(false);
        gametime.text = starttime.ToString("F2");
        Image.SetActive(true);
        gametitle.SetActive(true);
        bgMusic?.Stop();
        scoremanager.resetscore();
    }
}
