//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class ModelTest
    {
        /// <summary>
        ///
        /// </summary>
        [TestMethod]
        public void TestSubscribeViewToModel()
        {
            #region ARRANGE

            //
            bool testPassed = false;

            //
            Model.Model model = new Model.Model();

            //
            Mock mockGalleryView = new Mock<Library.ISubscriber>();

            #endregion ARRANGE

            #region ACT

            //
            model.Subscribe(mockGalleryView as Library.ISubscriber);
            //

            #endregion ACT

            #region ASSERT

            //
            if (model.Subscribers.Contains(mockGalleryView as Library.ISubscriber))
            {
                //
                testPassed = true;
            }

            //
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod]
        public void TestThumbnailCollectionReturn()
        {
            #region ARRANGE

            //
            bool testpassed = false;

            // Create a new image list that will be injected into _imageStorage
            string goodPath = "../../../assets/OrangeFish.png";

            //
            Model.Model model = new Model.Model();

            //
            model.ImageStorage.LoadImage(goodPath);

            #endregion ARRANGE

            #region ACT

            //
            List<Image> thumbs = model.GetThumbnails();

            #endregion ACT

            #region ASSERT

            //
            if (thumbs.Count == 1 && thumbs[0].Size == new Size(128, 128))
            {
                //
                testpassed = true;
            }
            //
            Assert.IsTrue(testpassed);

            #endregion ASSERT
        }
    }
}