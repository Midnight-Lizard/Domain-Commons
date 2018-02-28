#===========================================#
#				DOTNET	BUILD				#
#===========================================#
FROM microsoft/aspnetcore-build:2-jessie as dotnet-build
WORKDIR /build
COPY . /build/
RUN dotnet build -c Release
RUN ls ./

#===========================================#
#				DOTNET	TEST				#
#===========================================#
FROM microsoft/aspnetcore-build:2-jessie as dotnet-test
WORKDIR /test
COPY --from=dotnet-build /build .
RUN dotnet test -c Test

#===========================================#
#				NUGET	PUSH				#
#===========================================#
FROM microsoft/aspnetcore:2-jessie as nuget-push
ARG NUGET_KEY
WORKDIR /package
COPY --from=dotnet-build /build/package/bin/Release/ .
RUN dotnet nuget push *.nupkg -k ${NUGET_KEY} -s https://api.nuget.org/v3/index.json