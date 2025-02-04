using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Variable to keep track of the number of coins collected
    public int numberOfCoins = 0;

    // This method is called when another collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the tag "Coin"
        if (other.CompareTag("Coin"))
        {
            // Increment the coin count
            numberOfCoins++;

            // Optionally, log the updated coin count (for debugging)
            Debug.Log("Coins collected: " + numberOfCoins);

            // Optionally, destroy the coin object
            // Destroy(other.gameObject);
        }
    }
}
