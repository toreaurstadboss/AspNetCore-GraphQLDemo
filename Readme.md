### GraphQL demo - Asp.Net Core 


This solution shows how to get started with GraphQL in an Asp.Net Core solution. 


### Sample GraphQL query 


```graphql

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
