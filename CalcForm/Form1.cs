using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcForm
{
    public partial class Form1 : Form
    {
        bool allowArithmeticOperatorInput = false;
        bool allowEqualsInput = false;
        bool allowNumberInput = true;
        
        bool clearTextBoxOnNumberInput = false;
        bool firstNumberAlreadyInUse = false;
        
        CalcBrain calcBrain = new CalcBrain();

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateAndDisplayAnswer()
        {
            string answerAsString = calcBrain.performCalculation();
            textBox1.Text = answerAsString;
            textBox2.Text += (calcBrain.getFirstNumber() + calcBrain.getOperationToDo() + calcBrain.getSecondNumber() + "=" + answerAsString);
            textBox2.Text += Environment.NewLine;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (allowEqualsInput)
            {
                calcBrain.storeSecondNumber(float.Parse(textBox1.Text));
                calculateAndDisplayAnswer();
                allowNumberInput = false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            allowNumberInput = true;
            allowArithmeticOperatorInput = false;
            clearTextBoxOnNumberInput = false;
            firstNumberAlreadyInUse = false;
        }

// Code below gets input from + - x / buttons
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            updateArithmaticOperation("+");
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            updateArithmaticOperation("-");
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            updateArithmaticOperation("*");
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            updateArithmaticOperation("/");
        }

        //
        private void updateArithmaticOperation(string operation)
        {
            // Check if user is allowed to enter arithmetic operator
            if(allowArithmeticOperatorInput)
            {
                // If first number has been entered already, perform calculation
                if (firstNumberAlreadyInUse)
                {
                    calculateAndDisplayAnswer();
                }
                
                // Store operation to carry out and number
                calcBrain.storeOperationToDo(operation);
                calcBrain.storeFirstNumber(float.Parse(textBox1.Text));
                firstNumberAlreadyInUse = true;
                

                // Allow only numbers to be entered next and clear text field on next button press
                allowArithmeticOperatorInput = false;
                allowEqualsInput = false;
                allowNumberInput = true;
                clearTextBoxOnNumberInput = true; 
            }
        }

// Code below gets input from number button presses and displays result for user in text box
        
        // Method adds character to text box string
        private void updateTextBox(string x)
        {
            if (allowNumberInput)
            {
                clearTextBoxCheck();
                textBox1.Text += x;
            }
            allowArithmeticOperatorInput = true;
            allowEqualsInput = true;
        }

        // Clears text box when a number is entered after a selecting an arithmatic operation 
        private void clearTextBoxCheck()
        {
            if (clearTextBoxOnNumberInput)
            {
                textBox1.Text = "";
                clearTextBoxOnNumberInput = false;
            }
        }

        // Limits decimal point to only one use with each string
        private bool pointAlreadyUsedCheck()
        {
            string currentNumberInTextBox = textBox1.Text;
            char point = '.';
            bool pointAlreadyUsed = currentNumberInTextBox.Contains(point);
            return pointAlreadyUsed;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!pointAlreadyUsedCheck())
            {
                if (textBox1.Text == "")
                {
                    updateTextBox("0.");
                }
                else
                {
                    updateTextBox(".");
                } 
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            updateTextBox("0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateTextBox("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateTextBox("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateTextBox("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateTextBox("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateTextBox("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateTextBox("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            updateTextBox("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updateTextBox("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            updateTextBox("9");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
