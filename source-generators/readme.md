## Points importants

* Productivité : eviter le code non interessant (INotifyPropertyChanged, parsing et generation de structures de données)
* Perfs : 
    * pousser des traitements qui se font au runtime vers le compile time
    * on imagine des cas d'usage ou l"on peut eviter de faire de la reflexion au runtime
* les developeurs de Roslyn misent beaucoup sur des SourcesGenerators qui seront distribués via Nuget
* un mecanisme similaire existe en F# TypeProviders
* une façon de faire de la méta-programmation
* il n'est pas nouveau mais on sent que le mecanisme sera de plus en plus outillé et mis en avant
* l'intellissense est fantastique sur VS 2019 (pas pu tester mais plusieurs sources l'affirment)

### Liens interessants:
* https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
* https://github.com/dotnet/roslyn/blob/master/docs/features/source-generators.cookbook.md
* https://www.youtube.com/watch?v=JSFZ3qDx83g (3h48 par Immo Landwerth - PM DotNet)
* https://docs.microsoft.com/fr-fr/dotnet/fsharp/tutorials/type-providers/


## Disclaimer

Le code montré est un code d'exploration il est non teste.
Le Genrateur CSV à des limitations:
* un seul format supporté, "," comme separateur
* la detection du type est naive (elle se base sur les données de la premiére ligne uniquement)
* Zero tests automatisés
* Pour la géneration de code faut-t-il utiliser Microsoft.CodeDom.Providers.DotNetCompilerPlatform ou autre ? pour une raison que j'ignore je n'ai pas pu charger la lib sur dotnet5 rc-0 
