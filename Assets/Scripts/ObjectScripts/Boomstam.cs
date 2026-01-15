using Unity.VisualScripting;
using UnityEngine;

public class Boomstam : MonoBehaviour
{
    private float ObjSpeed = 6;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += transform.forward * ObjSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.EnemyHP -= 10;
            GameManager.instance.UpdateEnemyHPBar();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHP -= 10;
            GameManager.instance.UpdatePlayerHPBar();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}
