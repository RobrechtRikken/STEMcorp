using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeChild : MonoBehaviour {
    protected int FERRISLAYER = 8;
    protected Transform originalParent;
    //protected FixedJoint joint;

	// Use this for initialization
	void Start () {
        originalParent = this.gameObject.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) //makes the camera child of ferrisride
        {
            //joint = this.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;

            //joint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            this.gameObject.transform.SetParent(other.transform);
            Debug.Log(other.gameObject.name);
            //joint.breakForce = 50;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //this.gameObject.transform.SetParent(originalParent);
            this.gameObject.transform.SetParent(originalParent);

            //joint = null;
        }
        this.gameObject.transform.eulerAngles = new Vector3(0, this.gameObject.transform.eulerAngles.y, 0);
    }
}
