//Generate Models from Database//
// 1.
Scaffold-DbContext "Server=.\SQLEXPRESS;Database=ApiMoho;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -Context ApiMohoContext -f
// 2.
Move the ApiMohoContext file in the context folder.


//When adding new Field to the UserModel//
// 1.
Initialise migration  :    add-migration [migration name] -Context [contextname]
// 2.
Upadate or Create the Database  : update-database -Context [contextname]