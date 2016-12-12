using UnityEngine;
using System.Collections;

public class PlayerInputHandler : MonoBehaviour {


    [SerializeField]
    MoveCommand moveCommand;

    public PlayerCommand InputHander()
    {

        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
        {
            return moveCommand;
        }
        return null;
    }

}
