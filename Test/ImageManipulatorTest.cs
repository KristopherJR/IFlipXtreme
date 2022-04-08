using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Test
{
    /// <summary>
    /// Summary description for ImageManipulatorTest
    /// </summary>
    [TestClass]
    public class ImageManipulatorTest
    {
        [TestMethod]
        public void ResizeImageTest()
        {
            #region ARRANGE
            bool testPassed = false;
            Size newSize = new Size(100, 100);

            FakeImageManipulator fakeImageManipulator = new FakeImageManipulator();
            Image testImage = new Bitmap(50, 50);
            #endregion

            #region ACT
            testImage = fakeImageManipulator.Resize(testImage, newSize);
            #endregion

            #region ASSERT
            if(testImage.Size == newSize)
            {
                testPassed = true;
            }

            Assert.IsTrue(testPassed);
            #endregion
        }
    }
}
