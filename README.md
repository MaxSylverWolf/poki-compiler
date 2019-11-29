# Poki Compiler instrukcje
## $ - koniec linii instrukcji normalnej
## # - koniec linii instrukcji w warunku/pętli/funkcji
## w configu w w appkey podać ścieżkę do folderu Resources (config w zależności od uruchamiania w danym folderze)
## 1. Kalkulator:

```swift 1 + 2$
swift 2 - 1$
swift 2 * 2$
swift 4 / 2$
swift pikacz + klikacz$
```

#### wynik to pikaczklikacz (sklejenie stringa)

## 2. Kalkulator z definiowaniem zmiennej:

```swift nazwa 1 + 2$
swift nazwa 2 - 1$
swift nazwa 2 * 2$
swift nazwa 4 / 2$
swift nazwa pikacz + klikacz$
```

#### wynik będzie zapisany pod zmienną "nazwa"
#### wyniki są wyświetlane na ekranie

## 3. Zwykłe definiowanie zmiennej:
* pokeball nazwa wartość$ (string lub liczba)

## 4. Definiowanie pętli i wykonywanie:
* go attack ILERAZY# ciąg instrukcji, każda instrukcja kończy się znakiem "#"
  * pętla kończy się znakiem $
  * ILERAZY może być nazwą zmiennej typu Double (konwertowana do Int przy zaokrąglaniu do podłogi)
* snippet
```
	swift nazwa 1 + 2$
	go attack nazwa#
	swift 2 + 2#
	$
```
## 5. Definiowanie warunku IF i wykonywanie:
* go when zmienna warunek zmienna2#
	* ciąg instrukcji warunku kończy się znakiem $
	* zmienna/zmienna2 mogą być tekstem bez " " lub liczbą/double
	* warunki dostępne to - >,<,=,!=,<= (=<),>= (=>)
* snippet
```
	swift zmienna 1 + 2$
	swift zmienna2 2 + 2$
	go when zmienna != zmienna2#
	swift 2 + 2#
	$
```
## 6. Wydruk na konsoli:
* pocket print ciag znakow roznych$
	* przy podaniu nazwy zmiennej zwróci ją jako ToString() gdy wpisze się po spacji za nazwą zmiennej getAll, inaczej getType, getAttack, getHealth, przy getValue nie trzeba wpisywać, wystarczy sama nazwa zmiennej, ale można
	
## 7. Zmienne przy pokedex:
* pokedex all - wypisanie listy zdefiniowanych zmiennych
* pokedex zmienna all  - wypisanie wartości zmiennej
* pokedex zmienna set atrybut wartość$ - zmiana wartości atrybutu zmiennej
* pokedex zmienna get atrybut - pobranie wartości atrybutu zmiennej
* pokedex release zmienna - uwolnienie zmiennej (wyrzucenie z pamięci)
* pokedex release all - uwolnienie wszystkich zmiennych (wyrzucenie z pamięci)

## 8. Funkcje evolution:
* evolution nazwafunkcji# - definiowanie funkcji
* battle go nazwafunkcji$ - wywołanie funkcji
* snippet
```
    evolution moja#
	swift 2 + 2#
	pokeball pikaczu pika#
	pokedex all#
	$
	battle go moja$
```