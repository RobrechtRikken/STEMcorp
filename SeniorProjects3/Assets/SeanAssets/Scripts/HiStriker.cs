using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiStriker : MonoBehaviour {
  
  private Rigidbody rb;
  public GameObject weight;
  private Vector3 rbForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnCollisionEnter (Collision col)
  {
    if (col.gameObject.name == "Hammer")
    {
			rb = col.gameObject.GetComponent<Rigidbody>();
			weight.GetComponent<Rigidbody>().AddForce(new Vector3(0, rb.velocity.y,0));
    }
  }
}
