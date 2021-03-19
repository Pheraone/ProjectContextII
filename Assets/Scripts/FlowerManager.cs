using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
   public  GameObject flowerObject1;

    public GameObject flowerObject2;
    public GameObject flowerObject3;
    public GameObject flowerObject4;

    private void Update()
    {
        CheckFlowerScore();
    }

    void CheckFlowerScore()
    {
        if( Player.Instance.score == 2)
        {
            flowerObject1.SetActive(true);
        } 

        if( Player.Instance.score == 4)
        {
            flowerObject2.SetActive(true);
        }


        if (Player.Instance.score == 6)
        {
            flowerObject2.SetActive(true);
        }


        if (Player.Instance.score == 8)
        {
            flowerObject4.SetActive(true);
        }
    }
}
