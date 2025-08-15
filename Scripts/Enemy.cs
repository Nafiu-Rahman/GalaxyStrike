using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 10;
    [SerializeField] int scoreValue = 10;

    ScoreBoard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}