using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeChild : MonoBehaviour {
    protected int FERRISLAYER = 8;
    protected Transform originalParent;

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
            this.gameObject.transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            this.gameObject.transform.SetParent(originalParent);
        }
    }
}
