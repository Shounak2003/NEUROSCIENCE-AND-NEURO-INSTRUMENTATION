using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{


    public GameObject Object;

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        Object.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Object.SetActive(false);
  }

}
