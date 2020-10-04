using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : Stage
{

    public override void Stage_start()
    {
        Control.Strive = Me.Dash;
        Control.Strive += Me.Jump;
        Gamemanager.now_action = Control.Strive;
        Deadline.DestroyMethod = Deadline.Shake_it;
    }
}
