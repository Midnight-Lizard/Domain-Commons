#===========================================#
#				DOTNET	BUILD				#
#===========================================#
FROM microsoft/dotnet:2.1-sdk as dotnet-build
WORKDIR /build
COPY . .
RUN dotnet build -c Release

#===========================================#
#				DOTNET	TEST				#
#===========================================#
FROM microsoft/dotnet:2.1-sdk as dotnet-test
WORKDIR /test
COPY --from=dotnet-build /build .
RUN dotnet test -c Test

#===========================================#
#				NUGET	PUSH				#
#===========================================#
FROM microsoft/dotnet:2.1-sdk as nuget-push
ARG NUGET_KEY
WORKDIR /package
COPY --from=dotnet-build /build/package/bin/Release/*.nupkg .
RUN dotnet nuget push *.nupkg -k ${NUGET_KEY} -s https://api.nuget.org/v3/index.json
