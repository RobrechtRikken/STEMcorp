using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour {
    public GameObject itemToRotate;
    public Vector3 rotationAmount;
    protected Vector3 rotation;

    private void Start()
    {
        rotation = itemToRotate.transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate () {
        rotation += rotationAmount;
        //itemToRotate.GetComponent<Rigidbody>().AddTorque(rotationAmount);
        itemToRotate.transform.eulerAngles = rotation;
	}
}
