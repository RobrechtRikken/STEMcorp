using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCenterMass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody> ().centerOfMass = Vector3.zero;
	}
}
