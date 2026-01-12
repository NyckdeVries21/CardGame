using Unity.VisualScripting;
using UnityEngine;

public class Boomstam : MonoBehaviour
{
    private float ObjSpeed = 5;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(transform.forward * ObjSpeed, ForceMode.Force);
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
    }
}
