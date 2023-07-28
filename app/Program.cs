using System;


namespace CollectionsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("What is your name?");
            // var name = Console.ReadLine();
            // var currentDate = DateTime.Now;
            // Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
            // Console.Write($"{Environment.NewLine}Press any key to exit...");
            // Console.ReadKey(true);

            var collections = new CollectionsClass();
            // collections.ArraysFunction();

            // collections.DictionaryFunction();
            collections.ListFunction();

            Console.ReadLine();
        }
    }

    public class CollectionsClass
    {
        User _user1;
        User _user2;
        User _user3;

        public CollectionsClass()
        {
            _user1 = new User()
            {
                UserId = 1,
                FirstName = "Doan",
                LastName = "Huy"
            };

            _user2 = new User()
            {
                UserId = 2,
                FirstName = "Quang",
                LastName = "Anh"
            };

            _user3 = new User()
            {
                UserId = 3,
                FirstName = "Anh",
                LastName = "Phan"
            };
        }

        public void ListFunction()
        {
            List<User> users = new List<User>();
            users.Add(_user1);
            users.Add(_user2);
            users.Add(_user3);

            // .Contains("qu")             
            var matchUsers = users.Where(u => u.FirstName.ToLower() == "anh").ToList();
            foreach (var user in matchUsers)
            {
                Console.WriteLine($"User {user.UserId} {user.FirstName} {user.LastName}");
            }

            // var user = users.FirstOrDefault(u => u.UserId == 2);
            // Console.WriteLine($"User {user.UserId} {user.FirstName} {user.LastName}");

            // foreach(var user in users){
            //     Console.WriteLine($"User {user.UserId} {user.FirstName} {user.LastName}");
            // }
        }
        public void DictionaryFunction()
        {
            var users = new Dictionary<int, User>();
            users.Add(_user1.UserId, _user1);
            users.Add(_user2.UserId, _user2);
            users.Add(_user3.UserId, _user3);

            User user = null;
            bool isMatchFound = users.TryGetValue(200, out user);
            if (isMatchFound) Console.WriteLine($"User {user.UserId} {user.FirstName} {user.LastName}");


            // foreach(var user in users){
            // Console.WriteLine($"User {user.UserId} {user.FirstName} {user.LastName}");
            // }
        }
        public void ArraysFunction()
        {
            User[] users = new User[3];
            users[0] = _user1;
            users[1] = _user2;
            users[2] = _user3;
            for (int i = 0; i < 3; i++)
            {
                var user = users[i];
                Console.WriteLine($"User: {user.UserId} {user.FirstName} {user.LastName}");
            }
        }
    }
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}