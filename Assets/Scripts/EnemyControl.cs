using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private int speed = 10;

    private Rigidbody _enemyRB;

    private GameObject _player;

    
    // Start is called before the first frame update
    void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRB.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        
        
    }
}
