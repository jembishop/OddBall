using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour {
	public Text t;
    public Canvas can;
	Image i;
    SoundManager s;
    private void Start()
    {
        i = can.GetComponent<Image>();
        s = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void Resum(){
		t.text="";
		i.enabled=false;
		Time.timeScale=1;
        s.Next();
        gameObject.SetActive(false);

	}
}
