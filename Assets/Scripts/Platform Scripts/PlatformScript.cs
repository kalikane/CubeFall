using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public float move_Speed = 2f;
    public float bound_y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    private void Awake()
    {
        if (is_Breakable)
            anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
        Move();
	}


    //Fonction qui fait monter la plateform sur l'axe y
    void Move()
    {
        //recupération de la position actuel de la platform
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;

        //j'affecte la nouvelle valeur de y au transform
        transform.position = temp;

        if(temp.y >= bound_y)
        {
            //je désactive l'objet
            gameObject.SetActive(false);
        }

    }//Move

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject",0.5f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_Spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }

        }

    }//OnTriggerEnter2D


    void OnCollisionEnter2D( Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable)
            {
                SoundManager.instance.IceBreakSound();
                anim.Play("Break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();

            }

        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Debug.Log("dedans");
            if (moving_Platform_Left)
            {
                Debug.Log("dans le moving_Platform_Left");
                target.gameObject.GetComponent<PlayerMouvement>().PlatformMove(-1.5f);

            }
            if (moving_Platform_Right)
            {
                Debug.Log("dans le moving_Platform_Right");
                target.gameObject.GetComponent<PlayerMouvement>().PlatformMove(1.5f);

            }
        }
    }
    
} 
