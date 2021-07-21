using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int _score;
    private float _spawnRate = 1.0f;
    
    public List<GameObject> targets;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
            UpdateScore(5);
        }
    }

    private void UpdateScore(int scoreValue)
    {
        _score += scoreValue;
        scoreText.text = $"Score: {_score}";
    }
}
