﻿using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class LifeSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    private Family _lifeSystemGO = FamilyManager.getFamily(
        new AllOfComponents(typeof(Attack), typeof(Life), typeof(Triggered2D)) , new NoneOfComponents(typeof(Bacterie)));



    protected override void onPause(int currentFrame) {

    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in _lifeSystemGO)
        {
            Triggered2D t2d = go.GetComponent<Triggered2D>();

            if (t2d != null) {
                foreach (GameObject target in t2d.Targets)
                {
                    if (target.GetComponent<Life>() != null)
                    {

                        //
                        target.GetComponent<Life>().life -= go.GetComponent<Attack>().attack;
                        go.GetComponent<Life>().life -= target.GetComponent<Attack>().attack;



                        if (target.GetComponent<Life>().life <= 0)
                        {
                            GameObjectManager.destroyGameObject(target);

                        }
                    }
                }
                if (go.GetComponent<Life>().life <= 0)
                {
                    GameObjectManager.destroyGameObject(go);
                }
            }

        }


    }
}