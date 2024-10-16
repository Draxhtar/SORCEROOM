using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    [SerializeField] private float duration;

    private void OnEnable()
    {
        Invoke("DestroySelf", duration);
    }

    void DestroySelf() 
    {
        Destroy(gameObject);
    }
}
