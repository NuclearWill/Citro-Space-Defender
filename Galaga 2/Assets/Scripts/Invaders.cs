using UnityEngine;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public float wideSpacing = 2.0f; 
    public float heightSpacing = 2.0f;

    public AnimationCurve speed;

    public float missileAttackRate;
    public Projectile missilePrefab;

    public int nextLevel;

    public int amountKilled { get; private set; }
    public int totalInvaders => this.rows * this.columns;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;
    public float amountAlive => this.totalInvaders - this.amountKilled;

    private Vector3 _direction = Vector3.right;

    private void Awake()
    {
        for(int row = 0; row < this.rows; row++)
        {
            float width = wideSpacing * (this.columns - 1);
            float height = heightSpacing * (this.rows - 1);
            Vector2 centering = new Vector2 (-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * heightSpacing), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[row], this.transform);

                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += col * wideSpacing;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(Random.value < (1.0f) / (float)this.amountAlive)
            {
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
            }
        }
    }

    private void InvaderKilled()
    {
        amountKilled++;

        if(this.amountKilled >= this.totalInvaders)
        {
            SceneManager.LoadScene(nextLevel,LoadSceneMode.Single);
        }
    }
}
