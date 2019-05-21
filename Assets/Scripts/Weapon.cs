using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool Playerweapon1;
    public bool Playerweapon2;
    [Space(20)]
    public float delay = 0.25f;
    public float weapon2SprayStrength = 7;
    public float weapon2SprayStrengthWhilePressingShift = 1;
    [Space(20)]
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    float t;

    Quaternion bulletRotation1;
    Quaternion bulletRotation2;

    void Start()
    {
        t = delay;
    }

    // Update is called once per frame
    void Update()
    {
        t = t + 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && t > delay)
        {
            if(Playerweapon1)
            {
                PlayerWeapon1();
                t = 0;
            }
            else if(Playerweapon2)
            {
                PlayerWeapon2();
                t = 0;
            }
            
        }
    }

    void PlayerWeapon1()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void PlayerWeapon2()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon2SprayStrengthWhilePressingShift, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon2SprayStrengthWhilePressingShift, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon2SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon2SprayStrength, 0);
        }


        Instantiate(bulletPrefab, new Vector3(firePoint.position.x -0.2f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.2f, firePoint.position.y, firePoint.position.z), bulletRotation2);
    }
}
