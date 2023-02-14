using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class ExtendedDatabase
    {
        private Person[] _persons;

        private int _count;

        public ExtendedDatabase(params Person[] persons)
        {
            _persons = new Person[16];
            AddRange(persons);
        }

        public int Count
        {
            get { return _count; }
        }

        private void AddRange(Person[] data)
        {
            if (data.Length > 16)
            {
                throw new ArgumentException("Provided data length should be in range [0..16]!");
            }

            for (int i = 0; i < data.Length; i++)
            {
                Add(data[i]);
            }

            _count = data.Length;
        }

        public void Add(Person person)
        {
            if (_count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            if (_persons.Any(p => p?.UserName == person.UserName))
            {
                throw new InvalidOperationException("There is already user with _username!");
            }

            if (_persons.Any(p => p?.Id == person.Id))
            {
                throw new InvalidOperationException("There is already user with _Id!");
            }

            _persons[_count] = person;
            _count++;
        }

        public void Remove()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            _count--;
            _persons[_count] = null;
        }

        public Person FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username parameter is null!");
            }

            if (_persons.Any(p => p?.UserName == name) == false)
            {
                throw new InvalidOperationException("No user is present by _username!");
            }

            Person person = _persons.First(p => p.UserName == name);
            return person;
        }


        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be a positive number!");
            }

            if (_persons.Any(p => p?.Id == id) == false)
            {
                throw new InvalidOperationException("No user is present by _ID!");
            }

            Person person = _persons.First(p => p.Id == id);
            return person;
        }
    }
}
