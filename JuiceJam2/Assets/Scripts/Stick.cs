using UnityEngine;

public class Stick : MonoBehaviour
{
    public float speed = 2.0f;
    public float reachDistance = 2.0f;

    private Vector3 targetPosition;
    private bool moveUpRight = false;

    private bool move = false;

    void Start()
    {
        targetPosition = transform.position + new Vector3(reachDistance, reachDistance, 0);
    }

    void Update()
    {
        if (!IsGameRunning.Instance.isRunning)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            move = true;
        }

        if (move)
        {
            if (moveUpRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    moveUpRight = false;
                    targetPosition = transform.position - new Vector3(reachDistance, reachDistance, 0);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    moveUpRight = true;
                    targetPosition = transform.position + new Vector3(reachDistance, reachDistance, 0);
                }
            }
        }
    }
}