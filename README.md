# AspNetCore3.0AndIdentityServerv4Example
Hire me or work with me, either way contact me!
http://nativescript.studio 

Open Command Prompt in the directory of NativeScriptStudio.EfCore 
Enter the following commands to create a brand new migration if you modified the Entities
dotnet ef migrations add v3   keep in mind that the v3 is increased by 1 every time you perform a migration. For Exampple
dot net  ef migrations add v4 then your next migration would be dotnet migrations add v5 etc.

After the migrations has been completed succesfully you can either create a t-sql script and deploy it yourself 
You can piple it to an actual file like so
dotnet ef migrations script > migrationScript.tsql then give it to the dba.

If you are doing rapid development or managing your production workflows with migrations
dotnet ef database update would deploy your changes to the database speficied  


in sum the commands are: 
dotnet ef migrations add v3
dotnet ef migrations script > migrationScript.tsql 



For more advanced commands like reversing a migrations go here: 
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet
https://ef.readthedocs.io/en/staging/miscellaneous/cli/dotnet.html

This is the one liner that does it all -- U can delete the migrations folder to start from scracth if u get errors.
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb && dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb && dotnet ef migrations add InitalApplicationContextMigration -c ApplicationDbContext -o Data/Migrations/IdentityServer/ApplicationDbContextMigration && dotnet ef database update -c ApplicationDbContext &&  dotnet ef database update -c PersistedGrantDbContext &&  dotnet ef database update -c ConfigurationDbContext

I broke down the methods here just in case someone wanted to only run once at a time and it would be easy to copy and paste. 
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb 
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
dotnet ef migrations add InitalApplicationContextMigration -c ApplicationDbContext -o Data/Migrations/IdentityServer/ApplicationDbContextMigration
dotnet ef database update -c ApplicationDbContext


While in development it would be easier to drop the database and erase migrations than to manage the migration history. 

