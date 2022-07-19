using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    [SerializeField] float cameraSpeed;
    [SerializeField] Vector3 offset;



    private void LateUpdate()
    {
        Vector3 carPos = car.transform.position+offset;
        Vector3 camPOS = transform.position;

        transform.position = Vector3.Lerp(camPOS, carPos, cameraSpeed);
        
    }
}
