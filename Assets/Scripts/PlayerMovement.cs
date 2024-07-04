using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (!ObstacleData.Instance.IsTileBlocked((int)hit.point.x, (int)hit.point.z))
                {
                    targetPosition = new Vector3(hit.point.x, 1, hit.point.z);
                    isMoving = true;
                }
            }
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        float speed = 5f;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
