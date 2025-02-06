using UnityEngine;

public class Star : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;

    public float maxScale = 1f;
    public float minScale = 0.1f;

    public float maxSpeed = 5f;
    public float minSpeed = 1f;

    private SpriteRenderer _spriteRenderer;

    private int _animationFrame;

    private float speed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        this.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        speed = Random.Range(minSpeed, maxSpeed);

        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void Update()
    {
        if (this.transform.position.y <= -46)
            Destroy(this.gameObject);
        else
            this.transform.position += Vector3.down * speed * Time.deltaTime;
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
