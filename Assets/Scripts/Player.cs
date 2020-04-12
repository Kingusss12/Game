using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int lives, coins;
    public bool treeTraversal, binarySearchTree, sort, stack, queue, linkedList, gameIsSaved;
    public static Player Instance;
    float runSpeed,jumpSpeed, moveX;
    bool isGrounded = true;
    Rigidbody2D rb;
    public Transform Checkpoint;
    private Vector3 localScale;
    public Vector2 scale;
    public Vector2 PickupOffset;
    public ContactFilter2D CollisionDetection;
    public GameItem PickedUpObject;
    public Objective Objective;

    private Animator anim;

    private void Awake()
    {
        Instance = this;
        lives = SceneLoaderScript.Instance.PlayerData.Lives;
        coins = SceneLoaderScript.Instance.PlayerData.Coins;
        treeTraversal = SceneLoaderScript.Instance.PlayerData.TreeTraversal;
        binarySearchTree = SceneLoaderScript.Instance.PlayerData.BinarySearchTree;
        sort = SceneLoaderScript.Instance.PlayerData.Sort;
        stack = SceneLoaderScript.Instance.PlayerData.Stack;
        queue = SceneLoaderScript.Instance.PlayerData.Queue;
        linkedList = SceneLoaderScript.Instance.PlayerData.LinkedList;
        gameIsSaved = SceneLoaderScript.Instance.PlayerData.GameIsSaved;
    }


    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 2.5f;
        jumpSpeed = 500;
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * runSpeed;


        //if character moves on the X axis -> set animation to Walk
        if (Mathf.Abs(moveX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isWalking", true);
        }
        else anim.SetBool("isWalking", false);
        
        if (moveX > 0)
        {
            if (PickedUpObject)
            {
                PickedUpObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            transform.localScale = new Vector3(scale.x, scale.y, 0.1f); 
        }
        else if (moveX < 0)
        {

            if (PickedUpObject)
            {
                
                     PickedUpObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
                transform.localScale = new Vector3(-scale.x, scale.y, 0.1f);
        }


        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        if (rb.velocity.y > 0) anim.SetBool("isJumping", true);

        //Jumping, player will able to jump after touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpSpeed);
            isGrounded = false;
        }

        List<Collider2D> objects = new List<Collider2D>();
        rb.OverlapCollider(CollisionDetection, objects);
        foreach (var obj in objects)
        {
            GameItem objScript = obj.GetComponent<GameItem>();
            if (objScript && objScript.CanUse && (objScript.AutoUse || Input.GetKeyDown(KeyCode.E)))
            {
                objScript.Use(this);
                if (objScript.PickupOnUse)
                {
                    PickedUpObject = objScript;
                    PickedUpObject.transform.SetParent(transform);
                    PickedUpObject.transform.localPosition = PickupOffset;
                 }
                  return;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * runSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground"  || col.gameObject.tag == "GameController" || col.gameObject.tag == "Help" || col.gameObject.tag == "MovingPlatform" )
        {

            if (col.relativeVelocity.y > 0)
                isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    public void Die()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 5;
            SceneManager.LoadScene("World");
            print("Game Over");
        }
        else
        {

            if ("BinarySearchTree" == SceneManager.GetActiveScene().name || "Queue" == SceneManager.GetActiveScene().name)
            {
                Objective.Reset();
                transform.position = Checkpoint.position;
            }
            if ("Stack" == SceneManager.GetActiveScene().name)
            {
                Objective.Reset();
                transform.position = Checkpoint.position;
            }
            else transform.position = Checkpoint.position;
        }
    }

    public void SetObjective(Objective newObjective)
    {
        Objective = newObjective;
    }

    public void OnDestroy()
    {
        SceneLoaderScript.Instance.PlayerData.Lives = lives;
        SceneLoaderScript.Instance.PlayerData.Coins = coins;
        SceneLoaderScript.Instance.PlayerData.TreeTraversal = treeTraversal;
        SceneLoaderScript.Instance.PlayerData.BinarySearchTree = binarySearchTree;
        SceneLoaderScript.Instance.PlayerData.Sort = sort;
        SceneLoaderScript.Instance.PlayerData.Stack = stack;
        SceneLoaderScript.Instance.PlayerData.Queue = queue;
        SceneLoaderScript.Instance.PlayerData.LinkedList = linkedList;
        SceneLoaderScript.Instance.PlayerData.GameIsSaved = gameIsSaved;
    }

}

