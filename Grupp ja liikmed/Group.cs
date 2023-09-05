using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    public class Group
    {
        public List<string> Members { get; } = new List<string>();
        private readonly int _maxAmount;
        private Dictionary<string, int> _membersWithAge = new Dictionary<string, int>();

        public Group(int maxAmount)
        {
            _maxAmount = maxAmount;
        }

        public bool AddMember(string member, int age)
        {
            if (Members.Contains(member) || Members.Count >= _maxAmount)
                return false;

            Members.Add(member);
            _membersWithAge[member] = age;
            return true;
        }

        public int GetMembersCount()
        {
            return Members.Count;
        }

        public bool HasMember(string member)
        {
            return Members.Contains(member);
        }

        public string GetOldestMember()
        {
            if (_membersWithAge.Count == 0)
                return "No members in the group.";

            var oldestMember = _membersWithAge.OrderByDescending(x => x.Value).First();
            return $"{oldestMember.Key} is the oldest member in his group with age {oldestMember.Value} years.";
        }
    }
}
