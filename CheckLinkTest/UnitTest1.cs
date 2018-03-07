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
        public void WithoutHttpAtStartOfLink_NoLinks()
        {

            var links = LinkChecker.GetLinks("<a href=\"google.com\" />");
            
            Assert.Empty(links);
            //Assert.Equal("google.com", links.First());
        }

        [Fact]
        public void WithHttpAtStartOfLink_LinkParses()
        {

            var links = LinkChecker.GetLinks("<a href=\"http://google.com\" />");

            Assert.Single(links);
            Assert.Equal("http://google.com", links.First());
        }
    }
}
