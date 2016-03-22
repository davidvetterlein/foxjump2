using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class schaltermultiplayer : NetworkBehaviour {
    public GameObject[] Mauer;
    public int Schalteranz = 1;
    public int Schalter = 0;
    public int Mauerr;

    public void Start()
    {
        Mauerr = Schalteranz;

    }
    void Update()
    {
        if (Mauerr >= 0)
        {
            Mauer[Mauerr] = GameObject.Find("Mauer" +Mauerr);
            Mauerr -= 1;
        }
        if (active == false)
        {
            Mauer[CSchalter].SetActive(false);
        }
    }
    [SyncVar(hook = "OnActiveChange")]
    public bool active = true;

    [SyncVar]
    public int CSchalter = 0;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "knopf")
        {
            
            CmdDisable(Schalter = int.Parse(other.gameObject.name));
        }
    }

    [Command]
    private void CmdDisable(int schalter)
    {
        active = false;
        CSchalter = schalter;
    }

    private void OnActiveChange(bool updatedActive)
    {
        active = updatedActive;
        Debug.Log("Active changed on client!");
    }
}
