using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SynelTestProject.UnitTest.DAL.Repositories
{
    [TestClass]
    public class EmployeeRepoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //NOTE!
            //Integration tests must be done here(which is not required for this particular project), because repositories have dependencies from DbContext
            //Although unit tests are also possible by abstracting DbContext,creating mock(fake) DbContext class and testing against it
            //Will be done upon request
        }
    }
}
