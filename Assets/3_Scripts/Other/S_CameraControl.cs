using UnityEngine;

public class S_CameraControl : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 150.0f;
    [SerializeField] float minZoom = 10.0f;
    [SerializeField] float maxZoom = 100.0f;
    [SerializeField] float moveSpeed = 50.0f;
    [SerializeField] Vector2 WorldBorder = new Vector2(70.0f, 70.0f);
    Vector2 offSet;

    private void Start()
    {
        offSet.x += transform.position.x;
        offSet.y += transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w"))
        {
            pos.z += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * zoomSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, offSet.x-WorldBorder.x, offSet.x + WorldBorder.x);
        pos.y = Mathf.Clamp(pos.y, minZoom, maxZoom);
        pos.z = Mathf.Clamp(pos.z, offSet.y- WorldBorder.y, offSet.y + WorldBorder.y);

        transform.position = pos;
    }
}
