using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyBall : BallBase
{
    [Header("Speed Scales")]
    public float speedXScale = 1.5f;
    public float speedYScale = 1.5f;
   public override void OnPlayerCollision()
    {
        speed.x *= -1;

        speed.x *= speedXScale;
        speed.y *= speedYScale;
    }

}
