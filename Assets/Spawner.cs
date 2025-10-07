using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform limitX, limitNegX;
    private Transform spawner;
    private float maxTimeBetweenEnemies;
    private float currentTimeBetweenEnemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxTimeBetweenEnemies = 0.5f;
        currentTimeBetweenEnemies = maxTimeBetweenEnemies;
        spawner = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= currentTimeBetweenEnemies)
        {
            GameObject enem = Instantiate(enemy, spawner.position, Quaternion.identity);
            enem.GetComponent<Enemy>()._enemyLimitPosNegX = limitNegX;
            enem.GetComponent<Enemy>()._enemyLimitPosX = limitX;
            currentTimeBetweenEnemies += maxTimeBetweenEnemies;
        }
        
    }
}
