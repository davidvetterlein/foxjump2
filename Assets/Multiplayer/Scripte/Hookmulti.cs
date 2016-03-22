using UnityEngine;
using System.Collections;

public class Hookmulti : MonoBehaviour
{
    public bool called = false;
    public float distance;
    public Vector3 grabpos;
    public int lengthOfLineRenderer = 2;
    public bool callable = true;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<DistanceJoint2D>().distance = distance;
        if (called == false)
        {
            GetComponent<LineRenderer>().enabled = true;
            Vector3[] points = new Vector3[lengthOfLineRenderer];
            points[1] = gameObject.transform.position;
            points[0] = grabpos;
            GetComponent<LineRenderer>().SetPositions(points);
        }
        else {
            GetComponent<LineRenderer>().enabled = false;
        }

        if (Input.GetKey("up"))
        {
            distance -= 0.05f;
        }

        if (Input.GetKey("down"))
        {
            distance += 0.05f;
        }
        if (Input.GetKeyDown("m"))
        {
            if (called == true && callable == true)
            {
                called = false;
                CallHook();
            }
            else
            {
                called = true;
                UndoCall();
            }
        }
    }

    public void CallHook()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), Vector2.up);
        if (hit.collider != null && callable == true && hit.collider.tag != "uncall")
        {
            gameObject.GetComponent<DistanceJoint2D>().enabled = true;
            gameObject.GetComponent<DistanceJoint2D>().connectedAnchor = hit.collider.transform.position;
            grabpos = hit.collider.transform.position;
            distance = Vector3.Distance(transform.position, grabpos);
            distance -= 0.5f;
        } else if (hit.collider.tag == "uncall") {
            called = true;
        }
        callable = false;
    }

    public void UndoCall()
    {
        gameObject.GetComponent<DistanceJoint2D>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        callable = true;
        if (called == false)
        {
            UndoCall();
            called = true;
        }
    }
}
