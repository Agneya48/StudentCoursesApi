# StudentCoursesApi

ASP.NET Core Web API final project using:

- .NET 10
- Entity Framework Core
- SQL Server LocalDB
- Code First migrations
- EF Core seed data
- NSwag / Swagger UI

The project uses two API controllers:

- `StudentProfilesController`
- `CourseRecordsController`

Which in turn interact with two EF Core entity models/tables:

- `StudentProfiles`
- `CourseRecords`

`CourseRecords` uses `StudentProfileId` as a foreign key to relate in a one-to-many relationship. A student may have multiple course records, but each course record is associated with only one student profile.

Be advised that deleting a student profile will also delete all associated course records due to the configured cascade delete behavior in the EF Core model.

---

## Running the Project

After cloning or downloading the repository, open the solution in Visual Studio. Restore NuGet packages if prompted.

The project uses SQL Server LocalDB with the following connection string in `appsettings.json`:

```json
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StudentCoursesApiDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

From the project folder containing `StudentCoursesApi.csproj`, run:

```powershell
dotnet ef database update
```

This creates the LocalDB database, applies the EF Core migration, and inserts the seed data.

Then run the project and open Swagger/NSwag:

```text
https://localhost:7086/swagger
```

The port may differ depending on local Visual Studio launch settings.

---

## EF Core Tooling Note

If `dotnet ef` is not available, install the EF Core command-line tool:

```powershell
dotnet tool install --global dotnet-ef
```

Then verify installation:

```powershell
dotnet ef --version
```

If already installed but outdated, use:

```powershell
dotnet tool update --global dotnet-ef
```

---

## Visual Studio Package Manager Console Note

During development, Visual Studio’s Package Manager Console produced this error when running migration commands:

```text
GetProjectFromHierarchy must be called on the UI thread.
```

This appears to be a Visual Studio tooling/UI issue for Visual Studio 2026 Insiders, as detailed in this [support thread](https://developercommunity.visualstudio.com/t/Error-while-using-Add-Migration-in--nuge/11074563).

If the issue occurs, use the terminal commands instead from the project folder:

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

The migration files are already included in this repository, so normally only this command is needed after downloading:

```powershell
dotnet ef database update
```

---

## Resetting the Local Database

The database is not stored directly in GitHub. It is recreated from the EF Core migration and seed data.

To reset the local database back to the original seeded state, run:

```powershell
dotnet ef database drop
dotnet ef database update
```

Because LocalDB databases exist outside the project folder, multiple local copies of this project may point to the same database if they use the same database name:

```text
StudentCoursesApiDb
```

---

## API Notes

Swagger/NSwag displays the available API endpoints.

The `GET` operations use an optional nullable query parameter named `id`.

Examples:

```text
GET /api/StudentProfiles
GET /api/StudentProfiles?id=1
GET /api/CourseRecords
GET /api/CourseRecords?id=1
```

If `id` is left blank or set to `0`, the API returns the first five records from the table.

The project also includes an extra endpoint to show the relationship between a student profile and course records:

```text
GET /api/StudentProfiles/{id}/courses
```

This will return the student profile with the specified `id` along with all associated course records.