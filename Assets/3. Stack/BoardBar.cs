using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { LEFT, CENTER, RIGHT }
    public BarType barType;

    public HanoiTower hanoiTower;
    
    public Stack<GameObject> barStack = new Stack<GameObject>();

    void OnMouseDown()
    {
        if (!HanoiTower.isSelected)
            HanoiTower.selectedDonut = OnPopRing();
        else
            PushDonut(HanoiTower.selectedDonut);
    }
    
    public bool CheckRing(GameObject pushRing)
    {
        if (barStack.Count > 0)
        {
            int peekNumber = barStack.Peek().GetComponent<Donut>().donutNumber;
            int pushNumber = pushRing.GetComponent<Donut>().donutNumber;
    
            bool result = pushNumber < peekNumber ? true : false;
            if (!result)
                Debug.Log($"넣으려는 도넛은 {pushNumber}이고, 해당 기둥의 마지막 도넛은 {peekNumber}입니다.");
            
            return result;
        }
        
        return true;
    }
    
    public void PushDonut(GameObject donut)
    {
        if (!CheckRing(donut))
            return;
        
        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;
        
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        donut.transform.position = transform.position + Vector3.up * 5f;
        barStack.Push(donut);
    }
    
    public GameObject OnPopRing()
    {
        if (barStack.Count > 0)
        {
            HanoiTower.isSelected = true;
            GameObject popObj = barStack.Pop();
            
            return popObj;
        }
    
        return null;
    }
}