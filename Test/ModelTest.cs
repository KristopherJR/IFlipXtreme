using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Test.FakeClasses;

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
            FakeModel fakeModel = new FakeModel();

            Mock fakeGalleryView = new Mock<ISubscriber>();


            #endregion

            #region ACT
            fakeModel.Subscribe(fakeGalleryView as ISubscriber);
            #endregion

            #region ASSERT
            if (fakeModel.Subscribers.Contains(fakeGalleryView as ISubscriber))
            {
                testPassed = true;
            }

            Assert.IsTrue(testPassed);
            #endregion
        }
    }
}
