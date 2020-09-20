## Points importants

* Productivité : eviter le code non interessant (INotifyPropertyChanged, parsing et generation de structures de données)
* Perfs : 
    * pousser des traitements qui se font au runtime vers le compile time
    * on imagine des cas d'usage ou l"on peut eviter de faire de la reflexion au runtime

* les developeurs de Roslyn misent beaucoup sur des SourcesGenerators qui seront distribués via Nuget

* un mecanisme similaire existe en F# TypeProviders

* une façon de faire de la méta-programmation

* il n'est pas nouveau mais on sent que le mecanisme sera de plus en plus outillé et mis en avant



## Disclaimer

Le code montré est un code d'exploration il est non teste.
Le Genrateur CSV à des limitations:
* un seul format supporté, "," comme separateur
* la detection du type est naive (elle se base sur les données de la premiére ligne uniquement)
* Zero tests automatisés
