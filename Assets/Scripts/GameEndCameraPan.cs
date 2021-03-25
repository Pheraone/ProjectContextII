using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCameraPan : MonoBehaviour
{

    public GameObject[] panningLoc;
    public float[] timings;
    public bool GameEndCameraOn = false;

    private float lerpLoc;
    private int currentPanLoc = 0;
    private int currenTimingLoc = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEndCameraOn)
        {
            transform.position = Vector3.Lerp(panningLoc[currentPanLoc].transform.position, panningLoc[currentPanLoc + 1].transform.position, lerpLoc);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(panningLoc[currentPanLoc].transform.rotation.eulerAngles, panningLoc[currentPanLoc + 1].transform.rotation.eulerAngles, lerpLoc));
            lerpLoc += Time.deltaTime / timings[currenTimingLoc];
            if (lerpLoc > 1)
            {
                lerpLoc = 0;
                currenTimingLoc++;
                currentPanLoc += 2;
                if (currentPanLoc > panningLoc.Length - 1)
                {
                    currentPanLoc = 0;
                    currenTimingLoc = 0;
                }
            }
        }
    }
}
