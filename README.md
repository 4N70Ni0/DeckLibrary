# Español
Esta librería permite manipular una baraja mediante funciones.
La librería se encuentra dentro de "lib" y varios ejercicios en base a esta
baraja se encuentran dentro de "exercises". La documentación de esta baraja
se encuentra dentro de "Documentacion.md".

## Compilar

### Compilar la librería
```sh
msc -target:library -out:LibraryCards.dll Card.cs Deck.cs
```

### Compilar un ejercicio
```sh
msc -r:LibraryCards <ejercicio>
```

# English
This library allows you to manipulate a deck with functions.
You can find the library within the "lib" directory and various exercises which
uses this library inside of the directory "exercises".
You can read the documentation in the file "Documentacion.md" (in Spanish).

## Compile

### Compile the library
```sh
msc -target:library -out:LibraryCards.dll Card.cs Deck.cs
```

### Compile one exercise
```sh
msc -r:LibraryCards <exercise>
```
