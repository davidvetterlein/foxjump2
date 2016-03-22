using UnityEngine;
using System.Collections;

public class destroying : MonoBehaviour {
    ParticleSystem Par;
    GameObject Player;

	// Use this for initialization
	void Start () {
        Par = gameObject.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(Par.time >= 0.5)
        {
            gameObject.GetComponent<destroying>().enabled = false;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.transform.position.y <= transform.position.y)
        {
            Player = col.gameObject;
            Par.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player.GetComponent<steuerung>().Xp += PlayerPrefs.GetInt("XpPerBlock");
        }
    }
}
