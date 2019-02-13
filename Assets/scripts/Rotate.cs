using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotationSpeed = 0.1f;
	
	// Update is called once per frame
	void FixedUpdate () {

        this.transform.Rotate(new Vector3(0, rotationSpeed, 0));
	}
}
