using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemy;

    [SerializeField] private float _timer;
    [SerializeField] private List<float> _jumpTime;

    void Update()
    {

        _timer += Time.deltaTime;
        if (_timer > _jumpTime[Random.Range(0, 3)]) 
        {
            Instantiate(Enemy[Random.Range(0,3)],new Vector2(transform.position.x, transform.position.y+1.2f),Quaternion.identity);
            _timer = 0;
        }
    }
}
