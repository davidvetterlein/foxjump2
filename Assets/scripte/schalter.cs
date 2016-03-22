using UnityEngine;
using System.Collections;

public class schalter : MonoBehaviour {
	public GameObject Mauer;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D col){
		Mauer.SetActive(false);

	}
}
