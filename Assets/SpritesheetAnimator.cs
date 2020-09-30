using System;
using System.Linq;
using UnityEngine;

// Lister toutes les animations possibles ici
public enum Anims
{
    Iddle,
    Run,
    Roll,
    Jump
}

// Structure de données pour définir une animation
[Serializable]
public struct AnimDefinition
{
    public Anims name;
    public Sprite[] frames;
}

[RequireComponent(typeof(SpriteRenderer))]
public class SpritesheetAnimator : MonoBehaviour
{

    [Tooltip("animation speed in images per seconds")]
    public float animationSpeed = 25;

    public AnimDefinition[] animations;

    // accessors (getters)
    public AnimDefinition CurrentAnimation => _currentAnimation;
    public int LoopCount => _loopCount;
    public float AnimationFrameDuration => 1f / animationSpeed;

    // private properties
    private SpriteRenderer _spriteRenderer;
    private AnimDefinition _currentAnimation;

    private int _currentFrameIndex = 0;

    // durée en seconde avant l'affichage de la prochaine image
    private float _nextFrameCoolDown;

    // nombre de fois que l'animation est jouée complètement
    private int _loopCount;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _nextFrameCoolDown = AnimationFrameDuration;
        _currentAnimation = animations[0];
    }

    private void Update()
    {
        if (_currentAnimation.frames.Length == 0) return;

        // déclenche la frame suivante si le temps est écoulé
        if (_nextFrameCoolDown <= 0)
        {
            AnimateNextFrame();
        }

        // si on change la vitesse de l'animation, raccourci le temps d'attente si nécessaire
        if (AnimationFrameDuration < _nextFrameCoolDown) _nextFrameCoolDown = AnimationFrameDuration;

        // écoule le temps avant la prochaine image
        _nextFrameCoolDown -= Time.deltaTime;
    }

    private void AnimateNextFrame()
    {
        // calcule l'indice de l'image suivante
        _currentFrameIndex = (_currentFrameIndex + 1) % _currentAnimation.frames.Length;
        // affiche l'image suivante
        _spriteRenderer.sprite = _currentAnimation.frames[_currentFrameIndex];
        // Ajoute un temps d'attente calculé à partir de la fréquence de l'animation
        _nextFrameCoolDown += AnimationFrameDuration;
        // compte le nombre de fois que l'animation a été jouée
        if (_currentFrameIndex == 0) _loopCount++;
    }

    public void Play(Anims nextAnimation)
    {
        // Si l'animation est déjà jouée, on ne fait rien
        if (_currentAnimation.name == nextAnimation) return;
        // trouve l'animation correspondante dans la liste
        _currentAnimation = animations.First(a => a.name == nextAnimation);
        // réinitialise à la première image de la séquence
        _currentFrameIndex = 0;
        _loopCount = 0;
    }
}