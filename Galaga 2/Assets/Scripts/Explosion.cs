using UnityEngine;

public class Explosion : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;

    public Sprite[] animationSprites;

    public float animationTime = 1.0f;

    private int _animationFrame;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= animationSprites.Length)
        {
            Destroy(this.gameObject);
        }
        else _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
}
