using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
public class EnterCar : MonoBehaviour
{
    public GameObject teleport;
    public GameObject freeplayer;


    public RuleScript Rulecontr;


    [Space]
    public Transform player_PosIncar;
    public Transform player_PosOutCar;

    void Start()
    {
        
    }

    public void leaveCar()
    {

        print("Leave");

        teleport.SetActive(true);

        freeplayer.transform.parent = null;
        freeplayer.transform.position = player_PosOutCar.position;
        freeplayer.transform.eulerAngles = Vector3.zero;


        Rulecontr.playerInCar = false;
    }

    public void SitDownCar()
    {

        print("Sit");

        teleport.SetActive(false);
        freeplayer.transform.parent = player_PosIncar;
        freeplayer.transform.localPosition = Vector3.zero;

        Rulecontr.playerInCar = true;
    }
}
