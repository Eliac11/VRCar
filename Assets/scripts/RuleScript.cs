using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
public class RuleScript : MonoBehaviour
{
    public Car_Controller Carcontr;

    public CircularDrive drive;
    public Transform RuleBody;


    public SteamVR_Action_Boolean GazPress = null;
    public SteamVR_Action_Boolean GazBackPress = null;

    public bool playerInCar = false;


    // Update is called once per frame
    public void HandHoverUpdate(Hand hand)
    {
        
        Carcontr.Set_WheelsAngle(Mathf.Clamp( drive.outAngle/450,-1,1));

        RuleBody.localEulerAngles = new Vector3(RuleBody.localEulerAngles.x, 0, drive.outAngle);

    }

    public void Update()
    {
        if (playerInCar)
        {
            if (GazPress.GetState(SteamVR_Input_Sources.Any))
            {

                foreach (WheelCollider Wheel in Carcontr.Back_Wheels)
                {
                    Wheel.motorTorque = -0.2f * ((Carcontr.Motor_Torque * 5) / (Carcontr.Back_Wheels.Count + Carcontr.Front_Wheels.Count));

                }
            }
            else if (GazBackPress.GetState(SteamVR_Input_Sources.Any))
            {
                foreach (WheelCollider Wheel in Carcontr.Back_Wheels)
                {
                    Wheel.motorTorque = 0.2f * ((Carcontr.Motor_Torque * 5) / (Carcontr.Back_Wheels.Count + Carcontr.Front_Wheels.Count));

                }
            }
            else
            {
                foreach (WheelCollider Wheel in Carcontr.Back_Wheels)
                {
                    Wheel.motorTorque = 0;

                }
            }

        }
    }
}
