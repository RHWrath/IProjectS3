using Logic;

namespace Backend_Test
{
    [TestClass]
    public class CatUnitTests
    {
        [TestMethod]
        public void GetCat()
        {
            //arrange
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);

            //act
            var TestResult = TestCLogic.GetCats();

            //assert
            Assert.AreEqual(1, TestResult.Count());
            var Cat = TestResult.First();
            Assert.AreEqual("spinx", Cat.Name);
            Assert.AreEqual("empty", Cat.Description);
            Assert.AreEqual(true, mockDAL.IsActive);

        }
    }
}