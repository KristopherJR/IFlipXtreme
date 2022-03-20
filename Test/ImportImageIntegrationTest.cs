using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.FakeClasses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Test
{
    [TestClass]
    public class ImportImageIntegrationTest
    {
        [TestMethod]
        public void TestGoodThumbnailCollectionPassedToView()
        {
            #region ARRANGE
            // DECLARE a bool, call it testPassed:
            bool testPassed = false;

            FakeController fakeController = new FakeController();

            #endregion

            #region ACT
            // FIRE UpdateImageListCommand:
            fakeController.FakeGalleryView.ImportButtonPressed();
            #endregion

            #region ASSERT
            // CHECK that the collection in the EventArgs is a List of Images and only contains 1 element:
            if(fakeController.FakeGalleryView.ImageList.Count == 1)
            {
                // SET testPassed to true:
                testPassed = true;
            }

            Assert.IsTrue(testPassed);
            #endregion

        }


    }
    
    
}
