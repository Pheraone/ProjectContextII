using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Player>();

            return instance;
        }
    }

    public float forwardSpeed = 25f;
    public float strafeSpeed = 7.5f;
    public float hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRotateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    public int score = 0;
    public int maxScore = 5;


    //private float rollInput;
    //public float rollSpeed = 90f, rollAcceleration = 3.5f;

    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMouse();
        Move();
        //Win();
    }

    void Move()
    {
        //TODO: not turn as much when not flying -> clamp?
        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, 0, 0f, Space.Self);
        transform.Rotate(0, mouseDistance.x * lookRotateSpeed * Time.deltaTime, 0, Space.World);


        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;
    }

    void CalculateMouse()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        //calculate mouse distance
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
    }

    void CalculateScore()
    {
        score++;
        Debug.Log(score);
    }

    //For testing!
    //void Win()
    //{
    //    //score == maxScore
    //    if (score == maxScore)
    //    {
    //        GameManager.Instance.fsm.GotoState(GameStateType.Win);
    //    }
    //}
}
