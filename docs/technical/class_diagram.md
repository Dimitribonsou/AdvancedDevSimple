# Diagramme de Classes

Ce document illustre le modèle de domaine de l'application de Gestion de Catalogue Produit.

## Architecture Actuelle & Proposée

Le diagramme ci-dessous inclut les entités existantes (lignes pleines) et les entités proposées (lignes pointillées) pour répondre au besoin de gestion des Clients et Fournisseurs.

```mermaid
classDiagram
    class Product {
        +Guid Id
        +string Name
        +string Description
        +decimal Price
        +int Quantity
        +bool IsActive
        +ChangePrice(decimal newPrice)
        +Update(string name, decimal price, bool isActive)
        +ApplyDiscount(decimal percentage)
    }

    class Orders {
        +Guid Id
        +string CustomerName
        +decimal TotalAmount
        +DateTime CreatedAt
        +bool IsCancelled
        +Update(string customerName, decimal totalAmount)
        +Cancel()
    }

    %% Entités Proposées
    class Customer {
        +Guid Id
        +string FirstName
        +string LastName
        +string Email
        +string PhoneNumber
        +Address Address
    }

    class Provider {
        +Guid Id
        +string CompanyName
        +string ContactName
        +string Email
        +string Phone
    }

    class OrderItem {
        +Guid Id
        +Guid OrderId
        +Guid ProductId
        +int Quantity
        +decimal UnitPrice
    }

    %% Relations
    Orders "1" --> "*" OrderItem : contient
    Product "1" <-- "*" OrderItem : commandé dans
    Customer "1" --> "*" Orders : passe
    Provider "1" --> "*" Product : fournit
```

## Détails des Entités

### Entités Existantes

- **Product** : Représente un article du catalogue. Inclut la logique pour les changements de prix et remises.
- **Orders** : Représente une demande client. Stocke actuellement `CustomerName` comme chaîne, mais devrait lier une entité `Customer` à l'avenir.

### Entités Proposées

- **Customer** : Pour remplacer la simple chaîne `CustomerName` dans `Orders`, permettant une gestion complète des clients.
- **Provider (Fournisseur)** : Pour identifier la source des produits.
- **OrderItem** : Pour gérer plusieurs produits par commande (actuellement `Orders` a seulement un montant total, ce qui implique un modèle simplifié ou un détail manquant).
