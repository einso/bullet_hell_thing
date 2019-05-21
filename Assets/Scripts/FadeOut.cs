using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOut : MonoBehaviour
{
    float t;
    float fontSize;

    // Start is called before the first frame update
    void Start()
    {

        //this.GetComponent<TextMeshPro>().color = new Color32(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.name == "ScoreFeedbackTMP(Clone)")
        {
            t = t + 2.5f * Time.deltaTime;
            //fadeout -= 5;
            this.GetComponent<TextMeshPro>().color = Color32.Lerp(new Color32(255, 90, 90, 255), new Color32(255, 90, 90, 0), t);

            if (this.GetComponent<TextMeshPro>().fontSize < 5)
            {
                this.GetComponent<TextMeshPro>().fontSize += 2.5f * Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
