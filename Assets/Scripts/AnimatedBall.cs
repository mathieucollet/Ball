using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Animator))]
public class AnimatedBall : MonoBehaviour
{
    [FormerlySerializedAs("PointPreFab")]
    public GameObject paf;
    public float Speed = 3;

    private DateTime _nextChangeTime = DateTime.Now;
    private Vector3 _orientation = Vector3.right;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _collisionSpriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        var pafInstance = Instantiate(paf);
        pafInstance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        _collisionSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _collisionSpriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (!trigger.gameObject.CompareTag("Goal")) return;
        ScoreManager.instance.blueTeamScore++;
    }
}
