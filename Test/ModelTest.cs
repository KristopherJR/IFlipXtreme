using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void TestSubscribeViewToModel()
        {
            #region ARRANGE
            bool testPassed = false;
            Model.Model model = new Model.Model();

            Mock mockGalleryView = new Mock<Library.ISubscriber>();


            #endregion

            #region ACT
            model.Subscribe(mockGalleryView as Library.ISubscriber);
            #endregion

            #region ASSERT
            if (model.Subscribers.Contains(mockGalleryView as Library.ISubscriber))
            {
                testPassed = true;
            }

            Assert.IsTrue(testPassed);
            #endregion
        }

        [TestMethod]
        public void TestThumbnailCollectionReturn()
        {
            #region ARRANGE
            bool testpassed = false;
            //Create a new image list that will be injected into _imageStorage
            string goodPath = "../../../assets/OrangeFish.png";

            Model.Model model = new Model.Model();

            model.ImageStorage.LoadImage(goodPath);
            #endregion

            #region ACT
            List<Image> thumbs = model.GetThumbnails();
            #endregion

            #region ASSERT
            if (thumbs.Count == 1 && thumbs[0].Size == new Size(128, 128))
            {
                testpassed = true;
            }
            Assert.IsTrue(testpassed);
            #endregion
        }
    }
}
