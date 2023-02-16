using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SDP23;

namespace CalculatorTests.Hooks
{
    [Binding]
    class ScenarioTags
    {
        private Calculator calculator;

        public ScenarioTags(Calculator calculator)
        {
            this.calculator = calculator;
        }

        [BeforeScenario("SetFirstNumber", Order = 1)]
        public void SetNumber()
        {
            calculator.x = 50;
        }
    }
}
