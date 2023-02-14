using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingChecker : MonoBehaviour
{
    BuildingManager _buildingManager;

    void Awake()
    {
        _buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("NotPlacing")){
            
            _buildingManager.isPlacable = false;
        }else{
            _buildingManager.isPlacable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("NotPlacing")){
            Debug.Log("Can place");
            _buildingManager.isPlacable = true;
        }
    }
}
