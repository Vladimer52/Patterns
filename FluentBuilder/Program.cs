using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            User Tom = new UserBuilder().SetName("tom").SetAge(23).SetCompany("Microsoft").Build();
            User alice = User.CreateBuilder().SetName("Alice").SetAge(25).IsMaried;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public bool IsMaried { get; set; }

       public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }

    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }
        public UserBuilder SetAge(int age)
        {
            user.Age = age;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            user.Company = company;
            return this;
        }
         public UserBuilder IsMaried
        {
            get
            {
                user.IsMaried = true;
                return this;
            }
        }

        public static implicit operator User(UserBuilder builder)
        {
            return builder.user;
        }

        public User Build()
        {
            return user;
        }
    }
}
