using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Sprite[] animationSprites;
    public float animationTime = 1.0f;

    public Vector3 direction;
    public float speed;

    private int _animationFrame;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    public void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
}
