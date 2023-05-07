using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float lerpCoeff;
    [SerializeField] private float moveSpeed;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            direction.y = 1;
        if (Input.GetKey(KeyCode.A))
            direction.x = -1;
        if (Input.GetKey(KeyCode.D))
            direction.x = 1;
        if (Input.GetKey(KeyCode.S))
            direction.y = -1;
        if (direction != Vector2.zero)
        {
            rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(rigidbody2D.transform.right.x, rigidbody2D.transform.right.y) * moveSpeed * Time.deltaTime);
            Debug.Log(Vector2.SignedAngle(rigidbody2D.transform.right, direction));
            rigidbody2D.MoveRotation(Mathf.Lerp(rigidbody2D.rotation,rigidbody2D.rotation + Vector2.SignedAngle(rigidbody2D.transform.right, direction), lerpCoeff));
        }
       
        
    }
}
