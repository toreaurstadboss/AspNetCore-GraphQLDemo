### GraphQL demo - Asp.Net Core 


This solution shows how to get started with GraphQL in an Asp.Net Core solution. 


### Sample GraphQL queries


The following query will retrieve mountain data using GraphQL:


#### Selection / Query

```json

{
  mountains {
    id
    fylke: county
    kommune: muncipiality
    hoydeOverHavet: calculatedMetresAboveSeaLevel
    offisieltNavn: officialName
    primaerfaktor: calculatedPrimaryFactor
    referansePunkt: referencePoint
  }
}


```

It is possible to retrieve this same data via Postman using the following GET call:

```bash
http://localhost:2542/graphql?query={mountains{id fylke: county kommune: calculatedMetresAboveSeaLevel offisieltNavn: officialName primaerfaktor: calculatedPrimaryFactor referansePunkt: referencePoint}}
```


#### Alteration / Mutation 

The following call shows how to add a mountain using GraphQL and the 
createMountain mutation. 


```json 

mutation {
  createMountain(mountain: {
   county: "Svalbard"
  muncipiality: "Svalbard"
  officialName: "Newtontoppen"
  referencePoint: "Isbjønn på toppen"
  comments: "Husk rask snøskuter",
  metresAboveSeaLevel: "1713",
  primaryFactor: "1713"
  }) {    
    id
  }
}
```

And the following mutation shows how we can remove a mountain using GraphQL and the 
removeMountain mutation: 


```json 
mutation {
  removeMountain(id: {
    id: 365
  }) { id }
}
```

### Client library 
The following port of Apollo Client (an industry standard GraphQL client for several platforms, such as node/npm) is made browser ready from this Github repo:
https://github.com/Akryum/apollo-client-browser

It can be included like the following script reference or copied into the wwwroot 
folder locally for an Asp.Net Core application:


```js
<script src="https://unpkg.com/apollo-client-browser@1.7.0"></script>
```
