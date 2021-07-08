 FROM mcr.microsoft.com/dotnet/runtime:5.0
  COPY bin/Debug/net5.0/ App/
  EXPOSE 3303
  WORKDIR /App
  ENTRYPOINT ["dotnet", "pub.dll"]
