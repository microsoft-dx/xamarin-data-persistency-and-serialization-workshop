
# Data persistency and serialization in Xamarin.Forms

## Xamarin.Forms Local Databases

**SQLite** is an in-process library that implements a serverless SQL database engine. Otherwise said, by using SQLite we can make data persistent in our apps, without using an on-line database.

The way to do so for a Xamarin.Forms application is to incorporate the SQLite NuGet package in our project.

In order to add the package to our project, we have to select the solution -> Manage NuGet Packages -> search SQLite-net-pcl .

![image](https://user-images.githubusercontent.com/23138335/49687923-234d0280-fb13-11e8-8204-50131f25793a.png)

 
Once we have installed the NuGet package, the next thing to do is to implement the Database in our project. Thus, we will create a new class, called ‘Database.cs’.
Since we’re using SQLite.NET Async, we need to create a SQLite Async connection. 
For our data to be persistent, we need a database and a connection to the database. We will create two new objects of these types.

        private static Database _dataBase;

        private static SQLiteAsyncConnection _connection;

        public static Database Instance
        {
            get
            {
                if (_dataBase == null)
                {
                    _dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"ShoppingItem_{Core.AuthenticatedUserID}.db3"));
                }

                return _dataBase;
            }
        }

        private Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);

            _connection.CreateTableAsync<ShoppingItem>().Wait();
            _connection.CreateTableAsync<User>().Wait();
        }


In order for our app to remember data for each user session, we must add this method in our code:

        public async Task AddAuthenticatedUser(User givenUser)
        {
            await _connection.InsertOrReplaceAsync(givenUser);

            return;
        }

The logout method closes the connection and erases all data from our SQLite database. The next time the app will be opened a new user session will be created, consequently a new database. 

    public void LogOut()
          {
              _connection.CloseAsync().Wait();
              _dataBase = null;

## Serialization

**Serialization** is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The reverse process is called deserialization.       

**JSON** is short for JavaScript Object Notation, and is a way to store information in an organized, easy-to-access manner. In a nutshell, it gives us a human-readable collection of data that we can access in a really logical manner.

A simple example of writing data in JSON:

            var jason = {
                "age" : "24",
                "hometown" : "Missoula, MT",
                "gender" : "male"
              };

For this, we will need to add one more NuGet package to our solution:
![image](https://user-images.githubusercontent.com/23138335/49687948-64ddad80-fb13-11e8-922b-d5de3c6520d7.png)

 
### In the following lines I will explain how to make a WebRequest.
The code can be accessed in the Utilities folder in our solution -> WebRequests.cs. Our version uses JSON elements to build new uris.

The first step is to create a **web request**:

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
        
To send the request to the server and receive an answer call **GetResponse**. The actual type of the returned WebResponse object is determined by the scheme of the requested URI.

      using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                  using (Stream stream = response.GetResponseStream())
                  using (StreamReader reader = new StreamReader(stream))
                  {
                      return await reader.ReadToEndAsync();
                  }

## Conclusion

•	Xamarin.Forms supports database-driven applications using the SQLite database engine, which makes it possible to load and save objects in shared code. 

•	JSON gives us a human-readable collection of data that we can access in a really logical manner.

•	When it comes to accessing on-line data, we must use Web Requests.



