using Orleans.TestingHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestClusterFailRepoXunit
{
    public class TestClusterShould
    {
        [Fact]
        public void DeployWithoutAdditionalConfiguration()
        {
            var cluster = new TestCluster();
            cluster.Deploy();

            cluster.StopAllSilos();
        }

        [Fact]
        public void DeployWithAdditionalConfiguration()
        {
            var cluster = new TestCluster(
                new TestClusterOptions
                {
                    ExtendedFallbackOptions = new TestClusterOptions.FallbackOptions
                    {
                        InitialSilosCount = 1,
                        TraceToConsole = true
                    }
                }
            );

            cluster.Deploy();

            cluster.StopAllSilos();
        }
    }
}
