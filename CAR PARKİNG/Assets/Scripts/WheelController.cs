using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    [SerializeField] Transform frontRightTrans;
    [SerializeField] Transform frontLeftTrans;
    [SerializeField] Transform rearRightTrans;
    [SerializeField] Transform rearLeftTrans;
   


    public float acceleration = 500f;
    public float breakForce = 300f;
    public float maxTurn = 15f;

    private float currentAcceleration = 0;
    private float currentBreakForce = 0;
    private float currentturn = 0;


    private void FixedUpdate()
    {
        //Forward and backward movement
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        //braking
        if(Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakForce;
        }
        else
        {
            currentBreakForce = 0;
        }
        //apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        //turning
        currentturn = maxTurn * Input.GetAxis("Horizontal");
        frontRight.steerAngle = currentturn;
        frontLeft.steerAngle = currentturn;

        //turn wheel meshes
        frontLeftTrans.Rotate(0,0, frontLeft.rpm / 60 * -360 * Time.deltaTime);
        frontRightTrans.Rotate(0 ,0,frontRight.rpm / 60 * 360 * Time.deltaTime);
        rearLeftTrans.Rotate(0, 0, rearLeft.rpm / 60 * -360 * Time.deltaTime);
        rearRightTrans.Rotate(0, 0, rearRight.rpm / 60 * 360 * Time.deltaTime);


    }
    
    
    
}
