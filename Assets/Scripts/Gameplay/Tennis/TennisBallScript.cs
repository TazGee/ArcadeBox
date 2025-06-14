using UnityEngine;

public class TennisBallScript : MonoBehaviour
{

    bool served;
    public float ballSpeed;
    public float x, y;

    void Start()
    {
        served = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !served) Serve();

        if (!served) return;

        x = Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180f);
        y = Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180f);

        transform.localPosition += new Vector3(x * ballSpeed * Time.deltaTime, y * ballSpeed * Time.deltaTime, 0f);
    }

    public void Serve()
    {
        int i = Random.Range(1, 3);
        float angle;
        if (i == 1)
        {
            angle = Random.Range(45f, 135f);
        }
        else
        {
            angle = Random.Range(225f, 315f);
        }
        transform.eulerAngles = new Vector3(0f, 0f, angle);
        served = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TennisBorders")
        {
            if(x > 0)
                transform.eulerAngles = new Vector3(0f, 0f, Mathf.Acos(-y) / Mathf.PI * 180f);
            else
                transform.eulerAngles = new Vector3(0f, 0f, Mathf.Acos(-y) / Mathf.PI * -180f);
        }
        else if(collision.gameObject.tag == "Player")
        {
            float y = transform.position.y - collision.transform.position.y;
            float height = collision.bounds.size.y;

            float normalized = y / (height / 2f);
            normalized = Mathf.Clamp(normalized, -1f, 1f);

            float maxAngle = 60f;
            float bounceAngle;

            if (transform.position.x < collision.transform.position.x)
            { bounceAngle = normalized * maxAngle; bounceAngle += 270f; }
            else
            { bounceAngle = normalized * maxAngle * -1; bounceAngle += 90f; }

            transform.eulerAngles = new Vector3(0f, 0f, bounceAngle);
        }
    }
}
