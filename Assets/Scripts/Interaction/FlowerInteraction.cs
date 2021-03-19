using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteraction : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }
    public float maxRange;

    public void OnStartHover()
    {
        //highlight mat
        Debug.Log($"Interacting with {gameObject}");
    }

    public void OnInteract()
    {
        //particle play
        Debug.Log($"Woooo Particles {gameObject}");
    }

    public void OnEndHover()
    {

        Debug.Log($"Stopped interacting with {gameObject}");
        //normal mat
    }

}
