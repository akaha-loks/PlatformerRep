using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ChangeScene end;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            end.End();
        }
    }
}
