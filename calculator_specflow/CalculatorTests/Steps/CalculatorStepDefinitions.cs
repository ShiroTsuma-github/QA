using TechTalk.SpecFlow;
using SDP23;
using NUnit.Framework;

namespace CalculatorTests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private Calculator calculator;
        private int _result;
        private double _delta;
        private int _numberOfSolutions;

        public CalculatorStepDefinitions(Calculator calculator)
        {
            this.calculator = calculator;
        }
        

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            calculator.x = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            calculator.y = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result, "Result is different than expected");
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = calculator.Subtract();
        }

        [When(@"I calculate delta from (.*),(.*),(.*) as coefficients of the quadratic equation")]
        public void WhenICalculateDeltaFromAsCoefficientsOfTheQuadraticEquation(double a, double b, double c)
        {
            _delta = calculator.Delta(a, b, c);
        }

        [Then(@"the equation has (.*) real number solutions")]
        public void ThenTheEquationHasRealNumberSolutions(int expectedNumberOfSolutions)
        {
            if (_delta > 0)
            {
                _numberOfSolutions = 2;
            }
            else if (_delta < 0)
            {
                _numberOfSolutions = 0;
            }
            else if (_delta == 0)
            {
                _numberOfSolutions = 1;
            }

            Assert.AreEqual(expectedNumberOfSolutions, _numberOfSolutions, "Number of real number solutions is different than expected.");
        }

    }
}
