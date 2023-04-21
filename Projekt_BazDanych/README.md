
Poniżej zaprezentowany jest diagram bazy danych wykorzystywanej w poniższych zadaniach.

![obraz](https://user-images.githubusercontent.com/101172592/172188767-a9db3d9d-616a-490d-9f09-b068e047b0c8.png)


Kolokwium powinno zostać zrealizowane z wykorzystaniem biblioteki Entity Framework w wersji
Core w podejściu Code First.
Należy zadbać o dodanie przykładowych danych do odpowiednich tabel.

1. Przygotuj końcówkę, której zadaniem będzie zwrócenie szczegółowych informacji na temat
określonej akcji. Zwrócony obiekt powinien zawierać wozy strażackie, które brały udział w tej
akcji. Wynik powinien zostać posortowany malejąco po dacie przydzielenia wozu do akcji.
Pamiętaj o odpowiednich statusach HTTP.

2. Przygotuj końcówkę, której celem będzie przypisanie wozu strażackiego do akcji. Ze względu
na cięcia budżetowe, do akcji mogą być przypisane maksymalnie 3 wozy strażackie.
Dodatkowo jeżeli docelowa akcja wymaga specjalnego wyposażenia, możemy przypisywać
tylko te wozy, które je posiadają. Ostatnią rzeczą, którą musimy sprawdzić – czy akcja nie
została już zakończona. Jeżeli któreś z powyższych ograniczeń zostanie złamane należy
przerwać wykonanie żądania i poinformować o tym użytkownika w stosowny sposób.

Pamiętaj o:

a. Utworzeniu Web API zgodnie z podejściem REST.

b. Poprawnym nazywaniu zmiennych, kontrolerów itp.

c. Utrzymaniu odpowiedniej struktury kodu.

d. Wstrzykiwaniu zależności w odpowiednich miejscach.

e. Obsłudze błędów.

f. Korzystaniu z DTO.


