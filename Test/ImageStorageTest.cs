using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Drawing;
using System.IO;

namespace Test
{
    /// <summary>
    /// Summary description for ImageStorageTest
    /// </summary>
    [TestClass]
    public class ImageStorageTest
    {
        /// <summary>
        /// TEST if an image is loaded when LoadImage is passed a good path.  Test passed if an image is added to the image list.
        /// </summary>
        [TestMethod]
        public void TestLoadImageGoodPath()
        {
            #region ARRANGE
            // DECLARE an ImageStorage, call it "imageStorage":
            ImageStorage imageStorage = new ImageStorage();

            #endregion ARRANGE

            #region ACT
            // CALL LoadImage() on imageStorage and pass a good path:
            imageStorage.LoadImage("../../../TestAssets/TestImage");

            #endregion ACT

            #region ASSERT
            // TEST passes if an Image was loaded into the collection when a good path was provided:
            Assert.IsNotNull(imageStorage.ImageStore[0]);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST if an image is not loaded when LoadImage is passed a bad path.  Test passed if no image is added to the image list, and program does not crash.
        /// </summary>
        [TestMethod]
        public void TestLoadImageBadPath()
        {
            #region ARRANGE
            // DECLARE an ImageStorage, call it "imageStorage":
            ImageStorage imageStorage = new ImageStorage();

            #endregion ARRANGE

            #region ACT
            // CALL LoadImage() on imageStorage and pass a bad path:
            imageStorage.LoadImage("../../../NOT_A_REAL_PATH_HAHAHA");
   
            #endregion ACT

            #region ASSERT
            // TEST passes if no Image was loaded into the collection when a bad path was provided:
            Assert.IsTrue(imageStorage.ImageStore.Count == 0);

            #endregion ASSERT
        }

        /// <summary>
        /// TEST if an image is correctly saved to path.  Test passed if a file exists at the save path provided.
        /// </summary>
        [TestMethod]
        public void TestSaveImage()
        {
            #region ARRANGE
            // DECLARE an ImageStorage, call it "imageStorage":
            ImageStorage imageStorage = new ImageStorage();

            // DELETE the test file before creating a new one:
            File.Delete("../../../TestAssets/ThisFileShouldNotExistOutsideOfTesting");

            // ADD a new Bitmap to the ImageStore:
            imageStorage.ImageStore.Add(new Bitmap(100, 100));

            // SET the tag of the new Bitmap to the Image's path:
            imageStorage.ImageStore[0].Tag = "../../../TestAssets/ThisFileShouldNotExistOutsideOfTesting";

            #endregion ARRANGE

            #region ACT

            // CALL SaveImage and pass a new bitmap to be saved, and the position in the image list it will be saved to (0)
            imageStorage.SaveImage(new Bitmap(100, 100), 0);

            #endregion ACT

            #region ASSERT

            // ASSERT that a file exists at the test path we provided
            Assert.IsTrue(File.Exists("../../../TestAssets/ThisFileShouldNotExistOutsideOfTesting"));

            #endregion ASSERT

            #region CLEANUP

            // DELETE the test file that we just saved
            File.Delete("../../../TestAssets/ThisFileShouldNotExistOutsideOfTesting");

            #endregion CLEANUP
        }
    }
}
