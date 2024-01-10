# Application Process with API Tests and Code Sample

This project is a demonstration of the application process while applying for a Full Stack/Backend position.

## API Tests

To quickly test an API use the Visual Studio Code extension, REST Client. It allows for very simple syntax to test endpoints. Create a file with the .http extension. Provide the verb, endpoints, headers, and body then click 'Send Request' to see the response.

Thunder Client is another Visual Studio Code extension that is really handy at testing APIs. 

Postman is also good but I did not have it installed on my system.

## Code Sample

LINQPad is a convenient method of running isolated code. Create a file .linq extension and then run console applications very easily. In most cases, it automatically resolves any using statements.

## Description

The code sample basically reads the file statistics to determine how long was spent on each step of the application process. It determines which test took the longest to write, and the total time spent writing each test.

Additionally it includes the refactoring of the StringatizeDemNums method.

The PathToSource constant should be updated to reflect where the code was cloned to. 

Could be improved by including exception handling, logging, and calculating the relative path to the test files. 

## Known Issue

Cloning the project to a new location changes the FileInfo.LastWriteTimeUtc value, the original times were:

| Test                       | Time Spent Completing | Comments                     |
|----------------------------|-----------------------|------------------------------|
| apply-test.http            | 6 minutes             | Missed content-type header   |
| confirmation-test.http     | 1 minute              |                              |
| impossible-test.http       | 1 minute              |                              |
| rating-c-sharp-test.http   | 14 minutes            | Wrong PUT action and headers |
| command-test.http          | 2 minutes             |                              |
| get-source-test.http       | 1 minute              |                              |
| comments-test.http         | 3 minutes             |                              |
| database-breakin-test.http | 2 minutes             | Should have used JOINs       |
| punchline-test.http        | 3 minutes             |                              |
| final-test.http            | 6 minutes             |                              |

Based on time spent, it can be inferred that "rating-c-sharp-test.http" took the longest to complete.

Total time spent was approximately 39 minutes.