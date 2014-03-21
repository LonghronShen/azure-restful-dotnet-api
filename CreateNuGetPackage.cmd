del *.nuspec
del *.nupkg
nuget spec
nuget pack Azure.Restful.Provider\Azure.Restful.Provider.csproj -Build -IncludeReferencedProjects -Prop Configuration=Release