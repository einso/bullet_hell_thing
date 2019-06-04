using UnityEngine;

public class Parallax : MonoBehaviour {

	private float length, startPos;
	public GameObject backGround;
	public float parallexEffect;

	void Start () {
		startPos = transform.position.z;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void Update () {
		float dist = (backGround.transform.position.z*parallexEffect);

		transform.position = new Vector3(transform.position.x, transform.position.y, startPos + dist);

        if (transform.localPosition.z >= 24)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, startPos);
            
        }

    }

}
