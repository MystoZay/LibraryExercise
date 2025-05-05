# API de gestion de bibliothèque

## Configuration de l'environnement

Il est important d'avoir Entity Framework Core d'installer sur son ordinateur. En command line, entré la commande 
```
dotnet tool install --global dotnet-ef
```
Cette command est utilisée lorsque le DataContext de l'application va créer la Migration de la base de données.

## Comment lancer Docker

Assurez-vous d'avoir Docker Desktop d'installer et ouvert.

Par la suite, il suffit de lancer ```docker-compose up -d``` en command line à partir du folder qui contient le fichier docker-compose. Le script va build la solution, construire l'image ainsi que le deployé dans son container.

## Choix techniques

J'ai décidé de faire seulement 3 tables pour le projet. Si on a besoin dans un future d'afficher tous les livres ayant déjà été emprunté, il suffit que faire un join entre les tables Book and Loan. Il n'est pas nécessaire d'avoir une table qui contient ses informations. On va de la même logique pour les auteurs ayant plublié X nombre de livre.

Par la suite, j'ai décidé d'utiliser des controllers pour les routes des appels API. De cette façon, on garde le ```Program.cs``` simple et propres.

Pour le controlleur Loan, il n'a besoin que deux API. Puisqu'un utilisateur peut seulement créer un emprunt et regarder. Il n'est pas donc pas nécessaire d'exposer la table Loan à plus qu'il est nécessaire.



### API call

À l'aide de l'interface Swagger, il est possible de faire différent appel API à la base de données.

#### Author
La table Author contient 4 API calls (Get, Post, Put et Delete).

Exemple pour Delete /api/AuthorController/DeleteAuthor pour ID 1
http://localhost:5000/api/Author/DeleteAuthor?id=1
Avec Swagger, inséré '1' dans l text box ID pour le Delete.

Exemple pour Get /api/AuthorController/GetAuthor pour ID 1
http://localhost:5000/api/Author/GetAuthor?id=1
Avec Swagger, inséré '1' dans l text box ID pour le Get.

Exemple pour Get /api/AuthorController/UpdateAuthor pour ID 1
```
curl -X 'PUT' \
  'http://localhost:5000/api/Author/UpdateAuthor?id=1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "name": "string",
  "familyName": "string",
  "dateOfBirth": "2025-05-05"
}'
```
Avec Swagger, inséré '1' dans l text box ID pour le Update ainsi que le body suivant
```
{
  "id": 0,
  "name": "string",
  "familyName": "string",
  "dateOfBirth": "2025-05-05"
}
```

Exemple pour Get /api/AuthorController/AddAuthor pour ID 1
```
curl -X 'POST' \
  'http://localhost:5000/api/Author/AddAuthor' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "name": "Prenom",
  "familyName": "Nom",
  "dateOfBirth": "2025-05-05"
}'
```

Avec Swagger, inséré '1' dans l text box ID pour le Update ainsi que le body suivant
```
{
  "id": 0,
  "name": "Prenom",
  "familyName": "Nom",
  "dateOfBirth": "2025-05-05"
}
```
#### Book
La table Book contient 4 API calls (Get, Post, Put et Delete).

Exemple pour Delete /api/BookrController/DeleteBook pour ID 1
http://localhost:5000/api/Book/DeleteBook?id=1
Avec Swagger, inséré '1' dans l text box ID pour le Delete.

Exemple pour Get /api/BookController/GetBook pour ID 1
```
http://localhost:5000/api/Book/GetBook?id=1
```
Avec Swagger, inséré '1' dans l text box ID pour le Get.

Exemple pour Update /api/BookController/UpdateBook pour ID 1
```
curl -X 'PUT' \
  'http://localhost:5000/api/Book/UpdateBook?id=1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "0259416",
  "title": "Titre",
  "authorId": 1,
  "publicationDate": "2025-05-05"
}'
```

Avec Swagger, inséré '1' dans l text box ID pour le Update ainsi que le body suivant
```
{
  "id": "0259416",
  "title": "Titre",
  "authorId": 1,
  "publicationDate": "2025-05-05"
}
```
Exemple pour Post /api/BookController/AddBook pour ID 1
```
curl -X 'POST' \
  'http://localhost:5000/api/Book/AddBook' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "0259416",
  "title": "Titre",
  "authorId": 1,
  "publicationDate": "2025-05-05"
}'
```
Avec Swagger, inséré '1' dans l text box ID pour le Post ainsi que le body suivant
```
{
  "id": "0259416",
  "title": "Titre",
  "authorId": 1,
  "publicationDate": "2025-05-05"
}
```
### Loan
La table Loan contient 2 API calls (Get et Post).

Exemple pour Get /api/LoanController/GetLoan pour ID 1
http://localhost:5000/api/Loan/GetLoan?id=1
Avec Swagger, inséré '1' dans l text box ID pour le Get.

Exemple pour Post /api/LoanController/AddLoan pour ID 1
```
curl -X 'POST' \
  'http://localhost:5000/api/Loan/AddLoan' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "isbn": "0984026",
  "id": 0,
  "authorId": 1,
  "loanDate": "2025-05-05",
  "returnDate": "2025-06-05"
}'
```
Avec Swagger, inséré '1' dans l text box ID pour le Update ainsi que le body suivant
```
{
  "isbn": "0984026",
  "id": 0,
  "authorId": 1,
  "loanDate": "2025-05-05",
  "returnDate": "2025-06-05"
}
```

# Repo Git
https://github.com/MystoZay/LibraryExercise/tree/main