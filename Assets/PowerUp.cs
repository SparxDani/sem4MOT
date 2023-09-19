using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;

    void Start()
    {
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            firstCamera.enabled = !firstCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
            Destroy(gameObject);
        }
    }
}
