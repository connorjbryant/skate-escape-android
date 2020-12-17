using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PermanentUI : MonoBehaviour
{
    //player stats
    public int coins = 0;
    public int health = 5;
    public float speed = 7f;
    public float jumpForce = 9f;
    //public float gravityScale = 1f;
    //public float targetScale = 1f;
    //public float smooth = 5.0f;
    //public float tiltAngle = 60.0f;
    public float rotationspeed;
    public TextMeshProUGUI coinsText;
    public Text healthAmount;
    public Joystick joystick;
    public bool IsPaused;

    public GameObject PauseMenu;

    public static PermanentUI perm;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //singleton
        if (!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

        public void colorChange()
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }

    public void ScaleToTarget(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }

    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (10f * t - 15f) + 20f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        yield return null;
    }


    public void Reset()
        {
            coins = 0;
            coinsText.text = coins.ToString();
            health = 5;
            PermanentUI.perm.healthAmount.text = PermanentUI.perm.health.ToString();
            speed = 7f;
            jumpForce = 9f;
}

    public void Reset2()
    {
        //gravityScale = -10f;
        rotationspeed = 0f;
        speed = 7f;
        jumpForce = 9f;
    }


}

