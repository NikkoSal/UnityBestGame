using UnityEngine;

public class NoteMover : MonoBehaviour
{
    public float moveSpeed = 5f;    // Скорость движения по Z
    public float destroyZ = -2f;    // Удалить, если пролетело мимо

    void Update()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z <= destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
