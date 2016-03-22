using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Networkdead : NetworkBehaviour {

    [SyncVar]
    public bool dead = false;

    public Vector3 Spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(dead == true)
        {
            StartCoroutine(Example());
            Cmdtot(false);
        }
	}

    IEnumerator Example()
    {
        gameObject.GetComponent<steuerungmutli>().enabled = false;
        gameObject.GetComponent<NetworkPlayer>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.transform.position = Spawn;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<NetworkPlayer>().enabled = true;
        gameObject.GetComponent<steuerungmutli>().enabled = true;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "tot" && isLocalPlayer)
        {
            Cmdtot(true);
        }
    }

    [Command]
    private void Cmdtot(bool tdead)
    {
        dead = tdead;
    }

}
