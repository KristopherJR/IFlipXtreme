//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Test
{
    /// <summary>
    /// ImageManipulatorTest.
    /// 
    /// Tests the isolated functionality of ImageManipulator.
    /// </summary>
    [TestClass]
    public class ImageManipulatorTest
    {
        /// <summary>
        /// ResizeImageTest: Tests functionality when resizing an Image.
        /// </summary>
        [TestMethod]
        public void ResizeImageTest()
        {
            #region ARRANGE
            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;
            // DECLARE a new Size, call it newSize and set it to 100x100:
            Size newSize = new Size(100, 100);
            // INSTANTIATE a FakeImageManipulator:
            FakeImageManipulator fakeImageManipulator = new FakeImageManipulator();
            // DECLARE an Image, call it "testImage". Set it's size to 50x50:
            Image testImage = new Bitmap(50, 50);
            #endregion

            #region ACT
            // RESIZE the testImage to the newSize:
            testImage = fakeImageManipulator.Resize(testImage, newSize);
            #endregion

            #region ASSERT
            // IF the size of the testImage equals the newSize:
            if(testImage.Size == newSize)
            {
                // SET testPassed to true:
                testPassed = true;
            }
            // ASSERT testPassed:
            Assert.IsTrue(testPassed);
            #endregion
        }
    }
}
