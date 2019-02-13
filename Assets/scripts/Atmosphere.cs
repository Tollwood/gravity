using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{
    Planet planet;

    private void Start()
    {
        planet = transform.parent.GetComponent<Planet>();
    }

    private void OnTriggerEnter(Collider other)
    {
        planet.onPlanetEnter(other);

    }

    private void OnTriggerExit(Collider other)
    {
        planet.onPlanetExit(other);
       
    }
}
