using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramedDisable : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    [SerializeField] private float delay;
    [SerializeField] private Collider objcollider;
    [SerializeField] private ParticleSystem particles;

    void Disable()
    {
        objcollider.enabled = false;
    }


    private void OnValidate()
    {
        var lifetime = particles.main.startLifetime.constant;
        if (delay < lifetime)
        {
            delay = lifetime ;
        }
    }
    
    private void Awake()
    {
        Disable();
    }

    private void Update()
    {
        if (Input.GetKeyDown(input))
        {
            if (!objcollider.enabled)
            {
                objcollider.enabled = true;
                Invoke(nameof(Disable), delay);
                var main = particles.main;

                main.duration = delay - main.startLifetime.constant;
                particles.Play();
            }
        }
    }
}
