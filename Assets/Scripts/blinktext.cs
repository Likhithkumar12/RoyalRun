using TMPro;
using UnityEngine;
using System.Collections;

public class BlinkText : MonoBehaviour
{
    public float blinkSpeed = 0.2f; 

    public IEnumerator Blink(GameObject textToBBlink)
    {
        while (true)
        {
            textToBBlink.SetActive(!textToBBlink.activeSelf);
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
