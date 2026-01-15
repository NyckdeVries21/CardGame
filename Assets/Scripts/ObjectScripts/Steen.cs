using UnityEngine;

public class Steen : MonoBehaviour
{
    private float ObjSpeed = 12;
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
            GameManager.instance.EnemyHP -= 8;
            GameManager.instance.UpdateEnemyHPBar();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHP -= 8;
            GameManager.instance.UpdatePlayerHPBar();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
    }
}
