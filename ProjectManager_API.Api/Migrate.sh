#!bash

dotnet ef --startup-project ./ProjectManager_API.Api.csproj --project ../ProjectManager_API.Persistence/ProjectManager_API.Persistence.csproj migrations add $1 
