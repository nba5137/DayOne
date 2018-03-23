using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Shoot : MonoBehaviour {

    public int type = 1;
    public int damage;
    public float gap;
    public float range;
    public Camera fpsCam;

    GameObject gun_now;
    LineRenderer gun_line;
    Light gun_light;
    RaycastHit where_hit;
    float timer;
    float display_time = 0.2f;
	
    /* Name: type / damage / gap / range
     * Red Star: 1 / 20 / 0.2f / 100f
     *
     * 
     */

	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (type == 1)
        {
            damage = 20;
            gap = 0.2f;
            range = 100f;
            gun_now = GameObject.Find("RS_end");
            gun_line = gun_now.GetComponent<LineRenderer>();
            gun_light = gun_now.GetComponent<Light>();
        }

        if (Input.GetButton("Fire1") && timer >= gap)
        {
            Shoot();
        }

        if (timer >= gap * display_time)
        {
            // disable effects
            Display_Off();
        }
    }

    void Display_Off()
    {
        gun_line.enabled = false;
        gun_light.enabled = false;
    }

    void Shoot()
    {
        // Reset the timer.
        timer = 0f;

        gun_light.enabled = true;

        // Set position for line render
        gun_line.enabled = true;
        gun_line.SetPosition(0, gun_now.transform.position);

        // detecting if shoot anything
        if (Physics.Raycast(gun_now.transform.position, fpsCam.transform.forward, out where_hit, range))
        {
            // Set the end point for the ray.
            gun_line.SetPosition(1, where_hit.point);
        }
        else
        {
            // shoot as far as it can go.
            gun_line.SetPosition(1, gun_now.transform.position + fpsCam.transform.forward * range);
        }
    }
}
