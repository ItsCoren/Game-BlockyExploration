using UnityEngine;

public class CameraFollow : MonoBehaviour{
	[SerializeField] GameObject player;
	[SerializeField] Vector2 followOffset;
	[SerializeField] float speed = 3f;
	private Vector2 cameraContainer;
	private Rigidbody2D rb;

	void Start(){
		cameraContainer = GetCameraContainer();
		rb = player.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		Vector2 follow = player.transform.position;
		float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
		float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

		Vector3 newPosition = transform.position;
		if (Mathf.Abs(xDifference) >= cameraContainer.x)
		{
			newPosition.x = follow.x;
		}
		if (Mathf.Abs(yDifference) >= cameraContainer.y)
		{
			newPosition.y = follow.y;
		}
		float moveSpeed = (rb.velocity.magnitude > speed) ? rb.velocity.magnitude+1 : speed;
		transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
	}

	private Vector3 GetCameraContainer()
	{
		Rect aspect = Camera.main.pixelRect;
		Vector2 cam = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
		cam.x -= followOffset.x;
		cam.y -= followOffset.y;
		return cam;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Vector2 border = GetCameraContainer();
		Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
	}
}