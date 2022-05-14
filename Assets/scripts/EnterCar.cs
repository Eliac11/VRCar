using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
public class EnterCar : MonoBehaviour
{
    public GameObject playerinCar;
    public GameObject teleport;
    public GameObject freeplayer;


    public RuleScript Rulecontr;

    void Start()
    {
        
    }

    public void leaveCar()
    {
        playerinCar.SetActive(false);

        teleport.SetActive(true);
        freeplayer.SetActive(true);

        Rulecontr.playerInCar = false;
    }

    public void SitDownCar()
    {
        playerinCar.SetActive(true);

        teleport.SetActive(false);
        freeplayer.SetActive(false);

        Rulecontr.playerInCar = true;
    }
}
