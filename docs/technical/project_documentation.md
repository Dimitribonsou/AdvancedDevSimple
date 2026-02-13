# Documentation Technique

## Vue d'ensemble

Ce projet est un Service de Gestion de Catalogue Produit construit avec .NET, suivant les principes de la **Clean Architecture**. Il gère les Produits et les Commandes, avec des extensions prévues pour les Clients et les Fournisseurs.

## Architecture

La solution est divisée en plusieurs couches :

- **Domain** (`AdvancedDevSample.Domain`) : Contient la logique métier centrale, les entités et les interfaces des dépôts. Elle n'a aucune dépendance externe.
- **Application** (`AdvancedDevSample.Application`) : Contient les services métier (`ProductService`, `OrderService`) et les DTOs. Orchestre le flux de données entre l'API et le Domaine.
- **Infrastructure** (`AdvancedDev.Sample.Infrastructure`) : Implémente les interfaces définies dans le Domaine (Dépôts) et gère l'accès aux données (EF Core, InMemory).
- **API** (`Advanced.Sample.Api`) : Le point d'entrée de l'application, exposant les endpoints REST via des Contrôleurs.
- **Tests** (`Advanced.Sample.Test`) : Tests unitaires et d'intégration.

## Entités

Les entités principales sont définies dans la couche Domaine.

- **Product** (Produit) : Entité gérée avec logique de changement de prix et validation.
- **Orders** (Commandes) : Représente les commandes clients.
- **Customer** (Client - Prévu) : Pour représenter l'acheteur.
- **Provider** (Fournisseur - Prévu) : Pour représenter le fournisseur du produit.

Pour une représentation visuelle détaillée, voir le [Diagramme de Classes](./class_diagram.md).

## Flux Clés

Le système gère plusieurs processus métier clés, notamment :

1. **Création de Commande** : Validation du client et du montant avant persistance.
2. **Changement de Prix Produit** : Application des règles métier (prix positif) avant mise à jour en base.

Pour les visualisations des flux, voir les [Diagrammes de Flux](./flow_diagram.md).

## Structure du Projet

```
/ (Racine)
├── AdvancedDevSample.Domain/       # Entités du Domaine & Interfaces
├── AdvancedDevSample.Application/  # Services & DTOs
├── AdvancedDev.Sample.Infrastructure/ # Implémentation Accès Données
├── Advanced.Sample.Api/            # Contrôleurs Web API
├── Advanced.Sample.Test/           # Tests
└── docs/                           # Documentation
    └── technical/                  # Docs Techniques (Diagrammes, Guides)
```
