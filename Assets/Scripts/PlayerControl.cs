using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;

    private Rigidbody playerRB;

    private GameObject focalPoint;

    private bool hasPowerUp = false;

    [SerializeField] private int powerUpStrenght = 15;

    [SerializeField] private GameObject PowerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardinput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.transform.forward * moveSpeed * forwardinput);
        PowerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            PowerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDown());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            
        }
        {
            
        }
    }

    private IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        PowerUpIndicator.SetActive(false);

    }
}
