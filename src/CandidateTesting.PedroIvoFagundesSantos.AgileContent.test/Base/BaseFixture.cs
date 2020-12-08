using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Constants;
using System.Collections.Generic;
using System.Text;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.test.Base
{
    public class BaseFixture
    {
        public char[] SplitSeparators { get; set; }
        public Dictionary<string, int> Positions;
        public StringBuilder AgoraLogBuilder;
        public BaseFixture()
        {
            SplitSeparators = new[] {'\r', '\n'};
            Positions = new Dictionary<string, int>
            {
                {LogConstants.HttpMethod, 3},
                {LogConstants.StatusCode, 1},
                {LogConstants.UriPath, 4},
                {LogConstants.TimeTaken, 6},
                {LogConstants.ResponseSize, 0},
                {LogConstants.CacheStatus, 2}
            };
            AgoraLogBuilder = new StringBuilder();
        }
    }
}