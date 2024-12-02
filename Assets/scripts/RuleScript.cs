using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
public class RuleScript : MonoBehaviour
{
    public Car_Controller Carcontr;

    public LinearMapping drive;
    public Transform RuleBody;


    public SteamVR_Action_Boolean GazPress = null;
    public SteamVR_Action_Boolean GazBackPress = null;

    public bool playerInCar = false;
    public float d = 0.5f;


    // Update is called once per frame
    public void Update()
    {
        if (playerInCar)
        {
            Carcontr.Set_WheelsAngle((drive.value - d) * 2f);

            RuleBody.localEulerAngles = new Vector3(RuleBody.localEulerAngles.x, 0, (drive.value - d) * 2f * 420);

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
