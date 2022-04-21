//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Drawing;

namespace Test
{
    /// <summary>
    /// UNIT TEST Class for Model
    /// </summary>
    [TestClass]
    public class ModelTest
    {
        /// <summary>
        /// TEST passing an ISubscriber object into the Model's "Subscribe" method.  Test is passed if the model's subscribers list contains the ISubscriber after call.
        /// </summary>
        [TestMethod]
        public void TestSubscribeViewToModel()
        {
            #region ARRANGE

            // SET testPassed to false
            bool testPassed = false;

            // INSTANTIATE a new Model
            Model.Model model = new Model.Model();

            // INSTANTIATE a Mock ISubscriber
            Mock mockGalleryView = new Mock<Library.ISubscriber>();

            #endregion ARRANGE

            #region ACT

            // CALL Subscribe and pass in the mock gallery view
            model.Subscribe(mockGalleryView as Library.ISubscriber);

            #endregion ACT

            #region ASSERT

            // IF the subscribers list in model contains the mock gallery view
            if (model.Subscribers.Contains(mockGalleryView as Library.ISubscriber))
            {
                // SET testPassed to 'true':
                testPassed = true;
            }

            // ASSERT that testPassed is true
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        ///  TEST calling LoadImage to load an image from path, then calling GetThumbnails to return a list of thumbnails.  Test passed if list returns contains the correct number of elements and they are the correct size.
        /// </summary>
        [TestMethod]
        public void TestThumbnailCollectionReturn()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // Create a new image list that will be injected into _imageStorage:
            string goodPath = "../../../TestAssets/TestImage";

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // LOAD an Image using model and pass it a good path:
            model.ImageStorage.LoadImage(goodPath);

            #endregion ARRANGE

            #region ACT

            // TRY to retrieve the thumbnail collection from the Model:
            List<Image> thumbs = model.GetThumbnails();

            #endregion ACT

            #region ASSERT

            // IF the list contains one image, and it's size is 128x128
            if (thumbs.Count == 1 && thumbs[0].Size == new Size(128, 128))
            {
                // SET testpassed to true
                testPassed = true;
            }

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustBrightnessBadParams method, and pass bad params. Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustBrightnessBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustBrightness method with bad param values
            try
            {
                model.AdjustBrightness(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustBrightnessBadParams method, and pass good params. Test passed if InvalidParameterException is NOT thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustBrightnessGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustBrightness method with good param values
            try
            {
                model.AdjustBrightness(50);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        ///  TEST calling TestAdjustContrastBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustContrastBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustContrast method with bad param values
            try
            {
                model.AdjustContrast(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustContrastBadParams method, and pass good params. Test passed if InvalidParameterException is NOT thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustContrastGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustContrast method with good param values:
            try
            {
                model.AdjustContrast(50);
            }

            // CATCH the InvalidParameterException if thrown:
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustSaturationBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustSaturationBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustSaturation method with bad param values
            try
            {
                model.AdjustSaturation(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustSaturationGoodParams method, and pass good params. Test passed if InvalidParameterException is NOT thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustSaturationGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustSaturation method with good param values:
            try
            {
                model.AdjustSaturation(50);
            }

            // CATCH the InvalidParameterException if thrown:
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustScaleBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustScaleBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustScale method with bad param values
            try
            {
                model.AdjustScale(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestAdjustScaleGoodParams method, and pass good params. Test passed if InvalidParameterException is NOT thrown.
        /// </summary>
        [TestMethod]
        public void TestAdjustScaleGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the AdjustScale method with good param values:
            try
            {
                model.AdjustScale(50);
            }

            // CATCH the InvalidParameterException if thrown:
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestCropImageBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestCropImageBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the CropImage method with bad param values
            try
            {
                model.CropImage(-200, -200, -200, -200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestCropImageBadParams method, and pass good params.  Test passed if no exceptions are thrown.
        /// </summary>
        [TestMethod]
        public void TestCropImageGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "true":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the CropImage method with bad param values
            try
            {
                model.CropImage(1, 1, 1, 1);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to false
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestApplyFilterBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the ApplyFilter method with bad param values
            try
            {
                model.ApplyFilter(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestApplyFilterBadParams method, and pass good params.  Test passed if no exceptions are thrown.
        /// </summary>
        [TestMethod]
        public void TestApplyFilterGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "true":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the ApplyFilter method with good param values
            try
            {
                model.ApplyFilter(0);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to false
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestRotateImageBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestRotateImageBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the RotateImage method with bad param values
            try
            {
                model.RotateImage(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling RotateImage method, and pass good params.  Test passed if no exceptions are thrown.
        /// </summary>
        [TestMethod]
        public void TestRotateImageGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "true":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the RotateImage method with good param values
            try
            {
                model.RotateImage(1);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to false
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestFlipImageBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestFlipImageBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            #endregion ARRANGE

            #region ACT

            // TRY to call the FlipImage method with bad param values
            try
            {
                model.FlipImage(-200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling FlipImage method, and pass good params.  Test passed if no exceptions are thrown.
        /// </summary>
        [TestMethod]
        public void TestFlipImageGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "true":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the FlipImage method with good param values
            try
            {
                model.FlipImage(1);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to false
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling TestOpenImageBadParams method, and pass bad params.  Test passed if InvalidParameterException is thrown.
        /// </summary>
        [TestMethod]
        public void TestOpenImageBadParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "false":
            bool testPassed = false;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            #endregion ARRANGE

            #region ACT

            // TRY to call the OpenImage method with bad param values
            try
            {
                model.OpenImage(200);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to true
                testPassed = true;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST calling OpenImage method, and pass good params.  Test passed if no exception is thrown.
        /// </summary>
        [TestMethod]
        public void TestOpenImageGoodParams()
        {
            #region ARRANGE

            // DECLARE a bool, call it "testPassed" and set it to "true":
            bool testPassed = true;

            // CREATE a new Model, call it "model":
            Model.Model model = new Model.Model();

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL LoadImage and pass a good image path
            model.LoadImage("../../../TestAssets/TestImage");

            // CALL OpenImage to open the image at the first position in the list
            model.OpenImage(0);

            #endregion ARRANGE

            #region ACT

            // TRY to call the OpenImage method with good param values
            try
            {
                model.OpenImage(0);
            }

            // CATCH the InvalidParameterException if thrown
            catch (InvalidParameterException)
            {
                // SET testpassed to false
                testPassed = false;
            }

            #endregion ACT

            #region ASSERT

            // ASSERT "testPassed" is true:
            Assert.IsTrue(testPassed);

            #endregion ASSERT
        }
    }
}