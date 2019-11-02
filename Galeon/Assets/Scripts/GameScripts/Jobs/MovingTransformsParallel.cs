using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public struct MovingTransformsParallel : IJobParallelForTransform
{
    private Vector3 target;
    private float distance;
    private float speed;
    private float time;

    public MovingTransformsParallel(Vector3 t, float d, float s, float ti){
        target = t;
        distance = d;
        speed = s;
        time = ti;
    }
    public void Execute(int index, TransformAccess transform)
    {
        Vector3 direction = target - transform.position;
        if(direction.magnitude > distance){
            transform.position = transform.position + direction.normalized * speed * time;
        }
    }
}
