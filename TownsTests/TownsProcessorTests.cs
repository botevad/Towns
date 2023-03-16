using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]
        public void Test_ExecuteCommand_InvalidCommand() 
        {
            var townProcessor = new TownsProcessor();

            var actual = townProcessor.ExecuteCommand("CREATE Varna");

            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(1));
        }
    }
}
