using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedGirl : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(Speed, Input.GetKey(KeyCode.RightArrow) ? 2f : 0f);
    }
}