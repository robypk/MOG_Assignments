using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
            Q1_Button.onClick.AddListener(QuestionOne);
            Q2_Button.onClick.AddListener(QuestionTwo);
            Q3_Button.onClick.AddListener(QuestionThree);

        }

        private void QuestionOne()
        {
            Tuple<bool, int> result = IsSumTwoZero(Numbers);
            Q1_result.text = result.Item1.ToString() + ", The Number : " + result.Item2.ToString();
        }


        private void QuestionTwo()
        {
            Tuple<bool, List<int>> result = IsSumThreeZero(Numbers);
            string resultNumbers= "[ " + string.Join(", ", result.Item2) + " ]";
            Q2_result.text = result.Item1.ToString() + ", The Number : " + resultNumbers;

        }

        private void QuestionThree()
        {
            Tuple<bool, int> result1 = IsSumTwoZero(Numbers);
            Tuple<bool, List<int>> result2 = IsSumThreeZero(Numbers);
            string resultNumbers = "[ " + string.Join(", ", result2.Item2) + " ]";
            string Result1 = "Pair Sum Result : " + result1.Item1.ToString() + ", The Number : " + result1.Item2.ToString();
            string Result2 = "\nTriplet Sum Result : " + result2.Item1.ToString() + ", The Number : " + resultNumbers;
            Q3_result.text= Result1 + Result2;
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



        Tuple<bool, int> IsSumTwoZero(List<int> a)
        {
            Tuple<bool,int> result = Tuple.Create(false, 0);
            foreach (int number in a)
            {
                if (a.Contains(-number))
                {
                    result = Tuple.Create(true, number);
                    return result ;
                }  
            }
            return result;
        }


        Tuple<bool, List<int>> IsSumThreeZero(List<int> a)
        {

            Tuple<bool, List<int>> result = Tuple.Create(false, new List<int> { 0,0,0});
            a.Sort();
            int n = a.Count;

            for (int i = 0; i < n - 2; i++)
            {
                int first = i + 1; 
                int last = n - 1; 
                int currentNum = -a[i];
                print("NumOf ForLoop : " + i);

                while (first < last)
                {
                    int currentSum = a[first] + a[last];

                    if (currentSum == currentNum)
                    {
                        print(a[i] + ", " + a[first] + ", " + a[last] );
                        result = Tuple.Create(true, new List<int> { a[i], a[first], a[last] });
                        return result;
                    }
                    else if (currentSum < currentNum)
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

            return result;
        }
    }
}
