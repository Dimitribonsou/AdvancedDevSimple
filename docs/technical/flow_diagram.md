# Diagrammes de Flux

Ce document illustre les flux métier clés de l'application de Gestion de Catalogue Produit.

## 1. Flux de Création de Commande

Ce flux décrit le processus de création d'une nouvelle commande.

```mermaid
sequenceDiagram
    participant API as OrderController
    participant Service as OrderService
    participant Entity as Orders
    participant Repo as OrderRepository

    API->>Service: Create(customerName, totalAmount)
    Service->>Entity: new Orders(id, customerName, totalAmount)
    activate Entity
    Entity->>Entity: Validate(customerName, totalAmount)
    alt Échec Validation
        Entity-->>Service: throw DomainException
        Service-->>API: throw Exception
    else Succès Validation
        Entity-->>Service: Instance Order
    end
    deactivate Entity

    Service->>Repo: Add(order)
    Repo-->>Service: void
    Service-->>API: order.Id
```

## 2. Flux de Mise à Jour de Prix Produit

Ce flux décrit le processus de mise à jour du prix d'un produit, en appliquant les règles métier (ex: prix positif).

```mermaid
sequenceDiagram
    participant API as ProductsController
    participant Service as ProductService
    participant Entity as Product
    participant Repo as ProductRepository

    API->>Service: ChangeProductPrice(id, newPrice)
    Service->>Repo: GetProductById(id)
    Repo-->>Service: Instance Product
    
    alt Produit Non Trouvé
        Service-->>API: throw Exception("Produit introuvable")
    end

    Service->>Entity: ChangePrice(newPrice)
    activate Entity
    Entity->>Entity: Validate(newPrice)
    alt Échec Validation
        Entity-->>Service: throw DomainException
    else Succès Validation
        Entity-->>Service: void
    end
    deactivate Entity

    Service->>Repo: Update(product)
    Repo-->>Service: void
    Service-->>API: void
```
