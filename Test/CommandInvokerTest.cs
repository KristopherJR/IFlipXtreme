using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    /// <summary>
    /// Summary description for CommandInvokerTest
    /// </summary>
    [TestClass]
    public class CommandInvokerTest
    {
        // DEFINE a variable to hold the result of TestCommandsExecuting(), adjusted by
        private bool TestCommandsExecutingTestPassed = false;

        [TestMethod]
        public void TestCommandsExecuting()
        {
            #region ARRANGE
            // DECLARE an ICommandInvoker, call it "testCommandInvoker":
            ICommandInvoker testCommandInvoker = new Controller.CommandInvoker();
            // DECLARE an ICommand, call it "testCommand" and pass the "TestCommandsExecutingDelegateMethod" pointer:
            Library.ICommand testCommand = new Library.Command(TestCommandsExecutingDelegateMethod);
            #endregion

            #region ACT
            // EXECUTE the "testCommand" using the "testCommandInvoker":
            testCommandInvoker.Execute(testCommand);
            #endregion

            #region ASSERT
            // ASSERT "TestCommandsExecutingTestPassed":
            Assert.IsTrue(TestCommandsExecutingTestPassed);
            #endregion
        }
        /// <summary>
        /// Called from the "testCommandInvoker" in "TestCommandsExecuting()". If this is called the CommandInvoker is properly executing Command Objects.
        /// </summary>
        private void TestCommandsExecutingDelegateMethod()
        {
            // SET TestCommandsExecutingTestPassed to "true":
            TestCommandsExecutingTestPassed = true;
        }
    }
}
