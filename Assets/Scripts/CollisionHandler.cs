using System.Data;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    const string hitString="Hit";
    [SerializeField] float timetocooldown=1f;
    float cooldowntime=0f;
    [SerializeField] float decreasespeedamount=-2f;
    Level level;

    void Start()
    {
    level=FindFirstObjectByType<Level>();

    }
    void Update()
    {
        cooldowntime+=Time.deltaTime;
        
    }

    void OnCollisionEnter(Collision other)
    {

    if (cooldowntime < timetocooldown) return;
    if (!other.gameObject.CompareTag("Ground"))  
    {
        level.movechunkspeed(decreasespeedamount);  
        animator.SetTrigger(hitString);             
        cooldowntime = 0f;                          
    }
}
}
