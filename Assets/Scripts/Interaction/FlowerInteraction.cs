using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    internal bool purpleFlowerHit = false;
    internal bool orangeFlowerHit = false;
    internal bool lightBlueFlowerHit = false;
    internal bool pinkFlowerHit;
    private bool tutorialCheck = false;
    private IEnumerator coroutine;

    public void Start()
    {
        coroutine = WaitSeconds();
        pinkFlowerHit = false;
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("I am waiting");
        GameManager.Instance.inGameUI.SetActive(false);
    }

    public void OnStartHover()
    {
        //highlight mat
        Debug.Log($"Interacting with {gameObject}");

        //toegang tot gamobject
        if(tutorialCheck == false)
        {

            GameManager.Instance.inGameUI.SetActive(true);
            tutorialCheck = true;
        }
    }

    public void OnInteract()
    {
        Debug.Log($"Woooo Particles {gameObject.tag}");
        if (hasScored == false)
        {
            Player.Instance.score++;
        }

        if(gameObject.tag == "FlowerOrange")
        {
            orangeFlowerHit = true;

            FlowerManager.Instance.CheckOrange(orangeFlowerHit);
        }

        if (gameObject.tag == "FlowerLightBlue")
        {
            lightBlueFlowerHit = true;

            FlowerManager.Instance.CheckBlue(lightBlueFlowerHit);
        }


        if (gameObject.tag == "FlowerPurple")
        {
            purpleFlowerHit = true;
            FlowerManager.Instance.CheckPurple(purpleFlowerHit);
        }


        if (gameObject.tag == "FlowerPink")
        {
            pinkFlowerHit = true;
            FlowerManager.Instance.CheckPink(pinkFlowerHit);
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

        StartCoroutine(coroutine);
    }

}
