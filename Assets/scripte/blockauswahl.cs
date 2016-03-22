using UnityEngine;
using System.Collections;

public class blockauswahl : MonoBehaviour {
    public GameObject Block;
    public GameObject Lastblock;
    public Material Auswahlmat;
    public Material Dirt;
    public Material Lastmat;
    public float max;
    public float distance;
    bool enable = false;
    public string last = "null";
    public Material Caller;
    // Use this for initialization
    void Start()
    {
        Block = gameObject.GetComponent<TheHook>().nuller;
    }

	public void End () {
        Block.GetComponent<MeshRenderer>().material = Lastmat;
        last = "links";
        enable = false;
        gameObject.GetComponent<steuerung>().enabled = true;
        Block = gameObject.GetComponent<TheHook>().nuller;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(enable == true)
        {
            GameObject cam = Camera.main.gameObject;
            cam.transform.position = new Vector3(gameObject.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
        if (Input.GetKeyDown("m") && enable == false)
        {
            CallHook();
            enable = true;
            gameObject.GetComponent<steuerung>().enabled = false;
        } else if(Input.GetKeyUp("m") && enable == true)
        {
            gameObject.GetComponent<TheHook>().UndoCall();
            gameObject.GetComponent<TheHook>().CallHook();
            End();
        }
        if (Input.GetKeyDown("right") && enable == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Block.transform.position.x +0.6f , Block.transform.position.y), Vector2.right);
            distance = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(Block.transform.position.x, 0));
            if (hit.collider != null && distance <= max || last == "links")
            {
                if (Block != GameObject.Find("Null"))
                {
                    Block.GetComponent<MeshRenderer>().material = Lastmat;
                }
                Lastmat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                Block = hit.collider.gameObject;
                last = "rechts";
                Block.GetComponent<MeshRenderer>().material = Auswahlmat;
            }
        }
        if (Input.GetKeyDown("left") && enable == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Block.transform.position.x - 0.6f, Block.transform.position.y), Vector2.left);
            distance = Vector2.Distance(new Vector2(transform.position.x,0), new Vector2(Block.transform.position.x,0));
            if (hit.collider != null && distance <= max || last == "rechts")
            {
                if (Block != GameObject.Find("Null"))
                {
                    Block.GetComponent<MeshRenderer>().material = Lastmat;
                }
                Lastmat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                Block = hit.collider.gameObject;
                Block.GetComponent<MeshRenderer>().material = Auswahlmat;
                last = "links";
            }
        }
    }

    public void CallHook()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), Vector2.up);
        if (hit.collider != null)
        {
            if (Block != GameObject.Find("Null"))
            {
                Block.GetComponent<MeshRenderer>().material = Lastmat;
            }
            Lastmat = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
            Block = hit.collider.gameObject;
            Block.GetComponent<MeshRenderer>().material = Auswahlmat;
        }
    }

}
