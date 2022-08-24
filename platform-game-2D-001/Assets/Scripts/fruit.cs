using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;
    // Start is called before the first frame update
    void Start()
    {   
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D colideFruit)
    {
        // When collision the player, then "if" it will be executed
        if(colideFruit.gameObject.tag == "Player")
        {
            //After that, when the player crashes into the banana, the sprite, and the bump circle will be disabled.

            //Animation of the collect it will be actived
            // finally, object (banana) it will be destroyed
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            Destroy(gameObject, 0.2f);
    }
    }
}
