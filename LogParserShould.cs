using Challenge.Utilities.LogParser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge.Utilities.LogParser.Tests
{
    [TestClass]
    public class LogParserShould
    {
        [TestMethod()]
        public void RejectAnInvalidPath()
        {
            var lp = new LogParser();

            string LogPath = @"C:\Temp\programming-task-example-data.invalid";

            try
            {
                lp.ParseLogFile(LogPath);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Test passed
            }
        }

        [TestMethod()]
        public void AcceptAValidPath()
        {
            var lp = new LogParser();

            string LogPath = @"C:\Temp\programming-task-example-data.log";

            try
            {
                lp.ParseLogFile(LogPath);
                //Test passed
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void HaveZeroIpAddressesWhenInitialised()
        {
            var lp = new LogParser();

            Assert.AreEqual(0, lp.TotalUniqueIpAddresses());

        }

        [TestMethod()]
        public void ReturnOneOrMoreUniqueAddresses()
        {
            var lp = new LogParser();

            string LogPath = @"C:\Temp\programming-task-example-data.log";

            try
            {
                lp.ParseLogFile(LogPath);
                Assert.AreNotEqual(0, lp.TotalUniqueIpAddresses());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void Return3Addresses()
        {
            var lp = new LogParser();

            string LogPath = @"C:\Temp\programming-task-example-data.log";

            try
            {
                lp.ParseLogFile(LogPath);

                List<LogItemTotal> totalAddressList = lp.GetTopIpAddresses(3);
                Assert.AreEqual(3, totalAddressList.Count);

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public void Return2Urls()
        {
            var lp = new LogParser();

            string LogPath = @"C:\Temp\programming-task-example-data.log";

            try
            {
                lp.ParseLogFile(LogPath);
                List<LogItemTotal> totalUrlList = lp.GetTopUrls(2);

                Assert.AreEqual(2, totalUrlList.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
    }
}
