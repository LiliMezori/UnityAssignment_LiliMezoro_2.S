using ___Workdata._Scripts.Movement.UI;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    
    private UIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        // only use find if you are sure that u only have one of that component in scene 
        uiController = FindObjectOfType <UIController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(message:"Trigger detected");

        if (other.CompareTag("Goal"))
        {
            Debug.Log(message:"Reached Goal!!!!!!!");
            uiController.GameWin();
        }

        else if (other.CompareTag("Death"))

        {
            Debug.Log(message: "reached death");
            uiController.GameLost();
        }
        else if (other.CompareTag("Coin"))
        {
            uiController.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
