using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteract : MonoBehaviour
{
    [SerializeField] private ParticleSystem flowerParticle;
     

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        flowerParticle.Play();
    }
}
