using System.Linq;
using UnityEngine;

public class InterestPointsDatabase : MonoBehaviour {
    public InterestPointData[] interestPoints;
    public InterestPointData[] restaurants;
    public bool autoFindFromInterestPoints = true;

    private void Awake() {
        AutoRetrieveFromInterestPoints();
    }


    void AutoRetrieveFromInterestPoints() {
        if (!autoFindFromInterestPoints)  return;
        interestPoints = FindObjectsOfType<InterestPoint>(true).Select(x => x.establishment).Where(x=>x.type != InterestPointData.InterestPointType.CONTROL).ToArray();
    }

    private void OnValidate() {
        AutoRetrieveFromInterestPoints();
    }
}