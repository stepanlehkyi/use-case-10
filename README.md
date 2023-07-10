StringValidator
Application Description
StringValidator is a lightweight application implemented in C#, designed to verify the composition and length of a given string. The primary goal of this application is to ensure that a string meets specific security criteria - such as the presence of uppercase, lowercase, special characters, and numeric digits, along with conforming to a pre-set length. It is useful in various scenarios including form validation, password strength checking, and compliance checking for user inputs.

Regex Implementation Description
This application employs Regular Expressions (Regex) for the string validation process. The constructor of the StringValidator class takes a length parameter and uses it to form a Regex pattern, asserting that a valid string must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be exactly the defined length. The pattern explicitly disallows any whitespace. When the IsStringValid method is invoked with an input string, the Regex pattern is matched against the string, effectively validating the string according to the defined rules. The method returns true if the input string meets all the requirements and false otherwise.

Running the Application Locally
Follow the steps below to run the application on your local machine:

Ensure you have a .NET Core compatible environment setup. You can download .NET Core from here.

Clone the repository to your local machine using the command:

bash
Copy code
git clone <repository_url>
Replace <repository_url> with the actual URL of this repository.

Navigate to the root folder of the application (where the .csproj file is located) using:

bash
Copy code
cd <path_to_project>
Replace <path_to_project> with the actual path to the project on your local machine.

Build the application using the following command:

Copy code
dotnet build
Run the application using the command:

arduino
Copy code
dotnet run
To run the tests, navigate to the test project directory (where the test .csproj file is located) and use the following command:

bash
Copy code
dotnet test
This will display the test results in the console.
