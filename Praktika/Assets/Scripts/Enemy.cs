using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _enemySpeed;

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.AddForce(new Vector2(-_enemySpeed,0)); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Destroyer" || collision.collider.GetComponent<Bullet>()) 
        {
            Destroy(this.gameObject);
        }
    }
}
