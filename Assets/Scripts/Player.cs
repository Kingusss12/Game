using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    float runSpeed,jumpSpeed, moveX;
    public PlayerData presistentData;
    bool isGrounded = true;
    Rigidbody2D rb;
    public Transform Checkpoint;
    public Transform Sprite;
    public Vector2 PickupOffset;
    public ContactFilter2D CollisionDetection;
    public GameItem PickedUpObject;
    public Objective Objective;
    private void Awake()
    {
        Instance = this;
        if (SceneLoaderScript.Instance)
            presistentData = SceneLoaderScript.Instance.PlayerData;
        else
            presistentData = PlayerData.Load();
    }


    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 5;
        jumpSpeed = 440;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * runSpeed, rb.velocity.y);
        if (moveX > 0)
        {
            if (PickedUpObject)
                PickedUpObject.transform.localPosition = new Vector3(PickupOffset.x, PickupOffset.y, 0f);
            Sprite.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveX < 0)
        {
            if (PickedUpObject)
                PickedUpObject.transform.localPosition = new Vector3(-PickupOffset.x, PickupOffset.y, 0f);
            Sprite.localScale = new Vector3(1f, 1f, 1f);
        }
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


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground"  || col.gameObject.tag == "GameController" || col.gameObject.tag == "Help")
        {
            if (col.relativeVelocity.y > 0)
                isGrounded = true;
        }

    }

    public void Die()
    {
        presistentData.Lives--;
        if (presistentData.Lives <= 0)
        {
            SceneManager.LoadScene("World");
            print("Game Over");
        }
        else
        {
            Objective.Reset();
            transform.position = Checkpoint.position;
        }
    }

    public void SetObjective(Objective newObjective)
    {
        Objective = newObjective;
    }
}

