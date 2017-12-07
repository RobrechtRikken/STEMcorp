using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MakeParent : MonoBehaviour {
	protected Transform originalParent;
	public GameObject playArea;
	protected bool stay;
	protected bool isColliding;
	public GameObject cameraRig;
	public GameObject ferrisChecker;

	// Use ² for initialization
	void Start () {
		originalParent = cameraRig.transform.parent;
		stay = false;
		isColliding = false;
	}

	// Update is called once per frame
	/*void FixedUpdate () {
		if (stay) {
			isColliding = true;
			stay = false;
		} else {
			isColliding = false; //put in ienumerator and check less often?
			CollisionExit ();
		}
	}*/

	//void OnTriggerEnter(Collider other)
	void OnCollisionEnter(Collision other)
	{
		//if (other.gameObject == ferrisChecker) //makes the camera child of ferrisride
	//	{
			cameraRig.transform.SetParent(this.transform);
		playArea.GetComponent<VRTK_BodyPhysics> ().enabled = false;
			Debug.Log(other.gameObject.name);
		//}
	}

	/*void OnTriggerStay(Collider other)
	{
		//if (other.gameObject.layer == 8) {
			stay = true;
		//}
	}*/

	//private void OnTriggerExit(Collider other)
	void OnCollisionExit(Collision other)
	{
		Debug.Log ("Exited from:" + other.gameObject.name);

		//if (other.gameObject == ferrisChecker)
		//{
			//this.gameObject.transform.SetParent(originalParent);
			cameraRig.transform.SetParent(originalParent);
		playArea.GetComponent<VRTK_BodyPhysics> ().enabled = true;
			Debug.Log ("This does happen!");

			//joint = null;
		//}
		cameraRig.transform.eulerAngles = new Vector3(0, cameraRig.transform.eulerAngles.y, 0);
	}

	/*protected void CollisionExit()
	{
		cameraRig.transform.SetParent(originalParent);
		playArea.GetComponent<VRTK_BodyPhysics> ().enabled = true;
		cameraRig.transform.eulerAngles = new Vector3(0, cameraRig.transform.eulerAngles.y, 0);
	}*/

}
