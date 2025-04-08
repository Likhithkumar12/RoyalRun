using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        
    }
}
