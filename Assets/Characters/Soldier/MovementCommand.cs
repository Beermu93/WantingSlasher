using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand
{
    private Vector3 direction;
    private float speed;
    private Transform transformTarget;
    private float time;

    public MovementCommand(Vector3 p_direction, float p_speed, Transform p_transform, float p_time)
    {
        direction = p_direction;
        speed = p_speed;
        transformTarget = p_transform;
        time = p_time;
    }
    public void Execute()
    {
        transformTarget.position += direction * (Time.deltaTime * speed);
    }
}
