using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Health : MonoBehaviour
{
    public int max_health = 100;
    public int cur_health;
    // reference to UI_HP, UI_Damaged.
    public Slider health_slider;
    public Image damaged_image;

    // time for damaged image to fade away
    public float fade_time = 5f;

    // reference in order to disable them. 
    PlayerMove playerMove;
    Gun_Shoot gunShoot;
    bool isDead;
    bool isDamaged;


    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        gunShoot = GetComponentInChildren<Gun_Shoot>();

        // setting HP. 
        cur_health = max_health;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (isDamaged)
        {
            damaged_image.color = new Color(1f, 0f, 0f, 0.5f);
        }
        else
        {
            // clear the color. 
            damaged_image.color = Color.Lerp(damaged_image.color, Color.clear, fade_time * Time.deltaTime);
        }

        isDamaged = false;
    }


    public void TakeDamage(int amount)
    {
        isDamaged = true;

        cur_health -= amount;
        health_slider.value = cur_health;

        if (cur_health <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        gunShoot.Display_Off();

        // diable scripts of players. 
        playerMove.enabled = false;
        gunShoot.enabled = false;
    }
}