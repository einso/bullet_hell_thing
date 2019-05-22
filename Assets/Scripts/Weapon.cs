using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool Playerweapon1;
    public bool Playerweapon2;
    public bool Playerweapon3;
    public bool Playerweapon4;
    public bool Playerweapon5;
    [Space(20)]
    public float delay = 0.15f;
    float weaponSprayStrengthWhilePressingShift = 0;
    public float weapon2SprayStrength = 7;
    public float weapon3SprayStrength = 7;
    public float weapon4SprayStrength = 7;
    public float weapon5SprayStrength = 7;
    [Space(20)]
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    float t;

    Quaternion bulletRotation1;
    Quaternion bulletRotation2;
    Quaternion bulletRotation3;
    Quaternion bulletRotation4;

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
            else if(Playerweapon3)
            {
                PlayerWeapon3();
                t = 0;
            }
            else if (Playerweapon4)
            {
                PlayerWeapon4();
                t = 0;
            }
            else if (Playerweapon5)
            {
                PlayerWeapon5();
                t = 0;
            }

        }
    }

    //Player Level 1
    void PlayerWeapon1()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    //Player Level 2
    void PlayerWeapon2()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon2SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon2SprayStrength, 0);
        }


        Instantiate(bulletPrefab, new Vector3(firePoint.position.x -0.2f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.2f, firePoint.position.y, firePoint.position.z), bulletRotation2);
    }

    //Player Level 3
    void PlayerWeapon3()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon3SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon3SprayStrength, 0);
        }

        Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), firePoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.2f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.2f, firePoint.position.y, firePoint.position.z), bulletRotation2);
    }

    //Player Level 4
    void PlayerWeapon4()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon4SprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - weapon4SprayStrength - weapon4SprayStrength - weapon4SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon4SprayStrength, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + weapon4SprayStrength + weapon4SprayStrength + weapon4SprayStrength, 0);
        }

        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.1f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation3);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.1f, firePoint.position.y, firePoint.position.z), bulletRotation2);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation4);
    }

    //Player Level 5
    void PlayerWeapon5()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + weaponSprayStrengthWhilePressingShift, 0);
        }
        else
        {
            bulletRotation1 = Quaternion.Euler(0, -90 - weapon5SprayStrength, 0);
            bulletRotation3 = Quaternion.Euler(0, -90 - weapon5SprayStrength - weapon5SprayStrength, 0);
            bulletRotation2 = Quaternion.Euler(0, -90 + weapon5SprayStrength, 0);
            bulletRotation4 = Quaternion.Euler(0, -90 + weapon5SprayStrength + weapon5SprayStrength, 0);
        }

        Instantiate(bulletPrefab, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + 0.1f), firePoint.rotation);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.15f, firePoint.position.y, firePoint.position.z), bulletRotation1);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x - 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation3);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.15f, firePoint.position.y, firePoint.position.z), bulletRotation2);
        Instantiate(bulletPrefab, new Vector3(firePoint.position.x + 0.3f, firePoint.position.y, firePoint.position.z - 0.1f), bulletRotation4);
    }
}
