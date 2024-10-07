using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPSCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFov = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f; 
    [SerializeField] FirstPersonController fpsController;

    bool zoomedInToogle = false;

    private void OnDisable()
    {
        ZoomOut();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToogle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToogle = true;
        FPSCamera.fieldOfView = zoomedInFov;

    }

    private void ZoomOut()
    {
        zoomedInToogle = false;
        FPSCamera.fieldOfView = zoomedOutFOV;
    }

}
