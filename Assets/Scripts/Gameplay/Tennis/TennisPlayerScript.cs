using UnityEngine;

public class TennisPlayerScript : MonoBehaviour
{
    // - Atributi klase - //
    public bool controlable = false;
    public bool leftPlayer;
    public float speed;
    public float maxHeight;
    int direction;

    // - Metode klase - //
    void Update()
    {
        if (!controlable) return;

        direction = 0; //Vracanje smera na 0

        if(leftPlayer) //Igrac broj 1
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)) //Gore
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) //Dole
            {
                direction = -1;
            }
        }
        else //Igrac broj 2
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow)) //Gore
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) //Dole
            {
                direction = -1;
            }
        }

        //Pomeranje reketa
        transform.position += new Vector3(0f, speed * Time.deltaTime * direction, 0f);

        //Vracanje reketa na adekvatnu visinu ukoliko ispadne iz +-maxHeigh zone kretanja
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -maxHeight, maxHeight), transform.position.z); 
    }
}
