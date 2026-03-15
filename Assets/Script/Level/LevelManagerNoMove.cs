using UnityEngine;

public class LevelManagerNoMove : LevelManager
{
    protected override void Update()
    {
        base.Update();
        PlayerController.instance.rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
