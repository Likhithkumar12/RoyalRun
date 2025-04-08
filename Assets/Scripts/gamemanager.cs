using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class gamemanager : MonoBehaviour
{
   [SerializeField] float starttime=5f;
   [SerializeField] TMP_Text gametime;
   [SerializeField] GameObject gametext;
   [SerializeField] PlayerMovement Player;


   float lefttime=0;
   bool game=false;
   public bool gameoverr => game;

    void Start()
    {
        lefttime=starttime;

    }
    void Update()
    {
        gameover();
    }
    public void addtimevalue(float amount)
    {
        lefttime+=amount;
    }
    void gameover()
    {
        if(game) return;
        lefttime-=Time.deltaTime;
        gametime.text=lefttime.ToString("F2");
        if(lefttime<=0f)
        {
            gameovertext();
        }
    }
    void gameovertext()
    {
        game=true;
        Player.enabled=false;
        gametext.SetActive(true);
        Time.timeScale=.1f;
      


    }
    }
