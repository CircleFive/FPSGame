using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour {

    [SerializeField]
    PlayerInputHandler playerInputHandler;

    [SerializeField]
    Player player;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        PlayerCommand playerCommand = playerInputHandler.InputHander();

        //移動したのであればインスペクターで指定したオブジェクトで実行する
        if (playerCommand != null)
        {
            playerCommand.Exeute(player);
        }
        player.Direction();
    }
}
