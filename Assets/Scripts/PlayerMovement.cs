using UnityEngine;
using UnityEngine.SceneManagement;

//oyuncunun hareketini ve zýplamasýný kontrol eder.
public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;

    [SerializeField] LayerMask groundMask;

    //FixedUpdate fonksiyonunda, oyuncunun ileri ve yan hareketi hesaplanýr.
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    //Update fonksiyonunda, yere çarpýp çarpmadýðý kontrol edilir ve ölüm durumu belirlenir.
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        {

        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    //Die, oyuncunun ölüm durumunu iþler ve oyunu yeniden baþlatýr.
    public void Die()
    {
        alive = false;
        // Oyunu tekrar baþlat
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }
}
