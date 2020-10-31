#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["API/Backend.API/Backend.API.csproj", "API/Backend.API/"]
COPY ["Core/Business/Backend.Business.Billing/Backend.Business.Billing.csproj", "Core/Business/Backend.Business.Billing/"]
COPY ["Core/Backend.Domain/Backend.Domain.csproj", "Core/Backend.Domain/"]
COPY ["Common/Backend.Common/Backend.Common.csproj", "Common/Backend.Common/"]
COPY ["Core/Libraries/Backend.Library.Payment/Backend.Library.Payment.csproj", "Core/Libraries/Backend.Library.Payment/"]
COPY ["Core/Backend.Infrastructure/Backend.Infrastructure.csproj", "Core/Backend.Infrastructure/"]
COPY ["Core/Libraries/Backend.Library.Logging/Backend.Library.Logging.csproj", "Core/Libraries/Backend.Library.Logging/"]
COPY ["Core/Business/Backend.Business.Import/Backend.Business.Import.csproj", "Core/Business/Backend.Business.Import/"]
COPY ["Core/Business/Backend.Business.Notifications/Backend.Business.Notifications.csproj", "Core/Business/Backend.Business.Notifications/"]
COPY ["Core/Business/Backend.Business.Email/Backend.Business.Email.csproj", "Core/Business/Backend.Business.Email/"]
COPY ["Core/Libraries/Backend.Library.Email/Backend.Library.Email.csproj", "Core/Libraries/Backend.Library.Email/"]
COPY ["Core/Libraries/Backend.Library.AmazonS3/Backend.Library.AmazonS3.csproj", "Core/Libraries/Backend.Library.AmazonS3/"]
COPY ["Core/Business/Backend.Business.Dashboard/Backend.Business.Dashboard.csproj", "Core/Business/Backend.Business.Dashboard/"]
COPY ["Core/Business/Backend.Business.Users/Backend.Business.Users.csproj", "Core/Business/Backend.Business.Users/"]
COPY ["Core/Business/Backend.Business.Authorization/Backend.Business.Authorization.csproj", "Core/Business/Backend.Business.Authorization/"]
COPY ["Core/Business/Backend.Business.ProgressTracking/Backend.Business.ProgressTracking.csproj", "Core/Business/Backend.Business.ProgressTracking/"]
COPY ["Core/Business/Backend.Business.Metrics/Backend.Business.Metrics.csproj", "Core/Business/Backend.Business.Metrics/"]
COPY ["Core/Business/Backend.Business.Export/Backend.Business.Export.csproj", "Core/Business/Backend.Business.Export/"]
COPY ["Core/Business/Backend.Business.TrainingPrograms/Backend.Business.TrainingPrograms.csproj", "Core/Business/Backend.Business.TrainingPrograms/"]
COPY ["Core/Libraries/Backend.Library.MediaCompression/Backend.Library.MediaCompression.csproj", "Core/Libraries/Backend.Library.MediaCompression/"]
COPY ["Core/Business/Backend.Business-ExerciseType/Backend.Business.Exercises.csproj", "Core/Business/Backend.Business-ExerciseType/"]
COPY ["Core/Business/Backend.Business.Media/Backend.Business.Media.csproj", "Core/Business/Backend.Business.Media/"]
COPY ["Persistance/Backend.Persistance/Backend.Persistance.csproj", "Persistance/Backend.Persistance/"]
COPY ["Core/Business/Backend.Business.Chat/Backend.Business.Chat.csproj", "Core/Business/Backend.Business.Chat/"]
COPY ["Core/Business/Backend.Business.TrainingLog/Backend.Business.TrainingLog.csproj", "Core/Business/Backend.Business.TrainingLog/"]
RUN dotnet restore "API/Backend.API/Backend.API.csproj"
COPY . .
WORKDIR "/src/API/Backend.API"
RUN dotnet build "Backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.API.dll"]