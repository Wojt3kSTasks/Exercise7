# Zadanie dodatkowe

Przygotuj nowy projekt aplikacji API i razem z EF i podejściem CodeFirst wygeneruj kilka migracji, która pozwolą nam stworzyć bazę danych przedstawioną na poniższym rysunku.

## Baza danych

Poniżej przedstawiony jest diagram na którym będziemy pracować.

![alt text](./Data/cw7DatabaseERD.png "Title")

## Wymogi zadania

1. Przygotuj webapi z bazą za pomocą podejścia CodeFirst
2. Dodaj końcówkę pobierającą dane z wszystkich tabel
3. Dodaj końcówkę, która pozwoli dodawać dane do minimum 2 tabel, gdzie całość powinna odbyć się w jednej transakcji.

## Uwagi

- Program powinien być napisany przy użyciu .NET7. Użycie innej wersji może skutkować utratą punktów
- Program, który się nie kompiluje - 0 pkt
- Należy pamiętać o **poprawnych** kodach HTTP. Niepoprawny kod HTTP jest równoznaczny z utratą punktów
- Pamiętaj o poprawnych nazwach zmiennych/metod/klas
- Wykorzystaj dodatkowe modele dla danych zwracanych i przyjmowanych przez
  końcówki – DTO (ang. Data Transfer Object)
- Pamiętaj o SOLID, DI
