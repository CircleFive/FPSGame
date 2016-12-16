using UnityEngine;
using System.Collections;

public class MoveCommand : PlayerCommand {


    public override void Exeute(Player player)
    {
        player.Move();
    }

}
