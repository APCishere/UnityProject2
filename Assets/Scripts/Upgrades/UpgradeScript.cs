using UnityEngine;
using System.Collections.Generic;

public class UpgradeScript : MonoBehaviour
{
    public List<Transform> Dependencies = new List<Transform>();
    public List<Transform> Influences = new List<Transform>();
    public bool isUnlocked = false;
    public int upgradeID;
    //piority int>??
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshInfluences() {
        foreach (var x in Influences)
        {
            bool CorrectYLoop = true;
            //Debug.Log("1");
            foreach (var y in x.GetComponent<UpgradeScript>().Dependencies)
            {
                //Debug.Log("2");
                if(y.GetComponent<UpgradeScript>().isUnlocked != true)
                {
                    Debug.Log("Broke on Dependency" + y.name);
                    CorrectYLoop = false;
                    break;
                    
                }
                else {
                    Debug.Log("Continued on Dependency " + y.name);
                }
            }
            if(CorrectYLoop) {
                Debug.Log("Unlocked " + x.name);
                //unlock logic
            }
            
            //x.GetComponent<UpgradeScript>().PurchaseBlock(upgradeID);
            
        }
    }

}
