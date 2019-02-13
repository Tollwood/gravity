using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float yFactor = .3f;
    public float zFactor = .2f;
    public float rotationFactor = 2;
    public float mouseSensitivityY = 1;
    public float minY = .17f;
    public float maxY = 26f;
	

    float verticalLookRotation;
    bool firstPerson = false;
    Transform ct;

    private void Start()
    {
        ct = Camera.main.transform;
        ct.localEulerAngles = new Vector3(22, 0, 0);
    }

    // Update is called once per frame
    public void Update () {
        if(Input.GetKeyDown(KeyCode.F)){
            ct.localPosition = new Vector3(0, minY, 0);
            firstPerson = true;
        }
        HandleZoom();
        HandleLookUpDown();

	}

    private void HandleZoom()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if((zoom > 0 || zoom < 0) && firstPerson){
            firstPerson = false;
            ct.localPosition= new Vector3(0, minY, -.3f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !(ct.localPosition.y - yFactor <= minY))
        {
            ct.localPosition = new Vector3(ct.localPosition.x, ct.localPosition.y - yFactor, ct.localPosition.z + zFactor);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !(ct.localPosition.y - yFactor >= maxY))
        {
            ct.localPosition = new Vector3(ct.localPosition.x, ct.localPosition.y + yFactor, ct.localPosition.z - zFactor);
        }
    }

    private void HandleLookUpDown()
    {
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 90);
        ct.localEulerAngles = Vector3.left * verticalLookRotation;
    }
}
