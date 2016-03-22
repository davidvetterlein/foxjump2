using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Editorscript : MonoBehaviour {
    //public Vector3 poss;
    public float y;
    public float x;
	public float z;
    void Update () {
        //transform.position = poss;
        x = transform.position.x;
        y = transform.position.y;
		z = transform.position.z;

        x = Mathf.Round(x);
        y = Mathf.Round(y);
		z = Mathf.Round(z);

        gameObject.transform.position = new Vector3(x, y, z);
    }
}
