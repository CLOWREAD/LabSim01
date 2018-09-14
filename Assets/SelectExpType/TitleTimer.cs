using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleTimer : MonoBehaviour {

    public Sprite m_TitleImg00;
    public Sprite m_TitleImg01;
    public Sprite m_TitleImg02;

    int index = 0;
    float timedelta = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timedelta += Time.deltaTime;
        //Debug.Log(timedelta);
        if(timedelta >0.06)
        {
            timedelta = 0;
        Image im= this.GetComponent<Image>();

        index = Random.Range(0,9);
        index %= 3;
            switch (index)
        {

            case 0:
                im.sprite = m_TitleImg00;
                break;
            case 1:
                im.sprite = m_TitleImg01;
                break;
            case 2:
                im.sprite = m_TitleImg02;
                break;

        }
        
       

        }

    }
}
