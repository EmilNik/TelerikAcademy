namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<PhoneEntry> entriesSorted = new OrderedSet<PhoneEntry>();
        private Dictionary<string, PhoneEntry> entriesByName = new Dictionary<string, PhoneEntry>();
        private MultiDictionary<string, PhoneEntry> entriesByPhone = new MultiDictionary<string, PhoneEntry>(false);
        
        public int EntriesCount
        {
            get
            {
                return this.entriesByName.Count;
            }
        }

        public int PhonesCount
        {
            get
            {
                return this.entriesByPhone.Count;
            }
        }

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();

            PhoneEntry entry;
            bool flag = !this.entriesByName.TryGetValue(name2, out entry);

            if (flag)
            {
                entry = new PhoneEntry();
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>();
                this.entriesByName.Add(name2, entry);

                this.entriesSorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.entriesByPhone.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.entriesByPhone[oldent].ToList();

            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldent);
                this.entriesByPhone.Remove(oldent, entry);
                entry.PhoneNumbers.Add(newent);
                this.entriesByPhone.Add(newent, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            PhoneEntry[] list = new PhoneEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PhoneEntry entry = this.entriesSorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}
