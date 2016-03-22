using UnityEngine;
using System.Collections;

public class Seilbahn : MonoBehaviour {
	public Transform[] Positionen;
	public Transform Current;
	public GameObject SeilBahn;
	int currentint = 0;
	public float speed;
	bool ruckwarts = false;

	// Use this for initialization
	void Start () {
		Current = Positionen [0];
	}
	
	// Update is called once per frame
	void Update () {
		SeilBahn.transform.position = Vector3.MoveTowards (SeilBahn.transform.position, Current.position, speed);
		if (SeilBahn.transform.position == Current.position) {
			if (ruckwarts == false) {
				currentint += 1;
				if (currentint >= Positionen.Length) {
					ruckwarts = true;
                    currentint -= 1;
                }
				Current = Positionen [currentint];
			} else {
				currentint -= 1;
				if (currentint < 0) {
					ruckwarts = false;
                    currentint += 1;
                }
				Current = Positionen [currentint];
			}
		}
	}

}
