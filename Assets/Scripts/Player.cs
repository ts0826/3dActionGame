using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isSide;
    public Vector3 sideVec;

    [SerializeField]
    float speed;

    float hAxis;
    float vAxis;

    bool wDown;

    Vector3 moveVec;

    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        Move();
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;


        if (isSide && moveVec == sideVec)
            moveVec = Vector3.zero;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);



        transform.LookAt(transform.position + moveVec);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isSide = true;
            sideVec = moveVec;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isSide = false;
            sideVec = Vector3.zero;
        }
    }
}
