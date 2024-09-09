using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{

    #region Singleton

    private static Platform _instance;

    public static Platform Instance => _instance;

    public bool IsTransforming { get; set; }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    private float _move;
    private SpriteRenderer _sr;
    private BoxCollider2D _bCol;
    private Rigidbody2D _rb;

    [SerializeField]
    [Range(10f, 100f)]
    private float _speed = 20f;

    public float extendShrinkDuration = 70;
    public float platformWidth = 8;
    public float platformHeight = 0.9f;

    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        _sr = GetComponent<SpriteRenderer>();
        _bCol = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        MovePlatform();
    }

    private void MovePlatform()
    {
        _rb.velocity = new Vector2(_speed * _move, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.transform.position.y);

            ballRb.velocity = Vector2.zero;

            float difference = (paddleCenter.x - hitPoint.x) * (8 / platformWidth);

            // if ball fall to left left of platform
            if (hitPoint.x < paddleCenter.x)
            {
                if (hitPoint.y < paddleCenter.y)
                    ballRb.AddForce(-new Vector2(-(Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
                else
                    ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
            }
            // if ball fall to left right of platform
            else
            {
                if (hitPoint.y < paddleCenter.y)
                    ballRb.AddForce(-new Vector2((Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
                else
                    ballRb.AddForce(new Vector2((Mathf.Abs(difference * 200)), BallManager.Instance.initialBallSpeed));
            }
        }
    }

    public void StartWidthAnimation(float newWidth)
    {
        StartCoroutine(AnimatePlatformWigth(newWidth));
    }

    public IEnumerator AnimatePlatformWigth(float width)
    {
        this.IsTransforming = true;
        this.StartCoroutine(ResetPlatformWidth(this.extendShrinkDuration));

        if (width > this._sr.size.x)
        {
            float currentWidth = this._sr.size.x;
            while (currentWidth < width)
            {
                currentWidth += Time.deltaTime * 7;
                this._sr.size = new Vector2(currentWidth, platformHeight);
                _bCol.size = new Vector2(currentWidth, platformHeight);
                yield return null;
            }
        }
        else
        {
            float currentWidth = this._sr.size.x;
            while (currentWidth > width) 
            {
                currentWidth -= Time.deltaTime * 7;
                this._sr.size = new Vector2(currentWidth, platformHeight);
                _bCol.size = new Vector2(currentWidth, platformHeight);
                yield return null;
            }
        }
        this.IsTransforming = false;
    }

    private IEnumerator ResetPlatformWidth(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.StartWidthAnimation(this.platformWidth);
    }
}
