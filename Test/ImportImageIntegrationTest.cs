﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Controller;
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
            // INSTANTIATE fakeGalleryView:

            //Mock mockController = new Mock<Controller.Controller>();

            //mockController.Setup()
            #endregion

            #region ACT
            // FIRE UpdateImageListCommand:
            _fakeGalleryView.ImportButtonPressed();
            #endregion

            #region ASSERT
            // CHECK that the collection in the EventArgs is a List of Images and only contains 1 element:
            if(e.ImageList is List<Image> && e.ImageList.count == 1)
            {
                // SET testPassed to true:
                testPassed = true;
            }

            Assert.IsTrue(testPassed);
            #endregion

        }


    }
    
    
}