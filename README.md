# AdvancedDevSample - Gestion de Catalogue Produit

Ce dépôt contient le code source du Service de Gestion de Catalogue Produit, une API Web .NET construite selon les principes de la Clean Architecture.

## Vue d'ensemble du Projet

L'objectif de ce projet est de fournir un backend robuste pour gérer les produits, les commandes et les entités associées. Il supporte actuellement :

- **Gestion des Produits** : Créer, mettre à jour, supprimer et récupérer des produits.
- **Gestion des Commandes** : Passer et suivre des commandes.

Les fonctionnalités prévues incluent la gestion complète des Clients et des Fournisseurs.

## Stack Technique

- **Framework** : .NET 8.0
- **Architecture** : Clean Architecture (Domaine, Application, Infrastructure, API)
- **Documentation** : MkDocs avec Thème Material
- **Diagrammes** : Mermaid.js

## Pour Commencer

### Prérequis

- .NET 8.0 SDK
- Python 3.x (pour la documentation)

### Lancer l'Application

1. Cloner le dépôt.
2. Naviguer dans le dossier de la solution.
3. Lancer le projet :
   ```bash
   dotnet run --project Advanced.Sample.Api
   ```

### Lancer la Documentation

Pour voir la documentation technique localement :

1. Installer MkDocs et le thème Material :
   ```bash
   pip install mkdocs-material
   pip install mkdocs-material-extensions 
   ```
2. Lancer le serveur de documentation :
   ```bash
   mkdocs serve
   ```
3. Ouvrir votre navigateur à l'adresse `http://127.0.0.1:8000`.

## Architecture & Conception

Pour une documentation technique détaillée, incluant les diagrammes de classes et de flux, veuillez vous référer à la [Documentation Technique](docs/index.md) ou lancer le serveur MkDocs comme décrit ci-dessus.
