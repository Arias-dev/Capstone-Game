using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

[SerializeField] private float Speed, jumpSpeed;
// [SerializeField] private LayerMask ground;

// private PlayerActionControls playerActionControls;
private Rigidbody2D rb;
private Collider2D col;
private Animator anim;
private bool isMoving;
private bool isGrounded;
private bool isPullLever;
private int jumpCount;
public int DefaultJumpCount = 2;
// private bool isJump;

public bool buttonUp;
public bool buttonLeft;
public bool buttonRight;
public bool buttonDown;
public bool buttonJump;
public bool buttonPullLever;


private Vector3 DefaultScale;





void Start(){

    // playerActionControls = new PlayerActionControl();
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<Collider2D>();
    anim = GetComponent<Animator>();
    DefaultScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y, rb.transform.localScale.z);
    jumpCount = DefaultJumpCount;
}

void Update(){

    isMoving=false;


    if(Input.GetKey(KeyCode.RightArrow) || (buttonRight == true)){

        isMoving=true;
        rb.velocity = new Vector2(Speed, rb.velocity.y);
       
        // anim.SetBool("isRunning", true);
        
    }
    
    if(Input.GetKey(KeyCode.LeftArrow) || (buttonLeft == true)){
        isMoving=true;
        rb.velocity = new Vector2(-Speed, rb.velocity.y);
     
        // anim.SetBool("isRunning", true);
    }
    
    anim.SetBool("isRunning", isMoving);
            if (rb.velocity.x > 0.01)
            {
                
                transform.localScale = new Vector3(DefaultScale.x, DefaultScale.y, DefaultScale.z);
            }
            else if (rb.velocity.x < -0.01)
            {
                transform.localScale = new Vector3(-DefaultScale.x, DefaultScale.y, DefaultScale.z);
            }


    anim.SetBool("isGround", isGrounded);

    if(Input.GetKeyDown(KeyCode.DownArrow) || (buttonPullLever == true)){

            Debug.Log("Narik Tuas");
            // anim.SetTrigger("isPullLever");
    }


  
}



void OnCollisionEnter2D(Collision2D col){



    if(col.gameObject.tag == "Ground"){

        isGrounded = true;
        jumpCount = DefaultJumpCount;


        

    }
    
}


public void Button_Left(){

    
    buttonLeft = true;
    
}
public void Button_LeftReleased(){

    buttonLeft = false;
}
public void Button_Right(){

    buttonRight = true;
}

public void Button_RightReleased(){
    buttonRight = false;

}

public void Button_Up(){
    buttonUp = true;

}
public void Button_UpReleased(){
    buttonUp = false;

}
public void Button_Down(){
    buttonDown = true;

}
public void Button_DownReleased(){
    buttonDown = false;

}

public void Button_Jump(){


    if (jumpCount >0){

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            anim.SetTrigger("isJumping");
            isGrounded = false;
            jumpCount -= 1;

    }

}
public void Button_JumpReleased(){
    buttonJump = false;

}

public void Button_PullLever(){


    // if(pressButtonPullLever < 1){

    //     pressButtonPullLever += Time.deltaTime;
    //     buttonPullLever = true;
    // }

    // if(pressButtonPullLever > 1){

    //     buttonPullLever = false;
    // }

    anim.SetTrigger("isPullLever");



}

public void Button_PullLeverReleased(){ 

    buttonPullLever = false;

}





}


