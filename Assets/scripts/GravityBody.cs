using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{

    List<Planet> planets;
    Rigidbody rb;

    void Awake()
    {
        planets = new List<Planet>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Planet"))
        {
            Planet planet = go.GetComponent<Planet>();
            planets.Add(planet);
        }
                            
        rb = GetComponent<Rigidbody>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        foreach (Planet planet in planets)
        {
            // Allow this body to be influenced by planet's gravity
            planet.Attract(rb);
        }
    }
}