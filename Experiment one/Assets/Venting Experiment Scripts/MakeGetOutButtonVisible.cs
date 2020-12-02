using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGetOutButtonVisible : MonoBehaviour
{
      
    [SerializeField] private GameObject getOutButton,player;


    void OnEnable() 
    {
        PlayerVent.OnPlayerVentEvent += MakeVisible;
    }

    void OnDisable() 
    {
        PlayerVent.OnPlayerVentEvent -= MakeVisible;
    }

    void MakeVisible()
    {
        getOutButton.SetActive(true);
    }

    void Update()
    {
        if(player.activeSelf == true)
          getOutButton.SetActive(false);
    }
}
