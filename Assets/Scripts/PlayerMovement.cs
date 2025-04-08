
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    [SerializeField] float speed=5f;
    [SerializeField] float xclamp=3f;
    [SerializeField] float zclamp=2f;
    [SerializeField] float jumpForce = 5f; 
    [SerializeField] Animator animator;
     public  Transform groundCheck;
      public LayerMask groundLayer;
      public float var;
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        //Debug.DrawRay(groundCheck.position, Vector3.down * var, Color.yellow); 
            MovePlayer();
    }
    public void Move(InputAction.CallbackContext Context)
    {
        movement=Context.ReadValue<Vector2>();
    } 
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded()) 
        {
            Debug.Log("Jump is Called");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            animator.SetTrigger("Jump");

        }
    }
    private bool IsGrounded()
    {
         RaycastHit hit;
         bool hitt = Physics.Raycast(groundCheck.position, Vector3.down,out hit, var, groundLayer);
         Debug.Log($"hit name: {hit.distance}, bool : { hitt}");
        return hitt;
    }

    public void MovePlayer()
    {
        
       Vector3 currentpos=rb.position;
       Vector3 movedirection= new Vector3(movement.x,0f,movement.y);
       Vector3 newpos=currentpos+movedirection*speed*Time.deltaTime;
       newpos.x=Mathf.Clamp(newpos.x,-xclamp,xclamp);
       newpos.z=Mathf.Clamp(newpos.z,-zclamp,zclamp);
       rb.MovePosition(newpos);
    }
}
