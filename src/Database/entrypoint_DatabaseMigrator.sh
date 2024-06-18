# Wait 30 seconds after SQL Server is running for database creation.
sleep 5;

echo $App_ConnectionString

dotnet DatabaseMigrator.dll $App_ConnectionString "/migrations"