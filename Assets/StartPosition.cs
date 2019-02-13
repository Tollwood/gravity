using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {
    
    public Planet startPlanet;


	void Start () {
        transform.position = startPlanet.startPosition;
        transform.parent = startPlanet.transform;
	}
	
}
