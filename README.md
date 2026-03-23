# APBD-Cw2-s32797

Projekt konsolowy w C# przygotowany w Riderze w ramach ćwiczenia APBD.  
Aplikacja realizuje system uczelnianej wypożyczalni sprzętu.

## Opis projektu

System umożliwia:
- dodawanie sprzętu,
- dodawanie użytkowników,
- wypożyczanie sprzętu,
- zwrot sprzętu,
- naliczanie kary za opóźnienie,
- sprawdzanie aktywnych wypożyczeń,
- sprawdzanie przeterminowanych wypożyczeń,
- generowanie raportu końcowego.

W projekcie wykorzystano programowanie obiektowe, dziedziczenie, klasy abstrakcyjne, interfejsy oraz własne wyjątki.

## Struktura projektu

Projekt został podzielony na kilka katalogów:

- `Models` – klasy domenowe opisujące obiekty systemu,
- `Services` – logika biznesowa systemu,
- `Enums` – typy wyliczeniowe,
- `Exceptions` – własne wyjątki.

### Najważniejsze klasy

#### Models
- `Equipment`
- `Laptop`
- `Projector`
- `Camera`
- `User`
- `Student`
- `Employee`
- `Rental`

#### Services
- `IEquipmentService`, `EquipmentService`
- `IUserService`, `UserService`
- `IRentalService`, `RentalService`
- `IReportService`, `ReportService`

#### Enums
- `EquipmentStatus`
- `UserType`

#### Exceptions
- `EquipmentNotFoundException`
- `EquipmentUnavailableException`
- `UserNotFoundException`
- `UserLimitExceededException`
- `RentalNotFoundException`
- `RentalAlreadyReturnedException`

## Uzasadnienie podziału projektu

Taki podział projektu został wybrany po to, aby oddzielić dane od logiki operacji.

- Klasy w folderze `Models` przechowują dane i opisują główne byty systemu.
- Klasy w folderze `Services` realizują operacje na tych danych, np. dodawanie sprzętu, wypożyczanie i zwrot.
- Folder `Enums` porządkuje typy wyliczeniowe wykorzystywane w wielu miejscach.
- Folder `Exceptions` pozwala czytelnie obsługiwać sytuacje błędne.

Dzięki temu kod jest bardziej uporządkowany i łatwiejszy do rozwijania niż rozwiązanie, w którym cała logika znajduje się w `Program.cs`.

## Odpowiedzialności klas

W projekcie starałem się nadać klasom pojedyncze, czytelne odpowiedzialności:

- `Equipment`, `User`, `Rental` – reprezentują dane domenowe,
- `EquipmentService` – zarządza sprzętem,
- `UserService` – zarządza użytkownikami,
- `RentalService` – obsługuje logikę wypożyczeń, zwrotów, limitów i kar,
- `ReportService` – generuje raport końcowy,
- `Program.cs` – pełni rolę scenariusza demonstracyjnego i pokazuje użycie systemu.

## Kohezja

Próba zadbania o kohezję jest widoczna w tym, że każda klasa realizuje jeden główny cel.

Przykłady:
- `RentalService` skupia się na wypożyczeniach i zwrotach,
- `EquipmentService` operuje tylko na sprzęcie,
- `UserService` operuje tylko na użytkownikach,
- `ReportService` odpowiada tylko za raport.

Dzięki temu klasy nie mieszają wielu różnych odpowiedzialności naraz.

## Coupling

Próba ograniczenia coupling jest widoczna w tym, że:
- logika biznesowa została przeniesiona z `Program.cs` do serwisów,
- serwisy komunikują się przez interfejsy,
- `Program.cs` nie implementuje sam reguł biznesowych, tylko korzysta z gotowych metod serwisów.

Przykładowo `ReportService` nie tworzy sam danych o sprzęcie i wypożyczeniach, tylko korzysta z `IEquipmentService` i `IRentalService`.

## Dlaczego taki podział klas i plików uznałem za sensowny

Uznałem ten podział za sensowny, ponieważ:
- odpowiada naturalnemu podziałowi problemu na obiekty i operacje,
- pozwala łatwo znaleźć miejsce odpowiedzialne za konkretną funkcję,
- ułatwia rozbudowę projektu,
- poprawia czytelność kodu,
- pozwala pokazać zasady programowania obiektowego w praktyce.

Dzięki temu projekt jest bardziej przejrzysty niż rozwiązanie oparte na jednej dużej klasie.

## Reguły biznesowe

W systemie zaimplementowano następujące reguły:
- student może mieć maksymalnie 2 aktywne wypożyczenia,
- pracownik może mieć maksymalnie 5 aktywne wypożyczenia,
- sprzęt można wypożyczyć tylko wtedy, gdy jest dostępny,
- po wypożyczeniu sprzęt otrzymuje status `Borrowed`,
- po zwrocie sprzęt wraca do statusu `Available`,
- kara za opóźnienie wynosi 10 za każdy dzień spóźnienia.

## Obsługa błędów

System wykorzystuje własne wyjątki do obsługi błędnych sytuacji, np.:
- próby pobrania nieistniejącego sprzętu,
- próby pobrania nieistniejącego użytkownika,
- próby wypożyczenia niedostępnego sprzętu,
- przekroczenia limitu aktywnych wypożyczeń,
- próby zwrotu nieistniejącego wypożyczenia,
- próby ponownego zwrotu już oddanego sprzętu.

## Scenariusz demonstracyjny

W `Program.cs` został przygotowany scenariusz pokazujący działanie systemu.

Scenariusz obejmuje:
1. dodanie sprzętu,
2. dodanie użytkowników,
3. poprawne wypożyczenia,
4. próbę błędnej operacji,
5. zwrot w terminie,
6. zwrot po terminie z naliczeniem kary,
7. wyświetlenie aktywnych wypożyczeń,
8. wyświetlenie przeterminowanych wypożyczeń,
9. wygenerowanie raportu końcowego.

## Uruchomienie projektu

1. Otworzyć projekt w Riderze.
2. Zbudować projekt.
3. Uruchomić aplikację konsolową.
4. Wynik działania zostanie wyświetlony w terminalu.

## Autor

Maksymilian Taraniuk  
s32797
