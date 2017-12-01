using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {
    public float RotateEveryUpdate;

    private void FixedUpdate()
    {
        this.gameObject.transform.eulerAngles += new Vector3(0, RotateEveryUpdate, 0);
    }
}
