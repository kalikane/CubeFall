using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    public float moveSpeed = 2f;
    Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        Move();
      
	}

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.x);

        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

        }

    }//Move

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
