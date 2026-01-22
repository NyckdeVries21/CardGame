using UnityEngine;

public class Kast : MonoBehaviour
{
    private float deadTimer = 3;
    private void Update()
    {
        //Destroy(gameObject, deadTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
