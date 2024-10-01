using UnityEngine;

public class GetPotions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PotionsSpeed"))
            other.GetComponent<Potions>().SpeedUp();

        if(other.CompareTag("PotionsJump"))
            other.GetComponent<Potions>().JumpUp();

        if(other.CompareTag("PotionsHPUp"))
            other.GetComponent<Potions>().HPUp();
    }
}
