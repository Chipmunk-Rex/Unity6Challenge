using System;
using Chipmunk.Library;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IFSMEntity<EnumPlayer, Player>
{
    #region  getter
    PlayerInputReader PlayerInputReader => PlayerInputReader.Instance;
    public Animator Animator => throw new NotImplementedException();
    public bool CanChangeState => true;

    public FSMStateMachine<EnumPlayer, Player> FSMStateMachine => throw new NotImplementedException();
    #endregion
    private FSMStateMachine<EnumPlayer, Player> stateMachine;
    [SerializeField] public Animator animator;

    [SerializeField] public Rigidbody2D rigidbodyCompo;
    void OnEnable()
    {
        PlayerInputReader.OnDashEvent.AddListener(Dash);
        PlayerInputReader.OnJumpEvent.AddListener(Jump);
        PlayerInputReader.MoveValue.OnvalueChanged.AddListener(Move);
    }

    private void Move(int arg0, int arg1)
    {

    }

    private void Jump()
    {
        throw new NotImplementedException();
    }

    private void Dash()
    {
        throw new NotImplementedException();
    }

    void OnDisable()
    {

    }
}