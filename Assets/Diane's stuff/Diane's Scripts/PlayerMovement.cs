using System.Collections;
using UnityEngine;

//Added to manage the scene
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] public static int extraJumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //Horizontal wall jump force
    [SerializeField] private float wallJumpY; //Vertical wall jump force

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("Dashing")]

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 60f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] 
    private TrailRenderer trail;

    [Header("Platform")]
    [SerializeField]
    private LayerMask platformLayer;
    private Transform platform;
    private bool isOnThePlatform = false;
    float radius = 0.4f;

    public static bool isReloadingScene = false;
    public static float deathTimes = 0;


    void Start()
    {
        this.platform = null;
    }
    private void Awake()
    {
        #region CAleb's stuff:

        anim = GetComponent<Animator>();

        #endregion

        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if(isDashing == true)
        {
            return;
        }
        horizontalInput = Input.GetAxis("Horizontal");

        #region CAleb's stuff (movement ANIMATIONS):

        if(horizontalInput == 0) //If the player isn't moving
        {
            anim.SetBool("isRunning", false);

        } else
        {
            anim.SetBool("isRunning", true);
        }

        #endregion

        #region Caleb's stuff (Death animation):

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            deathTimes += 1;
            anim.SetTrigger("player Is Dead"); //Trigger prevents other animations from playing

            StartCoroutine(ReloadScene());
        }

        #endregion

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);

        //Set animator parameters
        //anim.SetBool("run", horizontalInput != 0);
        //anim.SetBool("grounded", isGrounded());

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
        }

        #region Caleb's stuff (jump TAKE OFF animation):
        if (isGrounded())
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
        #endregion

        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0 )
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        if (onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && ActionsManager.hasDashing == true)
        {
            Debug.Log("Dashing");
            StartCoroutine(Dash());
        }

        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded() || isOnThePlatform)
            {
                coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
                jumpCounter = extraJumps; //Reset jump counter to extra jump value
            }
            else
                coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
        }


        if (platform != null)
        {
            transform.parent = platform;
        }
        else
        {
            transform.parent = null;

        }

        if (isOnThePlatform)
        {
            isOnThePlatform = isOnPlatform();
        }
    }

   
    private bool isOnPlatform()
    {
     RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, 0.1f, platformLayer);
    if (hit && isOnThePlatform) isOnThePlatform = true;
    if (hit) this.platform = hit.collider.gameObject.transform;
    else this.platform = null;
    return hit.collider != null;

  
    }
    private void Jump()
    {
        
        if (coyoteCounter <= 0 && !onWall() && jumpCounter <= 0) return; 
        //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything

       // SoundManager.instance.PlaySound(jumpSound);

        if (onWall() && PurchaseActions.climbing == true)
        {
            
            
                WallJump();
            
            

        }
        else
        {
            if (isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);

                #region Caleb's stuff (jump TAKE OFF animation):
                anim.SetTrigger("jump_takeOff");
                #endregion
            }
            else
            {
                //If not on the ground and coyote counter bigger than 0 do a normal jump
                if (coyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                else
                {
                    if (jumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }

            //Reset coyote counter to 0 to avoid double jumps
            coyoteCounter = 0;
        }
    }

    private void WallJump()
    {
        
          body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
            wallJumpCooldown = 0;

        //Climbing animation
        anim.SetTrigger("isClimbing");
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;

        

    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trail.emitting = true;

        //Dashing animation
        anim.SetTrigger("isDashing");
        //

        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;


        


    }

    public IEnumerator ReloadScene()
    { 
      
       
            //Wait for 2 seconds
            yield return new WaitForSeconds(2);

            SceneManager.LoadScene("scene"); //reload scene

       


    }
}