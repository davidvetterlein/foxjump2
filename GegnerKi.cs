using UnityEngine;
using System.Collections;

public class GegnerKi : MonoBehaviour {
	public Vector2 Point1;
	public Vector2 Point2;
	public float speed;
	int jump = 50;
	public int newJump = 50;
	public float up;
	bool zupunkt1 = false;
	public int wahrscheinlichkeit = 0;
	bool grounded = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int rand;
		rand = Random.Range(0,1000);
		if(rand >= wahrscheinlichkeit && grounded == true){
			jump = newJump;
		}
		if(jump > 0){
			jump -= 1;
			gameObject.GetComponent<Rigidbody2D>().Sleep();
			gameObject.transform.position += new Vector3 (0, up, 0);
		}else{
			gameObject.GetComponent<Rigidbody2D>().WakeUp();
		}
		
		float step = speed * Time.deltaTime;
		if(zupunkt1 == true){
			transform.MoveTowards(gameObject.transform.position, Point1, step);
		}else{
			transform.MoveTowards(gameObject.transform.position, Point2, step);
		}
		if(gameObject.transform.position == Point1){
			zupunkt1 = false;
		}
		if(gameObject.transform.position == Point2){
			zupunkt1 = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		grounded = true;
	}
}
