using System;

public class TestUser
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }

    private TestUser(TestUserBuilder builder)
    {
        Username = builder.Username;
        Password = builder.Password;
        Email = builder.Email;
    }

    public class TestUserBuilder
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public TestUserBuilder SetUsername(string username)
        {
            Username = username;
            return this;
        }

        public TestUserBuilder SetPassword(string password)
        {
            Password = password;
            return this;
        }

        public TestUserBuilder SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public TestUser Build()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException("Username и Password являются обязательными полями.");
            }
            return new TestUser(this);
        }
    }
}
