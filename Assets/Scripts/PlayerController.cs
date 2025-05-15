using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] lanes;         // Массив из 4 дорожек
    private int currentLaneIndex = 1; // Старт между Lane1 и Lane2
    private Vector3 targetPosition;
    public float moveSpeed = 10f;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) MoveToLane(0);
        if (Input.GetKeyDown(KeyCode.D)) MoveToLane(1);
        if (Input.GetKeyDown(KeyCode.J)) MoveToLane(2);
        if (Input.GetKeyDown(KeyCode.K)) MoveToLane(3);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    void MoveToLane(int index)
    {
        if (index >= 0 && index < lanes.Length)
        {
            currentLaneIndex = index;
            targetPosition = new Vector3(
                lanes[index].position.x,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
