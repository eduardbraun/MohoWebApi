dotnet ef dbcontext scaffold "Server=.\;Database=AdventureWorksLT2012;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Model


Initialise migration  :    add-migration [migration name] -Context [contextname]

Upadate or Create the Database  : update-database -Context [contextname]