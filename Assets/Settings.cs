using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
    public int XpPerBlock;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("XpPerBlock", XpPerBlock);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
