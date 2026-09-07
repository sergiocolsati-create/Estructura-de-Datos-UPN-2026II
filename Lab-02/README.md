# Historial de Navegación — Listas Enlazadas Dobles

## Finalidad del laboratorio

Este proyecto corresponde al **Tema 2: Listas Enlazadas Dobles** del curso de Estructura de Datos. Su objetivo es implementar una lista enlazada doble, entender su estructura bidireccional y las operaciones de inserción y eliminación, y aplicar ese conocimiento a un problema real que requiera navegación en ambos sentidos.

La aplicación elegida para demostrarlo es un **simulador de historial de navegación web**, similar al que usan los navegadores (Chrome, Firefox, etc.) cuando permiten moverse hacia atrás y hacia adelante entre las páginas visitadas.

## Fundamento teórico

A diferencia de una lista enlazada simple (donde cada nodo solo apunta al siguiente), una **lista enlazada doble** permite recorrer la estructura en ambas direcciones. Cada nodo guarda tres cosas:

- **Dato**: la información que almacena el nodo (en este caso, el nombre de una página).
- **Siguiente**: referencia al nodo que viene después.
- **Anterior**: referencia al nodo que viene antes.

El primer nodo (**head**) tiene su `anterior` apuntando a `null`, y el último nodo (**tail**) tiene su `siguiente` apuntando a `null`. Esta doble referencia es justamente lo que hace posible un historial de navegación: cada "página visitada" es un nodo, y el usuario puede moverse entre ellas en cualquier dirección sin perder la ruta recorrida.

## Cómo funciona la aplicación

El programa simula el comportamiento de "Atrás" / "Adelante" de un navegador:

1. Cada vez que el usuario visita una nueva página, se crea un nodo nuevo y se agrega al final de la lista con `agregarAlFinal()`. El puntero de "página actual" se mueve a ese nuevo nodo.
2. Al presionar **Atrás**, el puntero de página actual se mueve al nodo `anterior`.
3. Al presionar **Adelante**, el puntero de página actual se mueve al nodo `siguiente`.
4. En todo momento, la interfaz muestra cuál es la página actual y el historial completo recorriendo la lista con `imprimirAdelante()`.

De esta forma, cada botón de la interfaz corresponde exactamente a una operación sobre la lista doble, lo que permite ver en vivo cómo se mueven los punteros `anterior` y `siguiente`.

## Estructura del proyecto

```
HistorialNavegacion/
├── Modelo/
│   ├── NodoDoble.cs        # Clase del nodo: dato, siguiente, anterior
│   └── ListaDoble.cs       # Clase de la lista: head, tail y sus métodos
├── Formularios/
│   └── Form1.cs            # Interfaz gráfica (Windows Forms)
├── Program.cs               # Punto de entrada de la aplicación
└── README.md
```

## Clases principales

### `NodoDoble`
Representa un nodo de la lista. Contiene:
- `Dato`: el nombre de la página (string).
- `Siguiente`: referencia al siguiente nodo.
- `Anterior`: referencia al nodo previo.

### `ListaDoble`
Representa la lista doblemente enlazada completa. Contiene:
- `Head`: primer nodo de la lista.
- `Tail`: último nodo de la lista.
- `agregarAlFinal(dato)`: agrega un nuevo nodo al final de la lista (nueva página visitada).
- `agregarAlInicio(dato)`: agrega un nuevo nodo al inicio de la lista.
- `eliminar(dato)`: elimina un nodo de la lista, reconectando sus vecinos.
- `imprimirAdelante()`: recorre la lista de principio a fin.
- `imprimirAtras()`: recorre la lista de fin a principio.

## Interfaz (Form1)

| Control | Función |
|---|---|
| `btnAtras` | Mueve el puntero de la página actual al nodo anterior |
| `btnAdelante` | Mueve el puntero de la página actual al nodo siguiente |
| `lblPaginaActual` | Muestra el nombre de la página en la que está parado el puntero |
| `txtNuevaPagina` | Campo de texto para ingresar el nombre de una nueva página |
| `btnVisitar` | Agrega la nueva página a la lista y mueve el puntero hacia ella |
| `lblHistorial` | Muestra el recorrido completo del historial |

## Cómo ejecutar el proyecto

1. Abrir la solución (`.sln`) en Visual Studio.
2. Verificar que el proyecto sea de tipo **Windows Forms App (.NET)**.
3. Compilar y ejecutar con `F5` o el botón "Iniciar".
4. Escribir el nombre de una página en el campo de texto y presionar **Visitar** para agregarla al historial.
5. Usar los botones **Atrás** y **Adelante** para navegar entre las páginas visitadas.

## Uso de inteligencia artificial

La IA generativa se utilizó únicamente como apoyo puntual (por ejemplo, para resolver dudas específicas durante la implementación), no como herramienta principal de desarrollo. Los diagramas de la estructura de nodos y del recorrido de la lista fueron elaborados de forma propia por el equipo, sin generación automática. Todo el contenido fue revisado, validado y comprendido por los integrantes antes de su entrega, conforme a la declaración de uso responsable de IA del laboratorio.

## Conclusiones esperadas

- La lista enlazada doble permite una navegación bidireccional eficiente, ideal para casos de uso como historiales de navegación.
- Manejar dos punteros por nodo (`anterior` y `siguiente`) exige más cuidado en la lógica de inserción y eliminación, pero brinda mayor flexibilidad que una lista simple.
- Implementar esta estructura sobre un caso práctico (el historial de un navegador) facilita entender su utilidad real más allá de la teoría.
