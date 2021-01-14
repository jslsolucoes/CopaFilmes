using CopaFilmes.Core.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Extension
{
    [TestClass]
    public class TaskExtensionTest
    {
        [TestMethod]
        public async Task TestSelect()
        {
            var expected = "test";
            var actual = await Task.Run(() => expected).Select(response => response);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task TestSelectMany()
        {
            var expected = new List<string>() { "mock1" };
            var actual = await Task.Run(() => new MockAsync())
                            .SelectMany(response => response.many)
                            .Select(r => r);
            CollectionAssert.AreEqual(expected, actual);
        }

        class MockAsync
        {
            public Task<List<string>> many = Task.FromResult(new List<string>() { "mock1" });
        }
    }
}
