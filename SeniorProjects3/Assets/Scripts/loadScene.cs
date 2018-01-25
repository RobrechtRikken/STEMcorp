using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {
	public string sceneToLoadpublic;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene (sceneToLoadpublic, LoadSceneMode.Single);
	}
}
