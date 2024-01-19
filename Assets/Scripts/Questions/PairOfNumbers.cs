using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UI;

namespace MOG.Roby
{
    public class PairOfNumbers : MonoBehaviour
    {

        [SerializeField] TMP_Text InputText;
        [SerializeField] Button AddButton;
        [SerializeField] TMP_InputField IntegerInputField;
        [SerializeField] Button Example1_Button;
        [SerializeField] Button Example2_Button;
        [SerializeField] Button Example3_Button;

        [SerializeField] Button Q1_Button;
        [SerializeField] Button Q2_Button;
        [SerializeField] Button Q3_Button;

        [SerializeField] TMP_Text Q1_result;
        [SerializeField] TMP_Text Q2_result;
        [SerializeField] TMP_Text Q3_result;


         List<int>Numbers =new List<int>();
        // Start is called before the first frame update
        void Start()
        {
            AddButton.onClick.AddListener(OnAddButtonClick);
            Example1_Button.onClick.AddListener(()=>onExampleButtonClick(new List<int> {-7, -5, 4, 5, 6 }));
            Example2_Button.onClick.AddListener(()=>onExampleButtonClick(new List<int> { -7,-3, 4, 6, 10, 15 }));
            Example3_Button.onClick.AddListener(()=>onExampleButtonClick(new List<int> { -11, 5, 6, 11 }));




        }

        private void onExampleButtonClick( List<int> ExampleList)
        {
            Numbers.Clear();
            Numbers.AddRange(ExampleList);
            InputText.text = "[ " + string.Join(", ", Numbers) + " ]";
        }

        public void OnAddButtonClick()
        {
            try
            {
                int newNum = int.Parse(IntegerInputField.text);
                Numbers.Add(newNum);
                InputText.text = "[ " + string.Join(", ", Numbers) + " ]";
                IntegerInputField.text = string.Empty;
            }
            catch (Exception msg)
            {
                print(msg.Message);
                IntegerInputField.text = string.Empty;
            }
        }




        bool IsSumZero(int[] a)
        {

            foreach (int number in a)
            {
                if (a.Contains(-number))
                {
                    return true;
                }  
            }
            return false;
        }

        static bool IsSumThreeZero(int[] a)
        {
            Array.Sort(a);
            int n = a.Length;

            for (int i = 0; i < n - 2; i++)
            {
                int first = i + 1; //-3
                int last = n - 1; // 15
                int targetSum = -a[i]; //7
                print("NumOf ForLoop : " + i);

                while (first < last)
                {
                    int currentSum = a[first] + a[last];

                    if (currentSum == targetSum)
                    {
                        print(a[i] + ", " + a[first] + ", " + a[last] );

                        return true;
                    }
                    else if (currentSum < targetSum)
                    {
                        print("first  " + a[first] + ", " + a[last]);
                        first++;
                    }
                    else
                    {
                        print("last  " + a[first] + ", " + a[last]);
                        last--;
                    }
                }
            }

            return false;
        }
    }
}
