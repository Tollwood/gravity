using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public bool isActive = false;
    public float gravity = -2;
    private Transform centerOfGravity;
    public Vector3 startPosition { get; private set; }
    public float rotationSpeed = 0.1f;

    private void Awake()
    {
        centerOfGravity =  transform.Find("CenterOfGravity");
        startPosition = transform.Find("StartPosition").position;
    }

    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }

    public void Attract(Rigidbody body)
    {
        if(isActive){
            //Debug.Log(name + "isActive");
            Vector3 gravityUp = (body.position - centerOfGravity.position).normalized;
            Vector3 localUp = body.transform.up;
            float distance = Vector3.Distance(body.position, centerOfGravity.position);
            // Apply downwards gravity to body
            Vector3 force = gravityUp * gravity;
            body.AddForce(force);
            //(Mathf.Clamp(threshold - distance, 0, threshold) )
            // Allign bodies up axis with the centre of planet
            body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
        }
    }

    public void onPlanetEnter(Collider other)
    {
        if (other.tag == "Player"){
            Debug.Log(transform.name + " entered");
            isActive = true;
            other.transform.parent = transform;    
        }

    }

    public void onPlanetExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(transform.name + " leaving");
            isActive = false;
            other.transform.parent = null;
        }
    }


}