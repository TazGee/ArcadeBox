using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public TennisGameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TennisBall")
        {
            manager.ResetBall();
        }
    }
}
