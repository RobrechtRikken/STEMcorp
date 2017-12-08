using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
	public ShootingRangeManager theManager;
	public float rotationAmount = 90f;
	public bool shotDown = false;
	public float coolDown = 5f;
	private float coolDownValue;
	// Use this for initialization
	void Start () {
		coolDownValue = coolDown;
	}
	
	// Update is called once per frame
	void Update () {
		if (shotDown) 
		{
			coolDown -= Time.deltaTime;
			if(coolDown <= 0f)
			{
				shotDown = false;
				coolDown = coolDownValue;
				this.transform.parent.eulerAngles = new Vector3 (this.transform.parent.eulerAngles.x + rotationAmount, this.transform.parent.eulerAngles.y, this.transform.parent.eulerAngles.z);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!shotDown) 
		{
			Debug.Log (other + " triggered me");
			this.transform.parent.eulerAngles = new Vector3 (this.transform.parent.eulerAngles.x + rotationAmount, this.transform.parent.eulerAngles.y, this.transform.parent.eulerAngles.z);
			shotDown = true;
			theManager.TargetIsHit ();
		}
	}
}
