using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteraction : MonoBehaviour, IInteractable
{
    private static FlowerInteraction instance;
    public static FlowerInteraction Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<FlowerInteraction>();
            return instance;
          
        }
    }

    public float MaxRange { get { return maxRange; } }
    public float maxRange;

    [SerializeField] private ParticleSystem flowerParticle;

    public bool hasScored = false;
    public bool purpleFlowerHit = false;
    public bool orangeFlowerHit = false;
    public bool lightBlueFlowerHit = false;
    public bool pinkFlowerHit = false;
    public void OnStartHover()
    {
        //highlight mat
        Debug.Log($"Interacting with {gameObject}");

        //toegang tot gamobject
    }

    public void OnInteract()
    {
        if(hasScored == false)
        {
            Player.Instance.score++;
        }

        if(gameObject.tag == "FlowerOrange")
        {
            orangeFlowerHit = true;
        }

        if (gameObject.tag == "FlowerLightBlue")
        {
            lightBlueFlowerHit = true;
        }

        if (gameObject.tag == "FlowerPink")
        {
            pinkFlowerHit = true;
        }

        if (gameObject.tag == "FlowerPurple")
        {
            purpleFlowerHit = true;
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
