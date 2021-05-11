using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D myRb;
  public float moveSpeed;

  public Animator myAnim;
  public string playerNickName;

  public static PlayerController instance;

  public string areaTransitionName;

  private Vector3 bottomLeftLimit;
  private Vector3 topRightLimit;

  public bool canMove = true;

  void Start()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      if (instance != this)
      {
        Destroy(gameObject);
      }
    }

    DontDestroyOnLoad(gameObject);
  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
    {
      Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
      myRb.velocity = Vector2.ClampMagnitude(move, moveSpeed);

      myAnim.SetFloat("moveX", myRb.velocity.x);
      myAnim.SetFloat("moveY", myRb.velocity.y);
    }else
    {
      myRb.velocity = Vector2.zero;
    }

    if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Vertical") == 1)
    {
      if(canMove)
      {
        myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
        myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
      }
      
    }

    transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
  }

  public void SetBounds(Vector3 botLeft, Vector3 topRight)
  {
    bottomLeftLimit = botLeft + new Vector3(0.5f, 0.8f, 0f);
    topRightLimit = topRight + new Vector3(-0.5f, -0.8f, 0f);
  }

}
