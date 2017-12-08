using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class BecomeChild : MonoBehaviour {
    protected Transform originalParent;
	public GameObject playArea;
    //protected FixedJoint joint;
	protected bool stay;
	protected bool isColliding;
	public GameObject cameraRig;

	protected bool stayChild;

	// Use ² for initialization
	void Start () {
		originalParent = cameraRig.transform.parent;
		stay = false;
		isColliding = false;
		stayChild = false;
	}

	/*void FixedUpdate()
	{
		if (stayChild) {
			isColliding = true;
			stayChild = false;
		} else {
			isColliding = false;
		}

		if (!isColliding) {
			CollisionExit ();
		}
	}*/

	// Update is called once per frame
	/*void FixedUpdate () {
		if (stay) {
			isColliding = true;
			stay = false;
		} else {
			isColliding = false;
			CollisionExit ();
		}
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8) //makes the camera child of ferrisride
        {
			cameraRig.transform.SetParent(other.transform);
			playArea.GetComponent<VRTK_BodyPhysics> ().enabled = false;
            Debug.Log(other.gameObject.name);
        }
    }

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 8) {
			stay = true;
		}
	}

    private void OnTriggerExit(Collider other)
    {
		Debug.Log ("Exited from:" + other.name);

        if (other.gameObject.layer == 8)
        {
            //this.gameObject.transform.SetParent(originalParent);
			cameraRig.transform.SetParent(originalParent);
			playArea.GetComponent<VRTK_BodyPhysics> ().enabled = true;
			Debug.Log ("This does happen!");

            //joint = null;
        }
        cameraRig.transform.eulerAngles = new Vector3(0, cameraRig.transform.eulerAngles.y, 0);
    }*/

	protected void CollisionExit()
	{
		cameraRig.transform.SetParent(originalParent);
		playArea.GetComponent<VRTK_BodyPhysics> ().enabled = true;
		cameraRig.transform.eulerAngles = new Vector3(0, cameraRig.transform.eulerAngles.y, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("This happens triggerenter");
		cameraRig.transform.SetParent(other.transform);
		playArea.GetComponent<VRTK_BodyPhysics> ().enabled = false;
		Debug.Log(other.gameObject.name);
	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("This happens " + other.name);
		CollisionExit ();
	}
}
