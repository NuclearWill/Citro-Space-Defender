using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private AudioSource audioPlayer;

    public AudioClip laserFire;
    public AudioClip deathExplosion;
    
    public Projectile laserPrefab;

    private SpriteRenderer _spriteRenderer;

    public Sprite[] animationSprites; //first sprite is front, second is left, third is right

    public float speed = 5.0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
            _spriteRenderer.sprite = this.animationSprites[1];
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
            _spriteRenderer.sprite = this.animationSprites[2];
        }
        else
        {
            _spriteRenderer.sprite = this.animationSprites[0];
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        audioPlayer.PlayOneShot(laserFire);
    }
}
