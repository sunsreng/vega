# vega
set ASPNETCORE_ENVIRONMENT="Development"

# package
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

webpack --config webpack.config.vendor.js
webpack