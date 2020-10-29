using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class AnimatedGirl : MonoBehaviour
{
    [FormerlySerializedAs("MaxSpeed")] [Tooltip("Vitesse max en unité par seconde")]
    public int maxSpeed = 10;
    [FormerlySerializedAs("Target")] public GameObject target;


    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.RightArrow;
    public KeyCode jump = KeyCode.Space;
    public KeyCode roll = KeyCode.Comma;

    private Animator _animator;
    private SpriteRenderer _mySpriteRenderer;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Roll = Animator.StringToHash("Roll");
    private static readonly int RunUp = Animator.StringToHash("RunUp");
    private Rigidbody2D _rigidbody2D;


    private void Update()
    {
        var maxDistancePerFrame = maxSpeed;
        var move = Vector3.zero;

        if (Input.GetKey(right))
        {
            move += Vector3.right * maxDistancePerFrame;
            _mySpriteRenderer.flipX = false;
        }
        else if (Input.GetKey(left))
        {
            move += Vector3.left * maxDistancePerFrame;
            _mySpriteRenderer.flipX = true;
        }

        if (Input.GetKey(up))
        {
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (Input.GetKey(down))
        {
            move += Vector3.down * maxDistancePerFrame;
        }

        _animator.SetBool(Jump, Input.GetKeyDown(jump));

        _animator.SetBool(Roll, Input.GetKeyDown(roll));
        
        _animator.SetBool(RunUp, Input.GetKey(up));

        _animator.SetFloat(Speed, move.magnitude * 10f);
        _rigidbody2D.velocity = move;
    }
    
    public void OnCollisionEnter(Collision other)
    {
        // how much the character should be knocked back
        const int magnitude = 5000;
        // calculate force vector
        var force = transform.position - other.transform.position;
        // normalize force vector to get direction only and trim magnitude
        force.Normalize();
        target.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
    }
}