using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    private static FlowerManager instance;
    public static FlowerManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<FlowerManager>();
            return instance;

        }
    }

    public GameObject flowerObject1;
    public GameObject flowerObject2;
    public GameObject flowerObject3;
    public GameObject flowerObject4;

    public int firstGoal =  1;
    public int secondGoal = 2;
    public int thirdGoal =  3;
    public int fourthGoal = 4;



    private void fixedUpdate()
    {
    }

    public void CheckOrange(bool test)
    {
        if (test == true)
        {
            Debug.Log("hello");
            flowerObject1.SetActive(true);
        }
    }
    public void CheckBlue(bool blue)
    {
        if (blue == true)
        {
            Debug.Log("hello1");
            flowerObject2.SetActive(true);
        }
    }

    public void CheckPink(bool pink)
    {
        if (pink == true)
        {
            Debug.Log("hello1");
            flowerObject3.SetActive(true);
        }
    }

    public void CheckPurple(bool purple)
    {
        if (purple == true)
        {
            Debug.Log("hello1");
            flowerObject4.SetActive(true);
        }
    }
    // if (FlowerInteraction.Instance.pinkFlowerHit == true)
    //{
    //    Debug.Log("hello2");
    //    flowerObject3.SetActive(true);
    //}
    // if (FlowerInteraction.Instance.purpleFlowerHit == true)
    //{
    //    Debug.Log("hello3");
    //    flowerObject4.SetActive(true);
    //}




}
