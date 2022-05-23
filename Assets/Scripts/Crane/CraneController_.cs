using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class CraneController_ : MonoBehaviour
{
    public GameObject cuerda;
    public GameObject cuerda2;
    ObiRopeCursor cursor;
    ObiRopeCursor cursor2;
    ObiRope rope;
    ObiRope rope2;

    public float minLength = 1.5f;
    public float maxLength = 13;
    public float speedCuerda = 0f;
    public float MaxspeedCuerda;
    void Start()
    {
        rope = cuerda.GetComponent<ObiRope>();
        rope2 = cuerda2.GetComponent<ObiRope>();
        cursor = cuerda.GetComponent<ObiRopeCursor>();
        cursor2 = cuerda2.GetComponent<ObiRopeCursor>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad7))   //DOWN
        {
            //estado_Cuerda = 1;

            if (rope.restLength < maxLength || rope2.restLength < maxLength)
            {
                cursor.ChangeLength(rope.restLength + speedCuerda * Time.deltaTime);
                cursor2.ChangeLength(rope2.restLength + speedCuerda * Time.deltaTime);

                //SoundManager.instanceSound_.reproducirSecondariesClip(soundCable, 1); //el 2 como parametro es el audio con cable en buen estado
            }

        }

        else if (Input.GetKey(KeyCode.Keypad8))     //UP
        {

            //estado_Cuerda = 2;

            if (rope.restLength > minLength || rope2.restLength > minLength)
            {
                cursor.ChangeLength(rope.restLength - speedCuerda * Time.deltaTime);
                cursor2.ChangeLength(rope2.restLength - speedCuerda * Time.deltaTime);
            }


        }


        else if (Input.GetKey(KeyCode.Keypad5))     //UP
        {
            cuerda.transform.position -= Vector3.right * Time.deltaTime;
            cuerda2.transform.position -= Vector3.right * Time.deltaTime;
            //estado_Cuerda = 2;
        }

        else if (Input.GetKey(KeyCode.Keypad4))     //UP
        {
            cuerda.transform.position += Vector3.right * Time.deltaTime;
            cuerda2.transform.position += Vector3.right * Time.deltaTime;
            //estado_Cuerda = 2;
        }
    }
}
