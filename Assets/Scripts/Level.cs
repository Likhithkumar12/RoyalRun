
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Level : MonoBehaviour
{
 [SerializeField]  CameraController cameraC;
  [SerializeField] GameObject[] ChunkPrefabs;
  [SerializeField]  GameObject checkpointprefab;
  
  [SerializeField] scoremanager scoremanage;
  [SerializeField] int chunkcount;
  [SerializeField] int counttospawncheckpoint=8;
  [SerializeField] Transform chunkparent;
  [SerializeField] float chunklength=10f;
  [SerializeField] float chunkmovespeed=8f;
  [SerializeField]  float minmovespeed=2f;
  [SerializeField]  float maxmovespeed=20f;
  [SerializeField]  float MinGravityZ=-22f;
  [SerializeField] float maxGravityZ=-2f;

   List<GameObject> chunks=new List<GameObject>();
   int chunksspawned=0;
  
    void Start()
    {
        spawnprefabs();

    }
    public  void movechunkspeed(float speedamount){
        float newmovespeed=chunkmovespeed+speedamount;
        newmovespeed=Mathf.Clamp(newmovespeed,minmovespeed,maxmovespeed);
       
        if(newmovespeed!=chunkmovespeed)
        {
            chunkmovespeed=newmovespeed;

            float garvityzvalue=Physics.gravity.z-speedamount;
            garvityzvalue=Mathf.Clamp(garvityzvalue,MinGravityZ,maxGravityZ);
            Physics.gravity=new Vector3(Physics.gravity.x,Physics.gravity.y,garvityzvalue);
            cameraC.changeFOV(speedamount);
        }
       
    
    }

    private void spawnprefabs()
    {
        for (int i = 0; i < chunkcount; i++)
        {
            Nspawnchunks();
        }
    }

    private void Nspawnchunks()
    {
        float chunkpos = spawnchunkposition();
        Vector3 spawnpos = new Vector3(transform.position.x, transform.position.y, chunkpos);
        GameObject chunkstospan = choosechunktospawn();

        GameObject newchunk0 = Instantiate(chunkstospan, spawnpos, Quaternion.identity, chunkparent);
        chunks.Add(newchunk0);
        Fence newchunk = newchunk0.GetComponent<Fence>();
        newchunk.Init(this, scoremanage);
        chunksspawned++;

    }

    private GameObject choosechunktospawn()
    {
        GameObject chunkstospan;
        if (chunksspawned % counttospawncheckpoint == 0 && chunksspawned!=0)
        {
            chunkstospan = checkpointprefab;
        }
        else
        {
            chunkstospan = ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)];
        }

        return chunkstospan;
    }

    private float spawnchunkposition()
    {
        float chunkpos;
        if (chunks.Count == 0)
        {
            chunkpos = transform.position.z;

        }
        else
        {
            chunkpos = chunks[chunks.Count - 1].transform.position.z + chunklength;
        }

        return chunkpos;
    }

    void Update()
    {
        chunkmovement();
        
    }
    private void chunkmovement()
    {
        for (int i=0;i<chunks.Count;i++)
        {
            GameObject chunk=chunks[i];
            chunk.transform.Translate(-transform.forward*(chunkmovespeed*Time.deltaTime));
            if(chunk.transform.position.z<=Camera.main.transform.position.z-chunklength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                Nspawnchunks();
               

            }
        
           

        }
    }
}
