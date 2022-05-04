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


    // Update is called once per frame
    public void HandHoverUpdate(Hand hand)
    {
        
        Carcontr.Set_WheelsAngle(Mathf.Clamp( drive.outAngle/45,-1,1));

        RuleBody.eulerAngles = new Vector3(RuleBody.eulerAngles.x, 0, drive.outAngle);

    }

    public void Update()
    {
        if (GazPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            foreach (WheelCollider Wheel in Carcontr.Back_Wheels)
            {
                Wheel.motorTorque = 0.2f * ((Carcontr.Motor_Torque * 5) / (Carcontr.Back_Wheels.Count + Carcontr.Front_Wheels.Count));

            }
        }
        if (GazBackPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            foreach (WheelCollider Wheel in Carcontr.Back_Wheels)
            {
                Wheel.motorTorque = -1 * ((Carcontr.Motor_Torque * 5) / (Carcontr.Back_Wheels.Count + Carcontr.Front_Wheels.Count));

            }
        }
    }
}
