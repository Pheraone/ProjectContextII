using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public  GameObject flowerObject1;
    public GameObject flowerObject2;
    public GameObject flowerObject3;
    public GameObject flowerObject4;

    public int firstGoal =  1;
    public int secondGoal = 2;
    public int thirdGoal =  3;
    public int fourthGoal = 4;

    public GameObject OrangeFlower;


    private void Update()
    {
        CheckFlowerScore();
    }

    void CheckFlowerScore()
    {

        if (FlowerInteraction.Instance.orangeFlowerHit == true)
        {
            Debug.Log("hello");
            flowerObject1.SetActive(true);
        }

        if (FlowerInteraction.Instance.orangeFlowerHit == true)
        {
            Debug.Log("hello");
            flowerObject1.SetActive(true);
        } 
        
        if (FlowerInteraction.Instance.orangeFlowerHit == true)
        {
            Debug.Log("hello");
            flowerObject1.SetActive(true);
        }  
        
        if (FlowerInteraction.Instance.orangeFlowerHit == true)
        {
            Debug.Log("hello");
            flowerObject1.SetActive(true);
        }

        //if ( Player.Instance.score == secondGoal)
        //{
        //    flowerObject2.SetActive(true);
        //}

        //if (Player.Instance.score == thirdGoal)
        //{
        //    flowerObject2.SetActive(true);
        //}

        //if (Player.Instance.score == fourthGoal)
        //{
        //    flowerObject4.SetActive(true);
        //}
    }

}
