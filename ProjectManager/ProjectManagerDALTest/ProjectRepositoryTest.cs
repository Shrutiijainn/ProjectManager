using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectManagerDAL;

namespace ProjectManagerDALTest
{
    [TestFixture]
    class ProjectRepositoryTest
    {
        IRepository<Project> repo;
        [SetUp]
        public void SetUp()
        {
            repo = new ProjectRepository();
        }
        public void CleanUp()
        {
            repo.Dispose();
        }
        [Test]
        public void GetAllTest()
        {
            var ActualCount = repo.GetAll().Count;
            var ExpectedCount = 0;
            Assert.AreEqual(ExpectedCount, ActualCount);
        }
        //[Test]
        //public void FindTest()
        //{
        //    var Obj = repo.Find(1);
        //    Assert.IsNotNull(Obj);
        //    Assert.IsInstanceOf<Project>(Obj);
        //}
        [Test]
        public void FindReturnNullTest()
        {
            var Obj = repo.Find(0);
            Assert.IsNull(Obj);
        }
    }
}