using UnityEngine;

[RequireComponent(typeof(SpritesheetAnimator), typeof(SpriteRenderer))]

public class AnimateGirlSpritesheet : MonoBehaviour
{
    private SpritesheetAnimator animator;
    private SpriteRenderer spriteRenderer;
    public float maxSpeed = 2;

    void Start()
    {
        animator = GetComponent<SpritesheetAnimator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var maxDistancePerFrame = maxSpeed * Time.deltaTime;
        Vector2 speed = Vector2.zero;
        bool isIddle = true;

        // RIGHT LEFT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            speed += Vector2.right * maxDistancePerFrame;
            animator.Play(Anims.Run);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            speed += Vector2.left * maxDistancePerFrame;
            animator.Play(Anims.Run);
        }

        // UP
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += Vector2.up * maxDistancePerFrame;
            animator.Play(Anims.Run);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed += Vector2.down * maxDistancePerFrame;
            animator.Play(Anims.Run);
        }

        // ROLL
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isIddle = false;
            animator.Play(Anims.Roll);
        }

        // JUMP
        if (Input.GetKey(KeyCode.Space))
        {
            isIddle = false;
            animator.Play(Anims.Jump);
        }

        // MOVE
        if (speed != Vector2.zero)
        {
            isIddle = false;
            this.transform.position = this.transform.position + (Vector3)speed;
        }

        // IDDLE
        if (isIddle)
        {
            animator.Play(Anims.Iddle);
        }
    }
}