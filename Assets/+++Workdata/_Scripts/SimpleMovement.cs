using ___Workdata._Scripts.Movement.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ___Workdata._Scripts
{
    public class SimpleMovement : MonoBehaviour

    {
        [SerializeField]  private int movingSpeed = 5;
        [SerializeField]  private int jumpForce = 5;
  
        private bool b = true;
        private int i = 10;
        private float f = 4.6f;

        private string s = "hello";
        private char _character = 'c';

        private Vector3 v = new Vector3(x: 0f, y: 0f, z: 0f);
   
        private Rigidbody2D rig;

        private float movementValue;

        [SerializeField] private CanvasGroup canvasPauseMenu;
   
   
        //Variables for Groundcheck
        [SerializeField] private Transform transformGroundcheck;
        private bool isGrounded;
        [SerializeField] private LayerMask layermaskGround; 
   
   
        //for checking the facing direction
        [SerializeField] private bool isFacingRight = true;
   
   
        //is called even before start
        private void Awake()
        {
    
        }  


        // Start is called before the first frame update
        void Start()
        {
            rig = GetComponent<Rigidbody2D>();
            rig.freezeRotation = true; 
        
            canvasPauseMenu.HideCanvasGroup();
        }

    
        // Update is called once per frame
        void Update()
        {
        
        }

  
    
    

        //update for physicbased things 
        private void FixedUpdate()
        {
            // setting the velocity of the rigidbody to the input we are getting from the keyboard
            rig.velocity = new Vector2(x: movementValue*movingSpeed,rig.velocity.y);

            if (movementValue > 0 && !isFacingRight)
            {
                FlipCharacter();
            }else if (movementValue < 0 && isFacingRight)
            {
                FlipCharacter();
            }

        }

        void FlipCharacter()
        {
            // store current scale of the object
            Vector3 currentScale = transform.localScale;
            currentScale.x = currentScale.x * - 1; 
            // applying scale to the transform
            transform.localScale = currentScale;
    
            // updating the "isfacing" variable
            isFacingRight = !isFacingRight;
        }



//last function - runs when programm gets closed 
        private void OnApplicationQuit()
        {
    
        }


//if the inputaction "move is triggered 
        void OnMove(InputValue inputValue )
        {
    
            Debug.Log("move: " + inputValue.Get<float>());
            movementValue = inputValue.Get<float>();


        }


//if the inputaction "jump is triggered 
        void OnJump()
        {

            if (Physics2D.OverlapCircle(transformGroundcheck.position, 0.2f, layermaskGround))

            {
                rig.velocity = new Vector2(0,jumpForce);
            }
    
    
    
            Debug.Log("Jump");
        }

        void OnPauseMenu()
        {
            Time.timeScale = 0f;
            canvasPauseMenu.ShowCanvasGroup(); 
        }


    }
}
