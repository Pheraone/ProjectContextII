using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteraction : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    public float maxRange;

    [SerializeField] private ParticleSystem flowerParticle;

    public bool hasScored = false;
    public void OnStartHover()
    {
        //highlight mat
        Debug.Log($"Interacting with {gameObject}");
    }

    public void OnInteract()
    {
        if(hasScored == false)
        {

            Player.Instance.score++;
        }

        hasScored = true;
        Debug.Log(Player.Instance.score);
        //particle play

        flowerParticle.Play();
        Debug.Log($"Woooo Particles {gameObject}");
    }

    public void OnEndHover()
    {

        Debug.Log($"Stopped interacting with {gameObject}");
        //normal mat
    }

}
