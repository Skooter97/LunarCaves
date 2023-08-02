using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly Location");
                break;
            case "Fuel":
                Debug.Log("Fuel up");
                break;
            case "Finish":
                Debug.Log("You have landed safely.");
                break;
            default:
                Debug.Log("You crashed!");
                break;
        }
    }
}
