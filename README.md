# Target Case Study
The goal of this case study was to review the given code and produce the appropriate test cases.

## Technologies and Notable Dependendencies
- .NET Framework 4
- Entity Framework 6.1.3
- JQuery 2.1.4

## Setup
1. Web.config (inside Products) and App.config (inside ProductsTest)
   - Connection Strings need redirected to the local repository path
2. In the event you receive the error "Cannot attach file" you must reset the local db used for this project
   - Start by deleting all 3 files in the SqlExpress
   - Execute the following command inside the package manager console
     ```
     sqllocaldb.exe stop v11.0
     sqllocaldb.exe delete v11.0
     Update-Database
     ```
## Running Tests
1. Open the Test Explorer via Test Menu
2. Click the double green arrows to "Run All Tests"

## Productionize Application
- Security for "edit" and "delete" functions
  - Once connected to a db table of users (or better yet LDAP) give users permissions based on their use case.
  - Ideally, I recommend starting with 3 basic groups
    - Users (most users, able to basic tasks)
    - Power User/Override (these are your specialists or users who are more comfortable with the system)
    - Admin (Administrator of the application able to access and modify everything)
- Original code failed function test
  - I have added a simple redirect of error 404
  - I suggest expanding this to include 403, and 500 at a minimum
