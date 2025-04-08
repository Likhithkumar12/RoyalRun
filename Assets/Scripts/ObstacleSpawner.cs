using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   [SerializeField] GameObject[] Obstacles;
   [SerializeField] float waittime=2f;
   [SerializeField] float minwaittime=.2f;
    void Start()
    {
       StartCoroutine(spawnCoroutine());

    }
    public void Decreasewaittime(float amount)
    {
        waittime-=amount;
        if(waittime<=minwaittime)
        {
            waittime=minwaittime;
        }
    }

    IEnumerator spawnCoroutine()
    {
        while (true)
        {
            GameObject ObstacloeSpawner = Obstacles[Random.Range(0, Obstacles.Length)];
            yield return new WaitForSeconds(waittime);
            Instantiate(ObstacloeSpawner, transform.position,Random.rotation);
        }
    }

}
