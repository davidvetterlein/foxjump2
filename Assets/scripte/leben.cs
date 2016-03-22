using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class leben : MonoBehaviour {
	public int life;
	public Text lebensanzeige;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lebensanzeige.text = life.ToString();
		if (life == 0){
			Application.LoadLevel(0);
		}
	}
}
