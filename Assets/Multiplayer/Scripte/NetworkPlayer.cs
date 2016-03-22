using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayer : NetworkBehaviour {
    public float Lerpi;
    public GameObject player;

    [SyncVar]
    private Vector2 syncPosition;

    private Rigidbody2D rigidbody2d;

	void Start () {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        if (isLocalPlayer)
        {
            gameObject.GetComponent<steuerungmutli>().enabled = true;
            gameObject.GetComponent<steuerungmutli>().cam = Camera.main.gameObject;
            gameObject.GetComponent<Hookmulti>().enabled = true;
        }
        else
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (isLocalPlayer)
        {
            CmdSendData(this.transform.position);
        }
        else
        {
            Interpolate();
        }
	}

    private void Interpolate ()
    {
        Vector2 newpos = Vector2.Lerp(this.transform.position, syncPosition, Time.deltaTime * Lerpi);
        rigidbody2d.MovePosition(newpos);
    }

    [Command]
    private void CmdSendData(Vector2 pos)
    {
        syncPosition = pos;
    }
}
