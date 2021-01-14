# nuget.result
This library is meant to provide a light-weight wrapper class that lets you quikcly determine whether an action succeeded for failed.

The following console app was written using this nuget package (Simple.Result) and Newtonsoft.Json.

```
using Fcbc.Utility.Result;
using Newtonsoft.Json;
using System;

namespace ResultExample
{
    class Program
    {
        public class UserData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public UserData(string first, string last)
            {
                FirstName = first;
                LastName = last;
            }
        }

        public class Error
        {
            public string Message { get; set; }
            public int Code { get; set; }

            public Error(string message, int code)
            {
                Message = message;
                Code = code;
            }
        }

        public static Result<UserData, Error> TestIt(bool pass)
        {
            if (pass)
            {
                return new UserData("Chris", "Volpi");
            }
            else
            {
                return new Error("Well this is awkward...", 1002);
            }
        }

        public static void MiniApp()
        {
            Console.WriteLine("Type pass for an example of a successful result object");
            Console.WriteLine("Type fail for an example of a failure result object");
            var command = Console.ReadLine();

            if (command.Equals("pass", StringComparison.OrdinalIgnoreCase))
            {
                var result = TestIt(true);
                Console.WriteLine(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
            else if (command.Equals("fail", StringComparison.OrdinalIgnoreCase))
            {
                var result = TestIt(false);
                Console.WriteLine(JsonConvert.SerializeObject(result, new JsonSerializerSettings { Formatting = Formatting.Indented }));
            }
            else
            {
                Console.WriteLine("Uh... WAT?");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                MiniApp();
            }
        }
    }
}

```

When a result is passed, `IsSuccess` is true and `Value` is not null.
When a result is failed, `IsSuccess` is false and `Error` is not null.

The above example makes use of the `implicit operator` functionality in the Result class. You do not have to new up a result class if you have the success or failure object that you want to return.

The VoidResult class does not have an implicit operator for success responses; you must always `return new VoidResult<ErrorClass>();` for success cases. This is because there is no way to implictly convert a void return into a type. Though, you can still `return new ErrorClass();` instead of newing up the result wrapper.

Because this class uses generics, the success and failure types can be whatever you want them to be.

Let me know if you think anything could be improved here and do not be shy with PRs.
