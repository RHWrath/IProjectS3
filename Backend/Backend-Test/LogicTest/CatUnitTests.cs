using Logic;
using Logic.Models;

namespace Backend_Test
{
    [TestClass]
    public class CatUnitTests
    {
        [TestMethod]
        [DataRow(1)]
        public void GetCat(int ID)
        {
            //arrange
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);

            //act
            var TestResult = TestCLogic.GetCatByID(ID);

            //assert
            var Cat = TestResult;
            Assert.AreEqual("sphinx", Cat.Name);
            Assert.AreEqual("empty", Cat.Description);
            Assert.AreEqual(true, mockDAL.IsActive);

        }

        [TestMethod]
        public void GetCats()
        {
            //arrange
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);
            
            //act
            List<CatModel> TestResult = TestCLogic.GetCats();
            
            //Assert
            Assert.AreEqual(true, mockDAL.IsActive);
            Assert.AreEqual(2, TestResult.Count());
            
            
        }

        [TestMethod]
        [DataRow("Henk", "Test")]
        public void CreateCat(string name, string description)
        {
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);
            
            TestCLogic.AddCat(name, description, null);
            
            Assert.AreEqual(true, mockDAL.IsActive);
            Assert.AreEqual(true, mockDAL.iscreated);
            Assert.AreEqual(3, mockDAL.Cats.Count);
            Assert.AreEqual(name, mockDAL.Cats[2].Name);
        }

        [TestMethod]
        [DataRow(1, "updated", "Test")]
        public void UpdateCat(int id, string name, string description)
        {
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);
            
            TestCLogic.UpdateCat( name, description, null, id);
            
            Assert.AreEqual(true, mockDAL.IsActive);
            Assert.AreEqual(true, mockDAL.IsUpdated);
            Assert.AreEqual("updated", mockDAL.Cats[1].Name);
        }

        [TestMethod]
        [DataRow(1)]
        public void DelCat(int ID)
        {
            MockCatDAL mockDAL = new MockCatDAL();
            CatLogic TestCLogic = new CatLogic(mockDAL);
            
            TestCLogic.DeleteCat(ID);
            
            Assert.AreEqual(true, mockDAL.IsActive);
            Assert.AreEqual(true, mockDAL.IsDeleted);
            Assert.AreEqual(1, mockDAL.Cats.Count);
        }
    }
}