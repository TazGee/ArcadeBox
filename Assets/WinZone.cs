using UnityEngine;

public class WinZone : MonoBehaviour
{
    public int player = 0;
    public TennisGameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TennisBall")
        {
            manager.IncreasePlayerPoints(player);
        }
    }
}
