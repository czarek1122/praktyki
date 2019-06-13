using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Elections
    {
        public long StartTime { get; set; }
        public string Command { get; set; }
        public int UserCount { get; set; }
        public List<string> UserIdLists { get; set; }
        public int VoteTime { get; set; }

        public Elections(int userCount, int voteTime)
        {
            VoteTime = voteTime;
            StartTime = DateTimeOffset.Now.ToUnixTimeSeconds() + VoteTime;
            Command = "następny";
            UserCount = userCount;
            UserIdLists = new List<string>();
        }
    }
}
