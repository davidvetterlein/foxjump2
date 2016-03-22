using UnityEngine;
using System.Collections;

public class GegnerKi : MonoBehaviour {
	public Vector3 Point1;
	public Vector3 Point2;
	public float speed;
	int jump = 50;
	public int newJump = 50;
	public float up;
	public bool zupunkt1 = false;
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
            transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(Point1.x, transform.position.y, transform.position.z), step);
        }
        else{
            transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3 (Point2.x, transform.position.y, transform.position.z), step);
		}
		if(gameObject.transform.position == new Vector3(Point1.x, transform.position.y, transform.position.z))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            zupunkt1 = false;
		}
		if(gameObject.transform.position == new Vector3(Point2.x, transform.position.y, transform.position.z))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            zupunkt1 = true;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		grounded = true;
	}
}
