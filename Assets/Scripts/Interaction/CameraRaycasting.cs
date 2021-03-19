using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    [SerializeField] private float range;
    private IInteractable currentTarget;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastForInteractable();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }

    }

    private void RaycastForInteractable()
    {
        RaycastHit whatIHit;

        //raycast from camera to point 
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(ray.origin, ray.direction * 5f);
        //Change this if possible
        if(Physics.Raycast(ray, out whatIHit, range))
        {
            IInteractable interactable = whatIHit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(whatIHit.distance <= interactable.MaxRange)
                {
                    if(interactable == currentTarget)
                    {
                        return;
                    } 
                    else if( currentTarget != null)
                    {
                            currentTarget.OnEndHover();
                            currentTarget = interactable;
                            currentTarget.OnStartHover();
                            return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }

                    
                }
                else
                {
                    if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = null;
                        return;
                    }
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnEndHover();
                    currentTarget = null;
                    return;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnEndHover();
                currentTarget = null;
                return;
            }
        }
    }
}
