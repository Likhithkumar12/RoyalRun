using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string playername="Player";
    [SerializeField]  float Rotationspeed=100f;
    protected Level level;
    void Start()
    { 
        level=FindFirstObjectByType<Level>();
    
    }
    void Update()
    {
        transform.Rotate(0f,Rotationspeed*Time.deltaTime,0f);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playername))
        {
           onPickup();
           Destroy(gameObject);
        }   
        
    }
    protected abstract  void onPickup();
}
