using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpVFX : MonoBehaviour
{
    float t;
    TextMeshPro textMeshPro;

    Color32 startCol = new Color32(255, 255, 255, 255);
    Color32 endCol = new Color32(255, 255, 255, 0);

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move position
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x - 1 * Time.deltaTime, pos.y, pos.z);

        //Change transparency
        t += 2 * Time.deltaTime;
        textMeshPro.color = Color32.Lerp(startCol, endCol, t);

        //Delete after time
        if (t >= 1) Destroy(gameObject);
    }
}
