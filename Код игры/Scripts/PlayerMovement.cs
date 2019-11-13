using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator ac;
    public GameManager gm;
    public BonusManager bm;
    public AudioManager AudioM;
    

    public float jumpSpeed, LaneDistance, SideSpeed, FirstLanePos;

    CapsuleCollider selfCollider;
    Rigidbody rb;

    public delegate void OnPowerupUse(BonusManager.PowerUp.Type type);
    public static event OnPowerupUse PowerUpUseEvent;

    int laneNumber = 1, lanesCount = 2;

    bool isRolling = false, wonnaJump=false, isImmortal = false;


    Vector3 ccCenterNorm = new Vector3(0, 1, 0),
            ccCenterRoll = new Vector3(0, 0.4f, 0.8f);

    Vector3 startPosition,rayPosition, rbVelocity;

    float ccHaightNorm = 2,
          ccHaightRoll = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        selfCollider = GetComponent<CapsuleCollider>();
        
        rb = GetComponent<Rigidbody>();
       
                
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, Physics.gravity.y * 3, 0), ForceMode.Acceleration);
        if(wonnaJump && isGrounded())
        {
            ac.SetTrigger("jumping");
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            wonnaJump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        rayPosition = transform.position;
        rayPosition.y += 0.05f;
        if (isGrounded())
        {
           
            if (gm.canPlay)
            {
                if (!isRolling)
                {
                    if (Input.GetAxisRaw("Vertical") > 0)
                    {
                        wonnaJump = true;
                    }

                    else if (Input.GetAxisRaw("Vertical") < 0)
                    {
                        StartCoroutine(DoRoll());
                    }
                }
            }
        }
       
        CheckInput();
        Vector3 newPos = transform.position;
        newPos.z = Mathf.Lerp(newPos.z, FirstLanePos + (laneNumber*LaneDistance), Time.deltaTime*SideSpeed);
        transform.position = newPos;

       
    }

    void CheckInput()
    {
        int sign = 0;
        if (!gm.canPlay || isRolling)
            return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            sign = -1;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            sign = 1;
        else
            return;

        laneNumber += sign;
        laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
    }

    bool isGrounded()
    {
        return Physics.Raycast(rayPosition, Vector3.down, 0.08f);
    }

    public void Pause()
    {
        rbVelocity = rb.velocity;
        rb.isKinematic = true;
        ac.speed = 0;
    }

    public void UnPause()
    {
        rb.isKinematic = false;
        rb.velocity = rbVelocity;
        ac.speed = 1;
    }

    public void Respawn()
    {
        StopAllCoroutines();
        isImmortal = false;
        isRolling = false;
        wonnaJump = false;
        stopRolling();
    }
    IEnumerator DoRoll()
    {
        float rollDuration = 0.8f;
        isRolling = true;
        ac.SetBool("rolling", true);

        selfCollider.center = ccCenterRoll;
        selfCollider.height = ccHaightRoll;
        while(rollDuration>0)
        {
            if(gm.canPlay)
            rollDuration -= Time.deltaTime;
            yield return null;
        }

        stopRolling();
    }
    private void stopRolling()
    {
        isRolling = false;
        ac.SetBool("rolling", false);
        selfCollider.center = ccCenterNorm;
        selfCollider.height = ccHaightNorm;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Trap") || !gm.canPlay)
            return;
        if (isImmortal)
        {
            collision.collider.isTrigger = true;
            return;
        }
        StartCoroutine(Death());
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Gem":
                gm.addGems(1);
                AudioM.PlayGemEffect();
                break;

            case "Star":
                PowerUpUseEvent(BonusManager.PowerUp.Type.MUILTIPLIER);
                break;

            case "Heart":
                PowerUpUseEvent(BonusManager.PowerUp.Type.IMMORTALITY);
                break;

            case "Biggem":
                PowerUpUseEvent(BonusManager.PowerUp.Type.GEMSEVERYWHERE);
                break;

            default: return;
        }

        Destroy(other.gameObject);
    }
    IEnumerator Death()
    {
        gm.canPlay = false;
        bm.ResetAllPowerUps();
        ac.SetTrigger("death");
        yield return new WaitForSeconds(2);
        ac.ResetTrigger("death");
        gm.updData();
        gm.showResult();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        laneNumber = 1;
    }

    public void ImmortalityOff()
    {
        isImmortal = false;
    }

    public void ImmortalityOn()
    {
        isImmortal = true;
    }


}
