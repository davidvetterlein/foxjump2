using UnityEngine;
using System.Collections;

public class jumper : MonoBehaviour {

	public float speed;
	public Transform Pos;
	public int time;
	public int newtime;
	GameObject Player;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time -= 1;
			Player.GetComponent<Rigidbody2D>().Sleep();
			Player.transform.position += new Vector3 (0, speed, 0);
		} else {
			Player.GetComponent<Rigidbody2D>().WakeUp();
		}
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Player") {
			time = newtime;
		}
	}

}
