using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{

    public Vector2 speed = new Vector3(1, 1);
    private Vector2 startSpeed;

    public string tagToCheck = "Player";

    [Header("Randomization")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);

    private Vector2 _startPosition;
    public bool _canMove = false;

    public void Awake()
    {
        _startPosition = transform.position;
        startSpeed = speed;
    }

    void Update()
    {
        if (!_canMove) return;
        transform.Translate(speed * Time.deltaTime * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == (tagToCheck))
            OnPlayerCollision();
        else if (collision.gameObject.tag == "Ball")
            OnBallCollision();
        else
            speed.y *= -1;
    }

    private void OnBallCollision()
    {
        speed.x *= -1;
        speed.y *= -1;
    }
    public virtual void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startSpeed;
    }

    public void canMove(bool state)
    {
        _canMove = state;
    }
}

