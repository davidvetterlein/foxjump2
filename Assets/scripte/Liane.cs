using UnityEngine;
using System.Collections;

public class Liane : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<HingeJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
