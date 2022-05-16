using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float speed = 0.5f;
    public float health;

    public int score;




    void Update()
    {


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;
        if (other.tag == "Cirno")
        {
            col.gameObject.GetComponent<Player_Cirno>().Damage();
            //Destroy(gameObject);
        }
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }


}