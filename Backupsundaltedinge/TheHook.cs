using UnityEngine;
using System.Collections;

public class TheHook : MonoBehaviour {
    public bool called = false;
	public float distance;
	public Vector3 grabpos;
	public int lengthOfLineRenderer = 2;
	public bool callable = true;
    public GameObject nuller;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.GetComponent<DistanceJoint2D>().distance = distance;
		if(called == false){
			GetComponent<LineRenderer>().enabled = true;
			Vector3[] points = new Vector3[lengthOfLineRenderer];	
			points[1] = gameObject.transform.position;
			points[0] = grabpos;
			GetComponent<LineRenderer>().SetPositions(points);
		}else if(called == true){
			GetComponent<LineRenderer>().enabled = false;
		}
		
		if(Input.GetKey("up")){
			distance -= 0.05f;
		}
		
		if(Input.GetKey("down")){
			distance += 0.05f;
		}
        if(Input.GetKeyDown("n")){
            {
                UndoCall();
            }
        }
    }

    public void CallHook()
    {
        if (gameObject.GetComponent<blockauswahl>().Block != nuller && gameObject.GetComponent<blockauswahl>().Block.tag == "callable")
        {
            called = false;
            GameObject Block;
            gameObject.GetComponent<DistanceJoint2D>().enabled = true;
            Block = gameObject.GetComponent<blockauswahl>().Block;
            grabpos = Block.transform.position;
            gameObject.GetComponent<DistanceJoint2D>().connectedAnchor = Block.transform.position;
            distance = Vector3.Distance(transform.position, grabpos);
            distance -= 0.2f;
            //callable = false;
            gameObject.GetComponent<blockauswahl>().End();
        }
    }

    public void UndoCall()
    {
        called = true;
        gameObject.GetComponent<DistanceJoint2D>().enabled = false;
    }
	
	/*void OnCollisionEnter2D(Collision2D col){
		callable = true;
		if(called == false){
			UndoCall();
			called = true;
		}
	}*/
}
