using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float torqueAmount = 10.0f;
    public float baseSpeed = 20.0f;
    [SerializeField] private float boostSpeed = 30.0f;
    [SerializeField] private bool canMove = true;
    public bool isGrounded;
    public float airTimePoints;
    private SurfaceEffector2D surfaceEffector2D;
    private float lastRotationZ;
    public float rotationCounter;
    public int totalRotations;
    public int totalRotationsInAir;
    private float rotationSum;
    private float previousRotation;
    public float totalAirTime;
    public float rotationWeight = 10.0f;
    public float airTimeWeight = 1.0f;
    public float timeWeight = 1.0f;

    public float playerSpeed;
    public Vector2 playerVelocity;

    public float maxVelocity = 0f;
    
    //Total Points in each round
    public float totalPoints;

    public Timer timer;

    private Rigidbody2D rb2d;

    public AudioSource snowboardSFX;
    public AudioSource bellAudioSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        previousRotation = transform.eulerAngles.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove){
            RotatePlayer();
            RespondToBoost();
            TrackRotations();
            GetPlayerVelocity();
            GetPlayerSpeed();
            
            float currentVelocityMagnitude = rb2d.velocity.magnitude;
            if (currentVelocityMagnitude > maxVelocity)
            {
                maxVelocity = currentVelocityMagnitude;
            }
            
        }
        
        // if (timer.isFinished)
        // {
            CalculateTotalPoints();

        // }
    }

    public float GetMaxVelocity()
    {
        return maxVelocity;
    }
    
    public Vector2 GetPlayerVelocity()
    {
        return rb2d.velocity;
    }

    public float GetPlayerSpeed()
    {
        return rb2d.velocity.magnitude;
    }
    
    private void CalculateTotalPoints()
    {
        
        float airTimePoints = totalAirTime * airTimeWeight;
        float rotationPoints = totalRotations * rotationWeight;
        float timePoints = timer.timeElapsed > 0 ? timeWeight / timer.timeElapsed : 0;

        totalPoints = airTimePoints + rotationPoints + timePoints;

        //
        //
        // totalPoints += rotationWeight * rotationCounter + airTimeWeight * airTimePoints;
        // rotationCounter = 0;
        //
        //
        // if (timer.isFinished)
        // {
        //     totalPoints += timeWeight * timer.timeElapsed;
        //     airTimePoints = 0;
        // }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            snowboardSFX.Play();
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            snowboardSFX.Stop();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        // 
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        } else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
        CalculateRotation();
        
    }
    private void TrackRotations()
    {
        if (!isGrounded)
        {
            float rotationDifference = transform.eulerAngles.z - lastRotationZ;
            if (rotationDifference > 180) rotationDifference -= 270f;
            if (rotationDifference < -180) rotationDifference += 270f;

            rotationCounter += Mathf.Abs(rotationDifference);

            if (Mathf.Abs(rotationCounter) >= 270f)
            {
                bellAudioSFX.Play();
                totalRotations += (int)(rotationCounter / 270f);
                rotationCounter %= 270f;
            }
        }
        else
        {
            rotationCounter = 0;
        }
    
        lastRotationZ = transform.eulerAngles.z;
    }
    
    private void CalculateRotation()
    {
        if (!isGrounded)
        {
            float currentRotation = transform.eulerAngles.z;
            float rotationDifference = Mathf.DeltaAngle(previousRotation, currentRotation);
            rotationSum += rotationDifference;
    
            totalRotationsInAir = Mathf.FloorToInt(Mathf.Abs(rotationSum) / 270f);
            previousRotation = currentRotation;

        }
        else
        {
            totalRotationsInAir = 0;
            rotationSum = 0;
            previousRotation = transform.eulerAngles.z;
        }
    }
    
}
