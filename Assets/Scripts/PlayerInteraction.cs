using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("Trigger");
        if (Input.GetKeyDown(KeyCode.E))
        {
            // UI part
            Debug.Log("activate");
        }
    }
}
