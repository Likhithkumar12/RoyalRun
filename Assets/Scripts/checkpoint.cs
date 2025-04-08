using UnityEngine;

public class checkpoint : MonoBehaviour
{
    gamemanager gamer;
    [SerializeField] float timeamount=5f;
    [SerializeField] float decreaeamount=0.2f;
    const string player="Player";
    ObstacleSpawner obstacleSpawner;
    void Start()
    {
    gamer=FindFirstObjectByType<gamemanager>();
    obstacleSpawner=FindFirstObjectByType<ObstacleSpawner>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(player))
        {
          gamer.addtimevalue(timeamount);
          obstacleSpawner.Decreasewaittime(decreaeamount);

        }
        
    }
}
