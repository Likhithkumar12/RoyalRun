using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fence : MonoBehaviour
{
    [SerializeField] GameObject fence;
    [SerializeField] GameObject Apple;
    [SerializeField] GameObject coin;
    [SerializeField] float applechance=0.3f;
     [SerializeField] float coinchance=0.5f;
     [SerializeField] float coinseperationlength=2f;
   
    [SerializeField] float[] lanes={-3f,0f,3f};
     List<int> availablelanes=new List<int>{0,1,2};
     Level level;
     scoremanager scoremanage;
     public void Init(Level level,scoremanager scoremanage)
     {
        this.level=level;
        this.scoremanage=scoremanage;

     }
    void Start()
    {
        spawnfence();
        spawnApple();
        spawncoin();
    }

   void spawnfence()
    {
        int fencestospawn=Random.Range(0,lanes.Length);
        for(int i=0; i<fencestospawn;i++)
        {
            if (availablelanes.Count <= 0)
            {
                break;
            }
            int selectedline = selectlane();
            Vector3 spawnpos = new Vector3(lanes[selectedline], transform.position.y, transform.position.z);
            Instantiate(fence, spawnpos, Quaternion.identity, this.transform);
        }

    }
    void spawnApple()
    {
        if(Random.value>applechance || availablelanes.Count<=0)
        {
            return;
        }
            int selectedline = selectlane();
            Vector3 spawnpos = new Vector3(lanes[selectedline], transform.position.y, transform.position.z);
            apple newapple=Instantiate(Apple, spawnpos, Quaternion.identity, this.transform).GetComponent<apple>();
            newapple.Init(level);


    }
    void spawncoin()
    {
        

        if(Random.value>coinchance || availablelanes.Count<=0)
        {
            return;
        }
        int selectedline = selectlane();
        int maxcoins=6;
        int coinstopsawn=Random.Range(0,maxcoins);
        for(int i=0;i<coinstopsawn;i++){
            float spawnposz=transform.position.z+coinseperationlength*i;
            Vector3 spawnpos = new Vector3(lanes[selectedline], transform.position.y,spawnposz);
            coin newcoin=Instantiate(coin, spawnpos, Quaternion.identity, this.transform).GetComponent<coin>();
            newcoin.Init(scoremanage);
        }

    }

    private int selectlane()
    {
        int randomindex = Random.Range(0, availablelanes.Count);
        int selectedline = availablelanes[randomindex];
        availablelanes.RemoveAt(randomindex);
        return selectedline;
    }
}
