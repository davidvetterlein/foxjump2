using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skillsystem : MonoBehaviour {
	public float[] SpeedLevel;
	public int Levelspeed;

	public int[] JumpLevel;
	public int Jumplength;

	public int herzenanz;
	public GameObject[] Herzen;

    public Slider Xpslider;
    public int Xp;
    public int Punkte;
    public Text Punktetxt;

    public GameObject skillsystem;
    public GameObject IngameButtons;

    public Text JumpLv;
    public Text SpeedLv;
	public Text Herzenlv;


    // Use this for initialization
    void Start () {
		herzenanz = PlayerPrefs.GetInt ("herzen");
		gameObject.GetComponent<steuerung> ().leben = 3 + herzenanz;
		Levelspeed = PlayerPrefs.GetInt ("Levelspeed");
		Jumplength = PlayerPrefs.GetInt ("JumpLength");
        Punkte = PlayerPrefs.GetInt("Punkte");

		if (herzenanz == 1) {
			Herzen [1].SetActive (true);
		}
		if (herzenanz == 2) {
			Herzen [1].SetActive (true);
			Herzen [0].SetActive (true);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
        Punktetxt.text = Punkte.ToString();
        Xp = gameObject.GetComponent<steuerung>().Xp;
        Xpslider.value = Xp;
        if(Xp >= 100)
        {
            Punkte += 1;
            gameObject.GetComponent<steuerung>().Xp = 0;
        }

		gameObject.GetComponent<steuerung> ().newjump = JumpLevel [Jumplength];
        gameObject.GetComponent<steuerung>().speed = SpeedLevel[Levelspeed];

        JumpLv.text = JumpLevel[Jumplength].ToString();
        SpeedLv.text = SpeedLevel[Levelspeed].ToString();
		Herzenlv.text = herzenanz.ToString();

        PlayerPrefs.SetInt("JumpLength", Jumplength);
        PlayerPrefs.SetInt("Levelspeed", Levelspeed);
        PlayerPrefs.SetInt("Punkte", Punkte);
		PlayerPrefs.SetInt("herzen", herzenanz);

        if (Input.GetKeyDown("i")){
            if(skillsystem.activeSelf == true)
            {
                skillsystem.SetActive(false);
                IngameButtons.SetActive(true);
            }
            else{
                skillsystem.SetActive(true);
                IngameButtons.SetActive(false);
            }
        }
    }

    public void UpJumpLv()
    {
        if(Punkte >= 1 && Jumplength < JumpLevel.Length -1)
        {
            Punkte -= 1;
            Jumplength += 1;
        }
    }
    public void UpSpeedLv()
    {
        if (Punkte >= 1 && Levelspeed < SpeedLevel.Length -1)
        {
            Punkte -= 1;
            Levelspeed += 1;
        }
    }
	public void UpHerzenLv()
	{
		if (Punkte >= 1 && herzenanz < 5)
		{
			Punkte -= 1;
			herzenanz += 1;			
			Herzen [herzenanz -1].SetActive (true);
			gameObject.GetComponent<steuerung>().leben = herzenanz + 3;
		}
	}

    public void MobilOpen()
    {
        if (skillsystem.activeSelf == true)
        {
            skillsystem.SetActive(false);
            IngameButtons.SetActive(true);
        }
        else {
            skillsystem.SetActive(true);
            IngameButtons.SetActive(false);
        }
    }
}
