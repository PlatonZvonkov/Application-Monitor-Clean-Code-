using Xunit;
using Observing;
using System.Diagnostics;
using System.Collections.Generic;

namespace Monitor_Tests
{
    public class ProgramIntegrationTest
    {
        [Fact]              
        public void Init_GivenActual_TerminateAfterTIme()
        {
            // Arrange
            using (Process process = new Process())
            {                
                process.StartInfo.FileName = "notepad.exe";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                process.Start();

                string name = "notepad";
                int lifeTime = 1;
                int frequency = 1;
                var arg = new Argument(name, lifeTime, frequency);
                var hash = new HashSet<int>();

                // Act
                Monitor.Monitoring(arg,hash);
                process.WaitForExit();

                // Assert
                Assert.True(process.HasExited);
            }
        }
    }
}
