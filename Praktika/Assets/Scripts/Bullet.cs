using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _bulletSpeed;
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.AddForce(new Vector2(_bulletSpeed, 0));
        _timer += Time.deltaTime;
        if (_timer > 4) 
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
