using UnityEngine;

[RequireComponent(typeof(SpritesheetAnimator), typeof(SpriteRenderer))]

public class AnimateGirlSpritesheet : MonoBehaviour
{
    private SpritesheetAnimator _animator;
    private SpriteRenderer _spriteRenderer;
    public float maxSpeed = 2;

    private void Awake()
    {
        _animator = GetComponent<SpritesheetAnimator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var maxDistancePerFrame = maxSpeed * Time.deltaTime;
        var speed = Vector2.zero;
        var isIddle = true;

        // RIGHT LEFT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _spriteRenderer.flipX = false;
            speed += Vector2.right * maxDistancePerFrame;
            _animator.Play(Anims.Run);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _spriteRenderer.flipX = true;
            speed += Vector2.left * maxDistancePerFrame;
            _animator.Play(Anims.Run);
        }

        // UP
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += Vector2.up * maxDistancePerFrame;
            _animator.Play(Anims.Run);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed += Vector2.down * maxDistancePerFrame;
            _animator.Play(Anims.Run);
        }

        // ROLL
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isIddle = false;
            _animator.Play(Anims.Roll);
        }

        // JUMP
        if (Input.GetKey(KeyCode.Space))
        {
            isIddle = false;
            _animator.Play(Anims.Jump);
        }

        // MOVE
        if (speed != Vector2.zero)
        {
            isIddle = false;
            transform.position += (Vector3)speed;
        }

        // IDDLE
        if (isIddle)
        {
            _animator.Play(Anims.Iddle);
        }
    }
}