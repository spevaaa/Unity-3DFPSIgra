
using UnityEngine;
using TMPro;

public class FPSController : MonoBehaviour
{
    public static FPSController instance;

    public float speed = 3f;
    public float jumpForce = 5f;
    public float raycastDistance = 1.2f;
    private Rigidbody rb;

    [Header("Score")]
    public int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v) * speed * Time.deltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private bool IsGrounded()
    {
        return (Physics.Raycast(transform.position, Vector3.down, raycastDistance));
    }
}
