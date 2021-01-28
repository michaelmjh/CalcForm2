using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcForm
{
    class CalcBrain
    {
        float firstNumber;
        float secondNumber;
        string operationToPerform;

        public void storeFirstNumber(float numberToStore)
        {
            firstNumber = numberToStore;
        }
        public string getFirstNumber()
        {
            return firstNumber.ToString();
        }

        public void storeSecondNumber(float numberToStore)
        {
            secondNumber = numberToStore;
        }
        public string getSecondNumber()
        {
            return secondNumber.ToString();
        }

        public void storeOperationToDo(string operationToStore)
        {
            operationToPerform = operationToStore;
        }
        public string getOperationToDo()
        {
            return operationToPerform;
        }

        public string performCalculation()
        {
            float answer = 0;
            if (operationToPerform == "+")
            {
                answer = firstNumber + secondNumber;
            }
            else if (operationToPerform == "-")
            {
                answer = firstNumber - secondNumber;
            }
            else if (operationToPerform == "*")
            {
                answer = firstNumber * secondNumber;
            }
            else  if (operationToPerform == "/")
            {
                answer = firstNumber / secondNumber;
            }
            return answer.ToString();
        }
    }
}
