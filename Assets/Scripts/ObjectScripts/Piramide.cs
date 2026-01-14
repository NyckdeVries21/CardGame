using UnityEngine;

public class Piramide : MonoBehaviour
{
    private float ObjSpeed = 4;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += (transform.forward * ObjSpeed) * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.EnemyHP -= 15;
            GameManager.instance.UpdateEnemyHPBar();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayerHP -= 15;
            GameManager.instance.UpdatePlayerHPBar();
            Destroy(gameObject);
        }
    }
}
