using System;
using UnityEngine;

namespace GameTools.MessageSystem
{
    public class DelegateTutorial : MonoBehaviour
    {
        delegate void MyDelegate(int x);
        MyDelegate myDelegate;
        private void Start()
        {
            
            myDelegate = PrintNum;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                myDelegate(10);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                myDelegate -= PrintNum;
                myDelegate += PrintDoubleNum;
            }
        }

        void PrintNum(int a)
        {
            Debug.Log($"Number is {a}");
        }
        void PrintDoubleNum(int a)
        {
            Debug.Log($"Number is {a} Double it is {a * 2}");
        }
    }
}