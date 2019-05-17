using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    public float max_x = 2.6f, min_x = -2.6f, min_y = -5.6f;
    public bool out_Of_Bounds;//par défaut c'est true

    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        //je recupère la position courante du player
        Vector2 temp = transform.position;

        if (temp.x > max_x)
            temp.x = max_x;


        if (temp.x < min_x)
            temp.x = min_x;

        transform.position = temp;

        if (temp.y <= min_y)
        {
            if (!out_Of_Bounds)
            {
                out_Of_Bounds = true;

                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }

    }
}
