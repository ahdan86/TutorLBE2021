using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        //Jika Bola ke arah computer paddle
        if (this.ball.velocity.x > 0.0f)
        {
            //JIka Bola di atas computer paddle
            if (this.ball.position.y > this.transform.position.y)
            {
                _rigidBody.AddForce(Vector2.up * this.speed);
            }
            //JIka Bola di bawah computer paddle
            else if (this.ball.position.y < this.transform.position.y)
            {
                _rigidBody.AddForce(Vector2.down * this.speed);
            }
        }
        else
        {
            //Kode dibawah akan memposisikan computer paddle ke tengah
            if (this.transform.position.y > 0.0f)
            {
                _rigidBody.AddForce(Vector2.down * this.speed);
            }
            else if (this.transform.position.y < 0.0f)
            {
                _rigidBody.AddForce(Vector2.up * this.speed);
            }
        }
    }
}