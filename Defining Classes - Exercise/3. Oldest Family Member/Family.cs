using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
 
namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people; //public //prop
        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person maxAgePerson = people.OrderByDescending(p => p.Age).First();
            return maxAgePerson;
        }
    }
}
