using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScoreDistance
{
    

    
    [UnityTest]
    public IEnumerator TestScoreDistanceWithEnumeratorPasses()
    {
        GameObject tmp = new GameObject();
        //tmp.AddComponent<>();
       // tmp.GetComponent<UnitTestExample>().MoveTo(new Vector3(2, 7, 9));
        yield return new WaitForSeconds(0.1f);
       // Assert.AreEqual(new Vector3(2, 7, 9), tmp.transform.position);
    }
}
