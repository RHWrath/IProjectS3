using Logic;

namespace Backend_Test
{
    [TestClass]
    public class MenuUnitTest
    {
        [TestMethod]
        public void GetMenuItem()
        {
            //arrange
            MockMenuDAL mockDAL = new MockMenuDAL();
            MenuCardLogic TestCLogic = new MenuCardLogic(mockDAL);

            //act
            var TestResult = TestCLogic.GetMenuCards();

            //assert
            Assert.AreEqual(1, TestResult.Count());
            var MenuCard = TestResult.First();
            Assert.AreEqual("Coffee", MenuCard.Name);
            Assert.AreEqual("empty", MenuCard.Description);

        }
    }
}