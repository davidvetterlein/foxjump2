using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D ()
    {
        Application.LoadLevel(1);
    }

    public void Next ()
    {
        Application.LoadLevel(1);
    }
}
