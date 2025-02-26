using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetY;
    [SerializeField] private float smooth = 0.125f;

    public static FollowPlayer instance;
    void Start()
    {
        offsetY = transform.position.y - player.position.y;
        instance = this;
    }

    void LateUpdate()
    {
        if (player.position.y > transform.position.y + 2.2f)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth * Time.deltaTime);
        }
    }
}
