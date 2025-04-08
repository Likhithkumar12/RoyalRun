using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    CinemachineCamera cinemachine;
    [SerializeField] ParticleSystem particles;
    [SerializeField] float minFOV=45f;
    [SerializeField] float maxFOV=85f;
    [SerializeField] float zoomduration=1f;
    [SerializeField]  float zoomspeed=5f;
    
    void Awake()
    {
        cinemachine=GetComponent<CinemachineCamera>();
    
    }
    public void changeFOV(float speedamount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangecamerRoutine(speedamount));
        if(speedamount>0)
        {
        particles.Play();
        }

    }
    IEnumerator ChangecamerRoutine(float speedamount)
    {
        float stratFOv=cinemachine.Lens.FieldOfView;
        float targetFOv=Mathf.Clamp(stratFOv+speedamount*zoomspeed,minFOV,maxFOV);
        float elsapsetime=0f;
        while(elsapsetime<zoomduration){
            elsapsetime+=Time.deltaTime;
            cinemachine.Lens.FieldOfView=Mathf.Lerp(stratFOv,targetFOv,elsapsetime/zoomduration);
            yield return null;

        }
        cinemachine.Lens.FieldOfView=targetFOv;


    
    }
}
