 FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY bin/Debug/net5.0/ App/
  ENV ASPNETCORE_URLS=http://+:3313
  EXPOSE 3313
  WORKDIR /App
  ENTRYPOINT ["dotnet", "sub.dll"]
