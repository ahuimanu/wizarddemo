# Repository Example

Based heavily on [Gary Woodfine's](https://garywoodfine.com/generic-repository-pattern-net-core/)
[Repository Pattern Library](https://github.com/threenine/Threenine.Data).

# Notes

Things to look out for:
* When placing an EF database context in its own project, you need to be mindful of the *other target frameworks* section of [this article](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#other-target-frameworks)
* this means you need to run the `ef` tooling like this: `dotnet ef migrations add InitialCreate --startup-project ../wizardui/wizardui.csproj`
* You may need to periodically go to the *Windows Task Manager* and kill `.NET Host Service` when dotnet commands fail (happenend when running above commands)
* the `dotnet` command apparently builds `.gitignore` files for you with this command: `dotnet new gitignore` (run it within the project directory)