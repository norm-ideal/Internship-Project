using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cirno : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;




    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {



    }

    public void Damage()
    {
        maxHealth--;
        if (maxHealth == 0)
        {
            Destroy(gameObject);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage();
        }

    }


}
