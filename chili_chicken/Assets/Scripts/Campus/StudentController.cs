using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StudentController : MonoBehaviour
{
    private bool isOnGround;
    public Rigidbody studentRb;
    public Animator studentAnim;
    public float jumpForce = 30 ;
    DirectionFinder directionFinder;
    public int direction_mode;
    public Vector3 forward;
    public Vector3 right;
    public GameObject sight;
    public Camera camera;

    private bool move_lock;

    private TalkLib talkLib;
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {





        talkLib = TalkLib.GetTalkLib();
        move_lock = false;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        direction_mode = 0;
        sight = GameObject.Find("Sight");

        rotate_buffer = 5;
        isOnGround = true;
        studentRb = gameObject.GetComponent<Rigidbody>();
        studentAnim = gameObject.GetComponent<Animator>();
        directionFinder = gameObject.GetComponent<DirectionFinder>();
        forward = directionFinder.FindForward(direction_mode);
        UpdateDirection();
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("position_x"), PlayerPrefs.GetFloat("position_y"), PlayerPrefs.GetFloat("position_z"));
        //gameObject.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("euler_x"), PlayerPrefs.GetFloat("euler_y"), PlayerPrefs.GetFloat("euler_z"));
    }

    public float rotate_speed = 0.00000001f;
    public float walk_speed = 18;
    public float count1;
    public float count2;
    public float moveLimit = 30;
    public float move_speed = 2;
    public float move_state = 0;

    private int rotate_buffer = 0;
    public void LockMove(){
        move_lock = true;
    }
    public void UnlockMove(){
        move_lock = false;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        Vector3 pos = transform.position;
        try
        {
            if (pos.y < Terrain.activeTerrain.SampleHeight(transform.position) - 100.2f)
            {
                pos.y = Terrain.activeTerrain.SampleHeight(transform.position) - 100.2f;
            }
        }
        catch
        {

        }
        
        transform.position = pos;
        if(! move_lock){
            MoveControl();
        }
        GameController.CheckQuit();
        //CameraFollow();

    }
    float FixAugment()
    {
        float temp = (float)System.Math.Pow(Game.getRole().getStrength() / 80, 0.5);
        temp = System.Math.Max(temp, 0.5f);
        temp = System.Math.Min(temp, 1.5f);
        return temp;
    }
    void MoveControl(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            studentAnim.SetFloat("Speed_f", 2);
            walk_speed = 30;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            studentAnim.SetFloat("Speed_f", 0.4f);
            walk_speed = 20;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            StartCoroutine(JumpFrozen(1));
            studentRb.AddForce(Vector3.up * jumpForce * FixAugment(), ForceMode.Impulse);
            studentAnim.SetTrigger("Jump_trig");
        }
        if (Input.GetKey(KeyCode.E))
        {
            TurnRight();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            TurnLeft();
            
        }
        
        
        
        float vertical_input = Input.GetAxis("Vertical");
        
        if (vertical_input != 0)
        {
            count1 = vertical_input;
            //studentAnim.SetTrigger("Walk_Static");
            Vector3 next_position = transform.position + forward * vertical_input * walk_speed * FixAugment() * Time.deltaTime;
            if(vertical_input > 0)
            {
                transform.LookAt(next_position);
            }
            
            transform.position = next_position;
            
        }
        if (Input.GetMouseButton(1))
        {
            float mouse_x = Input.GetAxis("Mouse X");
            float mouse_y = Input.GetAxis("Mouse Y");
            if (mouse_x != 0)
            {
                if (mouse_x < 0)
                {
                    TurnLeft();
                }
                else if (mouse_x > 0)
                {
                    TurnRight();
                }
                //Vector3 next_position = transform.position - right * horizontal_input * walk_speed * Time.deltaTime;
                //transform.LookAt(next_position);
                //transform.position = next_position;
            }
            if (mouse_y != 0)
            {
                if (mouse_y < 0 && move_state + move_speed < moveLimit)
                {
                    sight.transform.rotation = Quaternion.Euler(sight.transform.rotation.eulerAngles + new Vector3(2, 0, 0));
                    move_state += move_speed;
                }
                if (mouse_y > 0 && move_state - move_speed > -moveLimit * 0.5f)
                {
                    sight.transform.rotation = Quaternion.Euler(sight.transform.rotation.eulerAngles + new Vector3(-2, 0, 0));
                    move_state -= move_speed;
                }
                // studentAnim.SetTrigger("Idle");
            }
        }
    }
    private Ray ra;
    private RaycastHit hit;
    /*
    void UserClick()
    此处可能有点问题，暂时不采用
    {
        if (Input.GetMouseButtonDown(0))
        {
            ra = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                try
                {
                    hit.collider.gameObject.GetComponent<SimpleTalkNPC>().Talk(this);
                }
                catch
                {

                }
            }
        }
    }
    */
    void CameraFollow()
    {
        camera.transform.position = transform.position - forward * 4 + Vector3.up * 2;
        camera.transform.LookAt(camera.transform.position + forward);
    }
    void TurnRight()
    {
        TurnDirection(-1);
    }
    void TurnLeft()
    {
        TurnDirection(1);
    }
    void TurnDirection(int direction)
    {
        float x = forward.x;
        float z = forward.z;
        float angle = (float)System.Math.PI * rotate_speed * Time.deltaTime * direction;
        forward.x = x * (float)System.Math.Cos(angle) - z * (float)System.Math.Sin(angle);
        forward.z = x * (float)System.Math.Sin(angle) + z * (float)System.Math.Cos(angle);
        UpdateDirection();
    }

    void UpdateDirection()
    {
        //forward = directionFinder.FindForward(direction_mode);
        right = new Vector3(forward.x, forward.y, forward.z);
        float x = right.x;
        float z = right.z;
        right.x = -z;
        right.z = x;

        transform.LookAt(transform.position + forward);
    }
    public GameObject temp;
    public float cout;
    public string ccc;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            cout += 1;
            OpenDoor openDoor = collision.gameObject.GetComponent<OpenDoor>();
            openDoor.Open();
        }
        
        else if (collision.gameObject.CompareTag("TalkNPC"))
        {
            
            temp = collision.gameObject;
            SimpleTalkNPC simpleTalkNPC = collision.gameObject.GetComponent<SimpleTalkNPC>();
            simpleTalkNPC.Talk(this);

            
        }

    }
    private IEnumerator JumpFrozen(float waitTime)
    {
        isOnGround = false;
        yield return new WaitForSeconds(waitTime);
        isOnGround = true;

    }

}
