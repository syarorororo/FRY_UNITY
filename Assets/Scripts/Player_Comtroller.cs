using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Comtroller : MonoBehaviour
{
    [SerializeField]
    private float P_speed;

    private Transform P_transform;
    private CharacterController CharacterController;
    
    private Vector2 Move_Inp;
    private float Ver_velo ;
    private float Turn_Velo ;
    bool isDig = false;
    public GameObject Hole;
    public void OnMove(InputAction.CallbackContext context)
    {
        Move_Inp = context.ReadValue<Vector2>();
    }
    public void OnDig(InputValue value)
    {
        isDig = value.isPressed;
        Debug.Log("Push to Spase");
    }
    private void Awake()
    {
        P_transform = transform;
        CharacterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Vector3 P_pos = P_transform.position;
            Vector3 charaforward = transform.forward;
            Vector3 hole_pos = P_pos + charaforward;
      var move_velo = new Vector3 (Move_Inp.x*P_speed,Ver_velo,Move_Inp.y*P_speed);
      var moveDelta = move_velo*Time.deltaTime;
        CharacterController.Move(moveDelta);
        if (Move_Inp != Vector2.zero)
        {
            var targetAngleY = -Mathf.Atan2(Move_Inp.y, Move_Inp.x) * Mathf.Rad2Deg + 90;

            var angleY = Mathf.SmoothDampAngle(P_transform.eulerAngles.y, targetAngleY, ref Turn_Velo, 0.1f);

            P_transform.rotation = Quaternion.Euler(0, angleY, 0);
        }
        if(isDig)
        {
            
            Instantiate(Hole, hole_pos, Quaternion.identity);
        }
    }
}
