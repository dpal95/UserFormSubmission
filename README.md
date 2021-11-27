# UserFormSubmission

This project allows a user to be added to a SQL database. It has several validation/verification features to help the quality of the data 
i.e. email format checks and password verification. 

The project uses SQLCLient to access the database, I have used two different styles of method to access the database. The checkuserexists method uses hard coded sql 
whereas the insertuser method uses a stored procedure. There are benefits and draw backs to either style which i will list now.

the password is saved using a hash and salt therefore providing good security and lowering the risk of a password being stolen and used.

Hard coded sql:
  pros: keeps all code in one place
        covered by source control so breaking changes can be tracked
  cons: a small change requires a redeployment of the project
        very easy to make a syntax error. 
        
Stored Procedure:
   pros: changes/fixes can be implemented quickly
         modulates the project
         syntax errors picked up immediately 
   cons: not tracked in source control
         hard to maintain properly
         
         
The project has unit tests and access a test db to perform these. The tests are unit tests however due to the fact they query a test database to run a test script they are 
integration tests however they demonstrate good test coverage and provide confidence in the performance of the code.


The project uses two databases one for production and the other for test. the scripts included in the project should be ran before the project is started. The databases referred to
are UserFormSubmission and UserFormSubmissionTest. The respective create user table scripts should be ran first and then the respective insertuser and removeuser. 

any issues please contact me. 
