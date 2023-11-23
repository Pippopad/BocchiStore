# BocchiStore

![Project](https://img.shields.io/badge/Project-School-brightgreen)

## Schema logico
```
Books           (BookId, Title, Description?, CoverImage?)
Categories      (CategoryId, Name)
BookCategories  (BookId, CategoryId)
Users           (UserId, Username, Name, Surname, PasswordHash, Phone?, IsAdmin)
Loans           (BookId, UserId, StartDate, EndDate?)
Reviews         (ReviewId, Title, Description, Score, BookId, UserId)
```
