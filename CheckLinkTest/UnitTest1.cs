using CheckLinkConsole;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace CheckLinkTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var links = LinkChecker.GetLinks("<a href=\"google.com\" />");
            String x = "x";

            //Assert.Single(links);
            //Assert.Equal("google.com", links.First());
        }
    }
}
