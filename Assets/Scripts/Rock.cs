using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
   CinemachineImpulseSource cinemachineImpulseSource;
   [SerializeField] AudioSource ap;
   [SerializeField] ParticleSystem rockcollsion;
   [SerializeField] float shaker=10f;
   [SerializeField] float cooldowntime=2f;

    float cooltime=0f;
   void Awake()
   {
    cinemachineImpulseSource=GetComponent<CinemachineImpulseSource>();
    
   }
    void Update()
    {
        cooltime+=Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(cooltime<cooldowntime) return ;
        FireImpulse();
        collisionandaudio(other);
        cooltime=0f;
        
    }
    void FireImpulse()
    {
        float distance=Vector3.Distance(transform.position,Camera.main.transform.position);
        float shakevalue=(1f/distance)*shaker;
        shakevalue=Mathf.Min(shakevalue,1f);
        cinemachineImpulseSource.GenerateImpulse(shakevalue);
    }
    void collisionandaudio(Collision other){
        ContactPoint contact=other.contacts[0];
        rockcollsion.transform.position=contact.point;
        rockcollsion.Play();
        ap.Play();

    }
}
