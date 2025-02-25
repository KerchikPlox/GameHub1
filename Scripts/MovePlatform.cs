using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 startPos;
    // Update is called once per frame
    void Update()
    {
        while (transform.position.x < 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos + transform.right * 1, 3 * Time.deltaTime);
        }
    }
}
