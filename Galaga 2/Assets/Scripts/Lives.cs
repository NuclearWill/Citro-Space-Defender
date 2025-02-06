using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public GameObject[] oranges;
    private int lives;

    private void Awake()
    {
        lives = oranges.Length;
        Debug.Log("Number of Oranges = " + lives + "\n");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            LoseGame();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        lives -= 1;

        Debug.Log("Damage has been taken!\n");

        if(lives > 0 )
            Destroy(oranges[lives].gameObject);
        else
            LoseGame();
    }

    private void LoseGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
