using UnityEngine;

public class Snelwegbord : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
