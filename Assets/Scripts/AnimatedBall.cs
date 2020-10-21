using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Animator))]
public class AnimatedBall : MonoBehaviour
{
    public float Speed = 3;

    private DateTime _nextChangeTime = DateTime.Now;
    private Vector3 _orientation = Vector3.right;
    
    private void Update()
    {
        if (_nextChangeTime < DateTime.Now)
        {
            _orientation = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            _nextChangeTime = DateTime.Now.AddSeconds(1);
        }

        transform.position += _orientation * (Speed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(_orientation.y, _orientation.x));
    }
}
